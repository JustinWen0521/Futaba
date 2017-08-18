using ftd.data;
using ftd.nsql;
namespace ftd.dataaccess
{
    /// <summary>
    /// {T}&lt;EOMP&gt;功能表/授權對象{MenuPerm}
    /// </summary>
    public partial class EoMenuPermProvider
    {
        protected override void onSchemaLoaded()
        {  
            addTypedSqlHandler()
                .setColumns(AppDataName.EOMP_TargetKindName_XX)
                .setHandler(
                    t => t.EOMP_TargetKind.decode("A", "員工", "B", "部門/群組", "C", "職稱", "D", "權限")
                    //t => t.EOMP_TargetKind.decode("A", "員工", "B", "群組", "C", "職稱", "D", "權限", "E", "機關")
                );

            addTypedSqlHandler()
                .setColumns(AppDataName.EOMP_ViewKindName_XX)
                .setHandler(
                    t => t.EOMP_ViewKind.decode("A", "可檢視", "B", "不可檢視")
                );

            addTypedSqlHandler()
                .setColumns(AppDataName.EOMP_TargetCode_XX)
                .setHandler( t1 => {                   
                    var ta = t1.tryLink<EO_Employee>(t => t1.EOMP_TargetId == t.EOE_EmployeeId);
                    var tb = t1.tryLink<EO_Department>(t => t1.EOMP_TargetId == t.EOD_DepartmentId);
                    var tc = t1.tryLink<EO_EmployeeTitle>(t => t1.EOMP_TargetId == t.EOET_EmployeeTitleId);
                    var td = t1.tryLink<EO_Permission>(t => t1.EOMP_TargetId == t.EOP_PermissionId);
                    //var te = t1.tryLink<SY_Organ>(t => t1.EOMP_TargetId == t.SYO_OrganId);

                    return NSQL.@case()
                        .when(ta.PrimaryKey != null, "(員工)" + ta.EOE_EmployeeCode)
                        .when(tb.PrimaryKey != null, "(" + tb.EOD_DepartmentTypeName_XX + ")" + tb.EOD_DepartmentCode)
                        .when(tc.PrimaryKey != null, "(職稱)" + tc.EOET_TitleCode)
                        .when(td.PrimaryKey != null, "(權限)" + td.EOP_PermissionCode)
                        //.when(te.PrimaryKey != null, "(機關)" + te.SYO_OrganId)
                        .@else(t1.EOMP_TargetId)
                        .end();
                });

            addTypedSqlHandler()
                .setColumns(AppDataName.EOMP_TargetName_XX)
                .setHandler( t1 => {                   
                    var ta = t1.tryLink<EO_Employee>(t => t1.EOMP_TargetId == t.EOE_EmployeeId);
                    var tb = t1.tryLink<EO_Department>(t => t1.EOMP_TargetId == t.EOD_DepartmentId);
                    var tc = t1.tryLink<EO_EmployeeTitle>(t => t1.EOMP_TargetId == t.EOET_EmployeeTitleId);
                    var td = t1.tryLink<EO_Permission>(t => t1.EOMP_TargetId == t.EOP_PermissionId);
                    //var te = t1.tryLink<SY_Organ>(t => t1.EOMP_TargetId == t.SYO_OrganId);

                    return NSQL.@case()
                        .when(ta.PrimaryKey != null, "(員工)" + ta.EOE_EmployeeName)
                        .when(tb.PrimaryKey != null, "(" + tb.EOD_DepartmentTypeName_XX + ")" + tb.EOD_DepartmentName)
                        .when(tc.PrimaryKey != null, "(職稱)" + tc.EOET_TitleName)
                        .when(td.PrimaryKey != null, "(權限)" + td.EOP_PermissionName)
                        //.when(te.PrimaryKey != null, "(機關)" + te.SYO_OrganSName)
                        .@else(t1.EOMP_TargetId)
                        .end();
                });

            base.onSchemaLoaded();
        }

    }
}
