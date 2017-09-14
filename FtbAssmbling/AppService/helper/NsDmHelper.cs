using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ftd.data;
namespace ftd.nsql
{
    /// <summary>
    /// N-Sql Helper
    /// </summary>
    public class NsDmHelper
    {
        /// <summary>
        /// {T}組立機臺主檔 {AL_Assmbling}
        /// </summary>
        public static NsDmTypeQuery<AL_AssmblingDataTable, AL_AssmblingRow, AL_Assmbling> AL_Assmbling
        {
            get { return new NsDmTypeQuery<AL_AssmblingDataTable, AL_AssmblingRow,AL_Assmbling>(); }
        }

        /// <summary>
        /// {T}組立機臺明細 {AL_AssmblingDetail}
        /// </summary>
        public static NsDmTypeQuery<AL_AssmblingDetailDataTable, AL_AssmblingDetailRow, AL_AssmblingDetail> AL_AssmblingDetail
        {
            get { return new NsDmTypeQuery<AL_AssmblingDetailDataTable, AL_AssmblingDetailRow,AL_AssmblingDetail>(); }
        }

        /// <summary>
        /// {T}組立機臺主檔Log {AL_AssmblingLog}
        /// </summary>
        public static NsDmTypeQuery<AL_AssmblingLogDataTable, AL_AssmblingLogRow, AL_AssmblingLog> AL_AssmblingLog
        {
            get { return new NsDmTypeQuery<AL_AssmblingLogDataTable, AL_AssmblingLogRow,AL_AssmblingLog>(); }
        }

        /// <summary>
        /// &lt;AST&gt;測試 {TMP1}
        /// </summary>
        public static NsDmTypeQuery<AS_Tmp1DataTable, AS_Tmp1Row, AS_Tmp1> AS_Tmp1
        {
            get { return new NsDmTypeQuery<AS_Tmp1DataTable, AS_Tmp1Row,AS_Tmp1>(); }
        }

        /// <summary>
        /// &lt;CRCL&gt;班別{Class}
        /// </summary>
        public static NsDmTypeQuery<CR_ClassDataTable, CR_ClassRow, CR_Class> CR_Class
        {
            get { return new NsDmTypeQuery<CR_ClassDataTable, CR_ClassRow,CR_Class>(); }
        }

        /// <summary>
        /// &lt;CRC&gt;課程{Course}
        /// </summary>
        public static NsDmTypeQuery<CR_CourseDataTable, CR_CourseRow, CR_Course> CR_Course
        {
            get { return new NsDmTypeQuery<CR_CourseDataTable, CR_CourseRow,CR_Course>(); }
        }

        /// <summary>
        /// &lt;CRR&gt;報名{Registratio}
        /// </summary>
        public static NsDmTypeQuery<CR_RegistrationDataTable, CR_RegistrationRow, CR_Registration> CR_Registration
        {
            get { return new NsDmTypeQuery<CR_RegistrationDataTable, CR_RegistrationRow,CR_Registration>(); }
        }

        /// <summary>
        /// &lt;EOD&gt;部門{Department}
        /// </summary>
        public static NsDmTypeQuery<EO_DepartmentDataTable, EO_DepartmentRow, EO_Department> EO_Department
        {
            get { return new NsDmTypeQuery<EO_DepartmentDataTable, EO_DepartmentRow,EO_Department>(); }
        }

        /// <summary>
        /// &lt;EODM&gt;部門成員{DeptMember}
        /// </summary>
        public static NsDmTypeQuery<EO_DeptMemberDataTable, EO_DeptMemberRow, EO_DeptMember> EO_DeptMember
        {
            get { return new NsDmTypeQuery<EO_DeptMemberDataTable, EO_DeptMemberRow,EO_DeptMember>(); }
        }

        /// <summary>
        /// &lt;EOE&gt;人員{Employee}
        /// </summary>
        public static NsDmTypeQuery<EO_EmployeeDataTable, EO_EmployeeRow, EO_Employee> EO_Employee
        {
            get { return new NsDmTypeQuery<EO_EmployeeDataTable, EO_EmployeeRow,EO_Employee>(); }
        }

        /// <summary>
        /// &lt;EOET&gt;人員職稱{EmployeeTitle}
        /// </summary>
        public static NsDmTypeQuery<EO_EmployeeTitleDataTable, EO_EmployeeTitleRow, EO_EmployeeTitle> EO_EmployeeTitle
        {
            get { return new NsDmTypeQuery<EO_EmployeeTitleDataTable, EO_EmployeeTitleRow,EO_EmployeeTitle>(); }
        }

        /// <summary>
        /// {T}&lt;EOFPS&gt;程式功能授權{FunPermSet}
        /// </summary>
        public static NsDmTypeQuery<EO_FunPermSetDataTable, EO_FunPermSetRow, EO_FunPermSet> EO_FunPermSet
        {
            get { return new NsDmTypeQuery<EO_FunPermSetDataTable, EO_FunPermSetRow,EO_FunPermSet>(); }
        }

        /// <summary>
        /// &lt;EOLA&gt;登入帳號{LoginAccount}
        /// </summary>
        public static NsDmTypeQuery<EO_LoginAccountDataTable, EO_LoginAccountRow, EO_LoginAccount> EO_LoginAccount
        {
            get { return new NsDmTypeQuery<EO_LoginAccountDataTable, EO_LoginAccountRow,EO_LoginAccount>(); }
        }

        /// <summary>
        /// &lt;EOM&gt; 功能表定義{Menu}
        /// </summary>
        public static NsDmTypeQuery<EO_MenuDataTable, EO_MenuRow, EO_Menu> EO_Menu
        {
            get { return new NsDmTypeQuery<EO_MenuDataTable, EO_MenuRow,EO_Menu>(); }
        }

        /// <summary>
        /// {T}程式功能清單{EO_MenuFun}
        /// </summary>
        public static NsDmTypeQuery<EO_MenuFunDataTable, EO_MenuFunRow, EO_MenuFun> EO_MenuFun
        {
            get { return new NsDmTypeQuery<EO_MenuFunDataTable, EO_MenuFunRow,EO_MenuFun>(); }
        }

        /// <summary>
        /// {T}&lt;EOMP&gt;功能表/授權對象{MenuPerm}
        /// </summary>
        public static NsDmTypeQuery<EO_MenuPermDataTable, EO_MenuPermRow, EO_MenuPerm> EO_MenuPerm
        {
            get { return new NsDmTypeQuery<EO_MenuPermDataTable, EO_MenuPermRow,EO_MenuPerm>(); }
        }

        /// <summary>
        /// {T}&lt;EOMPS&gt;功能表/授權功能{MenuPermSet}
        /// </summary>
        public static NsDmTypeQuery<EO_MenuPermSetDataTable, EO_MenuPermSetRow, EO_MenuPermSet> EO_MenuPermSet
        {
            get { return new NsDmTypeQuery<EO_MenuPermSetDataTable, EO_MenuPermSetRow,EO_MenuPermSet>(); }
        }

        /// <summary>
        /// {T}&lt;EOMS&gt;功能表/功能結構 {MenuStruct}
        /// </summary>
        public static NsDmTypeQuery<EO_MenuStructDataTable, EO_MenuStructRow, EO_MenuStruct> EO_MenuStruct
        {
            get { return new NsDmTypeQuery<EO_MenuStructDataTable, EO_MenuStructRow,EO_MenuStruct>(); }
        }

        /// <summary>
        /// 權限主檔
        /// </summary>
        public static NsDmTypeQuery<EO_PermissionDataTable, EO_PermissionRow, EO_Permission> EO_Permission
        {
            get { return new NsDmTypeQuery<EO_PermissionDataTable, EO_PermissionRow,EO_Permission>(); }
        }

        /// <summary>
        /// &lt;EOPS&gt;權限設定表{PermissonSetting}
        /// </summary>
        public static NsDmTypeQuery<EO_PermissionSettingDataTable, EO_PermissionSettingRow, EO_PermissionSetting> EO_PermissionSetting
        {
            get { return new NsDmTypeQuery<EO_PermissionSettingDataTable, EO_PermissionSettingRow,EO_PermissionSetting>(); }
        }

        /// <summary>
        /// &lt;EOUE&gt;網站使用者事件主檔{UserEvent}
        /// </summary>
        public static NsDmTypeQuery<EO_UserEventDataTable, EO_UserEventRow, EO_UserEvent> EO_UserEvent
        {
            get { return new NsDmTypeQuery<EO_UserEventDataTable, EO_UserEventRow,EO_UserEvent>(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public static NsDmTypeQuery<EO_UserEventLogDataTable, EO_UserEventLogRow, EO_UserEventLog> EO_UserEventLog
        {
            get { return new NsDmTypeQuery<EO_UserEventLogDataTable, EO_UserEventLogRow,EO_UserEventLog>(); }
        }

        /// <summary>
        /// &lt;WTSD&gt;排程日期{ScheduleDate}
        /// </summary>
        public static NsDmTypeQuery<WT_ScheduleDateDataTable, WT_ScheduleDateRow, WT_ScheduleDate> WT_ScheduleDate
        {
            get { return new NsDmTypeQuery<WT_ScheduleDateDataTable, WT_ScheduleDateRow,WT_ScheduleDate>(); }
        }

        /// <summary>
        /// &lt;WTST&gt;排程工作{ScheduleTask}
        /// </summary>
        public static NsDmTypeQuery<WT_ScheduleTaskDataTable, WT_ScheduleTaskRow, WT_ScheduleTask> WT_ScheduleTask
        {
            get { return new NsDmTypeQuery<WT_ScheduleTaskDataTable, WT_ScheduleTaskRow,WT_ScheduleTask>(); }
        }

        /// <summary>
        /// &lt;WTST&gt;訂單{ScheduleTask}
        /// </summary>
        public static NsDmTypeQuery<ZZ_OrderDataTable, ZZ_OrderRow, ZZ_Order> ZZ_Order
        {
            get { return new NsDmTypeQuery<ZZ_OrderDataTable, ZZ_OrderRow,ZZ_Order>(); }
        }

        /// <summary>
        /// &lt;ZZOD&gt;訂單明細{ZZ_OrderDetail}
        /// </summary>
        public static NsDmTypeQuery<ZZ_OrderDetailDataTable, ZZ_OrderDetailRow, ZZ_OrderDetail> ZZ_OrderDetail
        {
            get { return new NsDmTypeQuery<ZZ_OrderDetailDataTable, ZZ_OrderDetailRow,ZZ_OrderDetail>(); }
        }

    }
}
