using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ftd.data;
using ftd.dataaccess;
using ftd.nsql;

namespace ftd.service
{
    /// <summary>
    /// 權限服務
    /// </summary>
    public class AppPermissionService : FtdPermissionService
    {
        public override void initService()
        {
            //載入權限設定
            loadPermissionFromClass(typeof(AppPermissionName));
            base.initService();
        }

        public override List<string> queryActorRoles(string actor_id)
        {
            // 查詢指定使用者{動作者}的權限清單
            // 如果使用者為動作者的話，會包含其所屬{動作者、部門、群組}權限與動作者所屬部門所屬群組權限           
            var qry = new NsDbQuery();
            var actor_ids = new List<string>();

            var rowe = NsDmHelper.EO_Employee.wherepk(actor_id).queryFirst();
            if (rowe != null)
            {
                #region [動作者]
                //動作者所屬部門、群組
                qry.setSelect(s =>
                {
                    var t1 = s.from<EO_DeptMember>();
                    s.Where = t1.EODM_MemberId == actor_id.toConstReq1();
                    s.select(t1.EODM_DeptId);
                });
                var keys1 = qry.queryKeys<string>();

                //部門所屬群組           
                qry.setSelect(s =>
                {
                    var t1 = s.from<EO_DeptMember>();
                    s.Where = t1.EODM_MemberId.batchin(keys1.toConstReq1());
                    s.select(t1.EODM_DeptId);
                });
                var keys2 = qry.queryKeys<string>();

                //得到 部門 群組
                actor_ids = keys1.Union(keys2).Distinct().ToList();
                #endregion
            }
            else
            {
                #region [部門、群組]
                //部門所屬群組           
                qry.setSelect(s =>
                {
                    var t1 = s.from<EO_DeptMember>();
                    s.Where = t1.EODM_MemberId == actor_id.toConstReq1();
                    s.select(t1.EODM_DeptId);
                });
                var keys1 = qry.queryKeys<string>();
                keys1.Add(actor_id);

                //得到 部門 群組
                actor_ids = keys1;
                #endregion
            }
            return actor_ids;
        }

        /// <summary>
        /// 查詢動作者{人、部門、群組}所擁有的權限(不及物)
        /// </summary> 
        public override List<string> queryActorsPremissons(List<string> actor_ids)
        {
            var qry = new NsDbQuery();

            //動作者所擁有的權限
            qry.setSelect(s =>
            {
                var t1 = s.from<EO_PermissionSetting>();
                var t2 = s.join<EO_Permission>()
                    .on(t => t.EOP_PermissionId == t1.EOPS_PermissionId);
                s.select(t2.EOP_PermissionCode);
                s.Where =
                    t1.EOPS_PermissionUserId.batchin(actor_ids.toConstReq1())
                    & t2.EOP_IsObjectNeed == "N" //免物件                    
                    ;
                s.groupBy(t2.EOP_PermissionCode);
                s.unionAll(_s =>
                {
                    var _t1 = _s.from<EO_Permission>();
                    _s.Where = _t1.EOP_IsEveryOneAllow == "Y";
                    _s.select(_t1.EOP_PermissionCode);
                });

            });
            var names = qry.queryKeys<string>().Distinct().ToList();

            return names;
        }

        /// <summary>
        /// 使用者{usr_perm}是否包含物件{obj_id}的權限{perm_name}
        /// </summary>
        public override bool containObjectPermission(FtdActorPermission actor_perm, string obj_id, string perm_name)
        {
            if (actor_perm.containPermisson(perm_name))
                return true;

            var perm_codes = getPermission(perm_name).queryObjPermNames();

            var dt = NsDmHelper.EO_PermissionSetting
                    .where(t => t.EOPS_ObjectId == obj_id.toConstReq1()
                        & t.EOPS_PermissionCode_XX.batchin(perm_codes.toConstReq1())
                     )
                    .query();

            foreach (var row in dt)
            {
                if (row.EOPS_PermissionUserId.inAny(actor_perm.ActorIds))
                    return true;
            }
            return false;
        }
    }
}
