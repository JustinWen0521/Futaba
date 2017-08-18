using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using ftd.nsql;
using ftd.service;
using ftd.data.nstable;
namespace ftd.data
{
    /// <summary>
    /// 權限主檔
    /// </summary>
    public interface EO_Permission : INsTable
    {
        /// <summary>
        /// [DIRECT]*權限ID{PK}：【key(EOP)】
        /// </summary> 
        NsColumn EOP_PermissionId { get; }
        /// <summary>
        /// [DIRECT]*權限說明{Description:100}：【最高權限】
        /// </summary> 
        NsColumn EOP_Description { get; }
        /// <summary>
        /// [DIRECT]*開放給每個人：A:是 B:否             ※若為是，則不用設定表每個人皆可使用
        /// </summary> 
        NsColumn EOP_IsEveryOneAllow { get; }
        /// <summary>
        /// [DIRECT]#開放給每個人：A:是 B:否             ※若為是，則不用設定表每個人皆可使用
        /// </summary> 
        NsColumn EOP_IsEveryOneAllowName_XX { get; }
        /// <summary>
        /// [DIRECT]*需指定物件：A:是 B:否             ※若為是，則該權限需另外指派物件.
        /// </summary> 
        NsColumn EOP_IsObjectNeed { get; }
        /// <summary>
        /// [DIRECT]#需指定物件：A:是 B:否             ※若為是，則該權限需另外指派物件.
        /// </summary> 
        NsColumn EOP_IsObjectNeedName_XX { get; }
        /// <summary>
        /// [DIRECT]*權限CODE{PermissionCode:50}：【APN_KM_Admin】
        /// </summary> 
        NsColumn EOP_PermissionCode { get; }
        /// <summary>
        /// [DIRECT]*權限名稱{PermissionName:50}：【系統\KM\系統管理員】
        /// </summary> 
        NsColumn EOP_PermissionName { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_PermissionNsTable : NsTable, EO_Permission
        {
            public NsColumn EOP_PermissionId
            {
                  get { return this["EOP_PermissionId"]; }
            }
            public NsColumn EOP_Description
            {
                  get { return this["EOP_Description"]; }
            }
            public NsColumn EOP_IsEveryOneAllow
            {
                  get { return this["EOP_IsEveryOneAllow"]; }
            }
            public NsColumn EOP_IsEveryOneAllowName_XX
            {
                  get { return this["EOP_IsEveryOneAllowName_XX"]; }
            }
            public NsColumn EOP_IsObjectNeed
            {
                  get { return this["EOP_IsObjectNeed"]; }
            }
            public NsColumn EOP_IsObjectNeedName_XX
            {
                  get { return this["EOP_IsObjectNeedName_XX"]; }
            }
            public NsColumn EOP_PermissionCode
            {
                  get { return this["EOP_PermissionCode"]; }
            }
            public NsColumn EOP_PermissionName
            {
                  get { return this["EOP_PermissionName"]; }
            }
        }
    }
}
