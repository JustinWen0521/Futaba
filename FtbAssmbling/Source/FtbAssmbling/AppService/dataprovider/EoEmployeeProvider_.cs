using ftd.data;
using ftd.nsql;
using ftd.service;
using ftd.nsql.provider;
namespace ftd.dataaccess
{
    /// <summary>
    /// 
    /// </summary>
    public partial class EoEmployeeProvider
    {
        protected override void onSchemaLoaded()
        {
            addTypedSqlHandler()
                .setColumns(AppDataName.EOE_EmployeeFullName_XX)
                .setHandler(t1 => (t1.PrimaryKey == null).istrue("", t1.EOE_DepartmentName_XX + "-" + t1.EOE_EmployeeName + " " + t1.EOE_EmployeeTitleName_XX))
                //.setHandler(t1 => (t1.PrimaryKey == null).istrue("", t1.EOE_OrganSName_XX + "-" + t1.EOE_EmployeeName + " " + t1.EOE_EmployeeTitleName_XX))
                ;

            addTypedSqlHandler()
                .setColumns(AppDataName.EOE_EmployeeStandardName_XX)
                .setHandler(t1 => (t1.PrimaryKey == null).istrue("", t1.EOE_EmployeeName + " " + t1.EOE_EmployeeTitleName_XX))
                ;

            addTypedSqlHandler()
                .setColumns(AppDataName.EOE_SexName_XX)
                .setHandler(t => t.EOE_Sex.decode("A", "男", "B", "女", t.EOE_Sex))
                ;

            addTypedSqlHandler()
                .setColumns(AppDataName.EOE_EmployeeSearchName_XX)
                .setHandler( t1 => t1.EOE_EmployeeName + NSQL.iif(t1.EOE_EmployeeTitleName_XX.isnull("") != "", " " + t1.EOE_EmployeeTitleName_XX.isnull(""), "") + NSQL.iif(t1.EOE_EmployeeEmail != "", " (" + t1.EOE_EmployeeEmail + ")", ""))
                ;

            addTypedSqlHandler()
                .setColumns(AppDataName.EOE_IsLeave_XX)
                .setHandler(t1 => NSQL.iif(t1.EOE_LeaveDate != null, "T", "F"))
                ;

            addTypedSqlHandler()
                .setColumns(AppDataName.EOE_CU_IsLoginUser_XX)
                .setHandler(t => {
                    var userId = NsQueryContext.getCurrentUserId();
                    return (t.EOE_EmployeeId == userId).istrue("T", "F");
                });
            
            base.onSchemaLoaded();
        }
    }
}
