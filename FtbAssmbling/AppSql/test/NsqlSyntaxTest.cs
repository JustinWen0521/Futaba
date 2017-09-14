using System;
using System.Data;
using ftd.nsql;

namespace ftd.test
{
    public static class NsqlSyntaxTest
    {
        internal static NsSqlFunc get_datatable_sql(string systemName, DataTable dt)
        {
            if (dt.Rows.Count == 0)
                throw new Exception("DataTable Has No Any Data");
            NsSqlFunc get_table = (s) =>
            {
                var row = dt.Rows[0];

                s.fromEmpty(systemName);
                //var idx = 0;
                //var string_null = (string) null;
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.DataType == typeof(string))
                    {
                        if (row[col] == DBNull.Value)
                            s.selectAppend(((string) null).toConst().As("C" + col.Ordinal));
                        else
                            s.selectAppend(((string)row[col]).toConst().As("C" + col.Ordinal));                       
                    }

                    if (col.DataType == typeof(int))
                    {
                        if (row[col] == DBNull.Value)
                            s.selectAppend(((string)null).toConst().As("C" + col.Ordinal));
                        else
                            s.selectAppend(((int)row[col]).ToString().toConst().As("C" + col.Ordinal));
                    }

                    if (col.DataType == typeof(decimal))
                    {
                        if (row[col] == DBNull.Value)
                            s.selectAppend(((string)null).toConst().As("C" + col.Ordinal));
                        else
                            s.selectAppend(((decimal)row[col]).ToString().toConst().As("C" + col.Ordinal));
                    }

                    if (col.DataType == typeof(DateTime))
                    {
                        if (row[col] == DBNull.Value)
                            s.selectAppend(((string)null).toConst().As("C" + col.Ordinal));
                        else
                            s.selectAppend(((DateTime)row[col]).toConst().tostring(NsDataFormat.DATE_EDateTime).toNetValue<string>().toConst().As("C" + col.Ordinal));
                    }
                }

                for (var i = 0; i < dt.Rows.Count - 1; i++)
                {
                    row = dt.Rows[i + 1];

                    s.unionAll(_s => {
                        _s.fromEmpty(systemName);
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.DataType == typeof(string))
                            {
                                if (row[col] == DBNull.Value)
                                    _s.selectAppend(((string)null).toConst());
                                else
                                    _s.selectAppend(((string)row[col]).toConst());
                            }

                            if (col.DataType == typeof(int))
                            {
                                if (row[col] == DBNull.Value)
                                    _s.selectAppend(((string)null).toConst());
                                else
                                    _s.selectAppend(((int)row[col]).ToString().toConst());
                            }

                            if (col.DataType == typeof(decimal))
                            {
                                if (row[col] == DBNull.Value)
                                    _s.selectAppend(((string)null).toConst());
                                else
                                    _s.selectAppend(((decimal)row[col]).ToString().toConst());
                            }

                            if (col.DataType == typeof(DateTime))
                            {
                                if (row[col] == DBNull.Value)
                                    _s.selectAppend(((string)null).toConst());
                                else
                                    _s.selectAppend(((DateTime)row[col]).toConst().tostring(NsDataFormat.DATE_EDateTime).toNetValue<string>().toConst());
                            }
                        }
                    });
                }               
            };

            NsSqlFunc get_table2 = (s) => {
                var t1 = s.fromSelect(get_table);
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.DataType == typeof(string))
                    {
                        s.selectAppend(t1["C" + col.Ordinal].As(col.ColumnName));
                    }
                    if (col.DataType == typeof(int))
                    {
                        s.selectAppend(t1["C" + col.Ordinal].tointeger().As(col.ColumnName));
                    }
                    if (col.DataType == typeof(Decimal))
                    {
                        s.selectAppend(t1["C" + col.Ordinal].todecimal(3).As(col.ColumnName));
                    }
                    if (col.DataType == typeof(DateTime))
                    {
                        s.selectAppend(t1["C" + col.Ordinal].todatetime(NsDataFormat.DATE_EDateTime).As(col.ColumnName));
                    }
                }
            };

            return get_table2;
        }

        public static void testAll()
        {
            var system_name = "EO";
            var long_col_name = "A".PadRight(300, '0');

            //#region [1]
            //{

            //    var dts_1 = new DataTable();
            //    dts_1.Columns.Add("ID", typeof(string));
            //    dts_1.Columns.Add(long_col_name, typeof(string));
            //    dts_1.Columns.Add("Money", typeof(int));
            //    dts_1.Columns.Add("EntryDate", typeof(DateTime));
            //    dts_1.Columns.Add("Percent", typeof(Decimal));
            //    dts_1.Rows.Add("ID001", @"Jack''s Name", null, "2009/10/1 12:30:40", 10.21m);
            //    dts_1.Rows.Add("ID002", "Mary\"'or''='", 200, null, 22.45m);
            //    dts_1.Rows.Add("\"or\"=\" -- select node", "David--;&12345;", 300, "2009/10/3 12:30:40", null);
            //    dts_1.Rows.Add("ID004", null, 300, "2009/10/4 12:30:40", 19234.8m);

            //    Console.WriteLine("Test 1");
            //    var qry = new NsDbQuery();
            //    qry.setSelect(s =>
            //    {
            //        var t = s.fromSelect(get_datatable_sql(system_name, dts_1))
            //            .typed(t => new { ID = t["ID"], sName = t[long_col_name], iMoney = t["Money"], dEntryDate = t["EntryDate"], mPercent = t["Percent"] });
            //        s.select(
            //            t.Cols.ID
            //            , t.Cols.sName
            //            , t.Cols.sName.As("C1")
            //            , t.Cols.dEntryDate
            //            , t.Cols.mPercent
            //            , t.Cols.iMoney
            //            , t.Cols.sName.substr(1, 2).As("C2")
            //            , t.Cols.sName.substr(1, 100).As("C3")
            //            , t.Cols.sName.left(2).As("C4")
            //            , t.Cols.sName.left(100).As("C5")
            //            , t.Cols.sName.isnull("Ken").As("C6")
            //            , t.Cols.sName.right(1).As("C7")
            //            , t.Cols.sName.right(100).As("C8")
            //            , t.Cols.sName.upper().As("C9")
            //            , t.Cols.sName.lower().As("C10")
            //            , t.Cols.iMoney.tostring().As("C12")
            //            , t.Cols.iMoney.todecimal(1).As("C13")
            //            , t.Cols.iMoney.isnull(100).As("C14")
            //        );
            //    });
            //    var BatchDataTable = qry.queryData();

            //    Console.WriteLine("Test 2");
            //    qry.setSelect(s =>
            //    {
            //        var t = s.fromSelect(get_datatable_sql(system_name, dts_1))
            //            .typed(t => new { ID = t["ID"], sName = t[long_col_name], iMoney = t["Money"], dEntryDate = t["EntryDate"], mPercent = t["Percent"] });
            //        s.select(
            //            t.Cols.mPercent.tostring().As("C1")
            //            , t.Cols.mPercent.tointeger().As("C2")
            //            , t.Cols.mPercent.round(0).As("C3")
            //            , t.Cols.mPercent.round(1).As("C4")
            //            , t.Cols.mPercent.round(3).As("C5")
            //            , t.Cols.mPercent.isnull(10.5m).As("C6")
            //            , t.Cols.dEntryDate.tostring(NsDataFormat.DATE_EDate).As("C7")
            //            , t.Cols.dEntryDate.tostring(NsDataFormat.DATE_EDateTime).As("C71")
            //            , t.Cols.dEntryDate.tostring(NsDataFormat.DATE_EDateTime16).As("C72")
            //            , t.Cols.dEntryDate.tostring(NsDataFormat.DATE_MSSQL_120).As("C73")
            //            , t.Cols.dEntryDate.tostring(NsDataFormat.DATE_YYYYMMDD).As("C74")
            //            , t.Cols.dEntryDate.tostring(NsDataFormat.DATE_YYYYMMDDHHMMSS).As("C75")
            //            , t.Cols.dEntryDate.tostring().As("C76")
            //        );
            //    });
            //    BatchDataTable = qry.queryData();
            //} 
            //#endregion

            #region [DateTime Test]
            {
                Console.WriteLine("DateTime Test");
                var dts = new DataTable();
                dts.Columns.Add("Date1", typeof(string));
                dts.Columns.Add("Date2", typeof(string));
                dts.Columns.Add("Date3", typeof(string));
                dts.Columns.Add("Date4", typeof(string));
                dts.Rows.Add("20080911", "235959", "2009-12-30 23:59:59", "2009/12/30 23:59:59");
                dts.Rows.Add(null, null, null, null);

                var qry = new NsDbQuery();
                qry.setSelect(s =>
                {
                    var t1 = s.fromSelect(get_datatable_sql(system_name, dts))
                        .typed(t => new { Date1 = t["Date1"], Date2 = t["Date2"], Date3 = t["Date3"], Date4 = t["Date4"] });
                    s.select(
                        t1.Cols.Date1.todatetime(NsDataFormat.DATE_YYYYMMDD).As("C1")
                        , (t1.Cols.Date1 + t1.Cols.Date2).todatetime(NsDataFormat.DATE_YYYYMMDDHHMMSS).As("C2")
                        , t1.Cols.Date3.todatetime(NsDataFormat.DATE_MSSQL_120).As("C3")
                        , t1.Cols.Date4.todatetime(NsDataFormat.DATE_EDateTime).As("C4")
                        , t1.Cols.Date4.left(10).todatetime(NsDataFormat.DATE_EDate).As("C5")
                        , t1.Cols.Date4.left(16).todatetime(NsDataFormat.DATE_EDateTime16).As("C7")
                    );
                });
                var dt = qry.queryData();

            } 
            #endregion

            #region [JoinTest]
            {
                Console.WriteLine("JoinTest");
                var dts1 = new DataTable();
                dts1.Columns.Add("ID", typeof(string));                
                dts1.Rows.Add("A");
                dts1.Rows.Add("B");
                dts1.Rows.Add("C");
                dts1.Rows.Add("D");

                var dts2 = new DataTable();
                dts2.Columns.Add("ID", typeof(string));
                dts2.Rows.Add("A1");
                dts2.Rows.Add("B");
                dts2.Rows.Add("C1");
                dts2.Rows.Add("D");                

                var qry = new NsDbQuery();
                qry.setSelect(s =>
                {
                    var t1 = s.fromSelect(get_datatable_sql(system_name, dts1))
                        .typed(t => new { ID = t["ID"] });
                    var t2 = s.joinSelect(get_datatable_sql(system_name, dts2))
                        .on(t => t1.Cols.ID == t["ID"])
                        .typed(t => new { ID = t["ID"] });
                    s.select(
                        t1.Cols.ID.isnull("#").As("ID1")
                        , t2.Cols.ID.isnull("#").As("ID2")
                    );
                    s.orderBy(s.Selects[0].Asc, s.Selects[1].Asc);
                });
                var dt = qry.queryData();

                qry.setSelect(s =>
                {
                    var t1 = s.fromSelect(get_datatable_sql(system_name, dts1))
                        .typed(t => new { ID = t["ID"] });
                    var t2 = s.leftJoinSelect(get_datatable_sql(system_name, dts2))
                        .on(t => t1.Cols.ID == t["ID"])
                        .typed(t => new { ID = t["ID"] });
                    s.select(
                        t1.Cols.ID.isnull("#").As("ID1")
                        , t2.Cols.ID.isnull("#").As("ID2")
                    );
                    s.orderBy(s.Selects[0].Asc, s.Selects[1].Asc);
                });
                var dt2 = qry.queryData();

                qry.setSelect(s =>
                {
                    var t1 = s.fromSelect(get_datatable_sql(system_name, dts1))
                        .typed(t => new { ID = t["ID"] });
                    var t2 = s.rightJoinSelect(get_datatable_sql(system_name, dts2))
                        .on(t => t1.Cols.ID == t["ID"])
                        .typed(t => new { ID = t["ID"] });
                    s.select(
                        t1.Cols.ID.isnull("#").As("ID1")
                        , t2.Cols.ID.isnull("#").As("ID2")
                    );
                    s.orderBy(s.Selects[0].Asc, s.Selects[1].Asc);
                });
                var dt3 = qry.queryData();

                qry.setSelect(s =>
                {
                    var t1 = s.fromSelect(get_datatable_sql(system_name, dts1))
                        .typed(t => new { ID = t["ID"] });
                    var t2 = s.fullJoinSelect(get_datatable_sql(system_name, dts2))
                        .on(t => t1.Cols.ID == t["ID"])
                        .typed(t => new { ID = t["ID"] });
                    s.select(
                        t1.Cols.ID.isnull("#").As("ID1")
                        , t2.Cols.ID.isnull("#").As("ID2")
                    );
                    s.orderBy(s.Selects[0].Asc, s.Selects[1].Asc);
                });
                var dt4 = qry.queryData();

            }
            #endregion

        }
    }
}
