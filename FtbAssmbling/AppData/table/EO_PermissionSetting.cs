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
    /// &lt;EOPS&gt;權限設定表{PermissonSetting}
    /// </summary>
    public interface EO_PermissionSetting : INsTable
    {
        /// <summary>
        /// [DIRECT]*權限設定Id{PermissionSettingId}：【PK&lt;EOPS&gt;】
        /// </summary> 
        NsColumn EOPS_PermissionSettingId { get; }
        /// <summary>
        /// [DIRECT]*開放給每個人：A:是 B:否             ※若為是，則不用設定表每個人皆可使用&lt;br/&gt;
        /// </summary> 
        NsColumn EOPS_IsEveryOneAllow_XX { get; }
        /// <summary>
        /// [DIRECT]*需指定物件：A:是 B:否             ※若為是，則該權限需另外指派物件.&lt;br/&gt;
        /// </summary> 
        NsColumn EOPS_IsObjectNeed_XX { get; }
        /// <summary>
        /// [DIRECT]權限物Id{ObjectId}：【&lt;KEY&gt;】※若IsObjectNedd為是，則該需指派物件
        /// </summary> 
        NsColumn EOPS_ObjectId { get; }
        /// <summary>
        /// [DIRECT]#權限物名稱{ObjectName_XX}：【[部門]資訊中心】
        /// </summary> 
        NsColumn EOPS_ObjectName_XX { get; }
        /// <summary>
        /// [DIRECT]*權限CODE{PermissionCode:50}：【APN_KM_Admin】&lt;br/&gt;
        /// </summary> 
        NsColumn EOPS_PermissionCode_XX { get; }
        /// <summary>
        /// [DIRECT]*權限ID{PermissionId}:【KEY&lt;EOP&gt;】
        /// </summary> 
        NsColumn EOPS_PermissionId { get; }
        /// <summary>
        /// [DIRECT]*權限名稱{PermissionName:50}：【系統\KM\系統管理員】&lt;br/&gt;
        /// </summary> 
        NsColumn EOPS_PermissionName_XX { get; }
        /// <summary>
        /// [DIRECT]*人員ID{PermissionUserId}：【KEY&lt;EOE&gt;|KEY&lt;EOD&gt;】
        /// </summary> 
        NsColumn EOPS_PermissionUserId { get; }
        /// <summary>
        /// [DIRECT]*部門名稱{DepartmentName:50}：【資訊中心】&lt;br/&gt;#完整姓名{EmployeeFullName_XX}：【市政府-林勝文 組長】&lt;br/&gt;
        /// </summary> 
        NsColumn EOPS_PermissionUserName_XX { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_PermissionSettingNsTable : NsTable, EO_PermissionSetting
        {
            public NsColumn EOPS_PermissionSettingId
            {
                  get { return this["EOPS_PermissionSettingId"]; }
            }
            public NsColumn EOPS_IsEveryOneAllow_XX
            {
                  get { return this["EOPS_IsEveryOneAllow_XX"]; }
            }
            public NsColumn EOPS_IsObjectNeed_XX
            {
                  get { return this["EOPS_IsObjectNeed_XX"]; }
            }
            public NsColumn EOPS_ObjectId
            {
                  get { return this["EOPS_ObjectId"]; }
            }
            public NsColumn EOPS_ObjectName_XX
            {
                  get { return this["EOPS_ObjectName_XX"]; }
            }
            public NsColumn EOPS_PermissionCode_XX
            {
                  get { return this["EOPS_PermissionCode_XX"]; }
            }
            public NsColumn EOPS_PermissionId
            {
                  get { return this["EOPS_PermissionId"]; }
            }
            public NsColumn EOPS_PermissionName_XX
            {
                  get { return this["EOPS_PermissionName_XX"]; }
            }
            public NsColumn EOPS_PermissionUserId
            {
                  get { return this["EOPS_PermissionUserId"]; }
            }
            public NsColumn EOPS_PermissionUserName_XX
            {
                  get { return this["EOPS_PermissionUserName_XX"]; }
            }
        }
    }
}
