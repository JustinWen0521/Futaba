using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using ftd.data;
using ftd.nsql;
using System.Globalization;
namespace ftd.dataaccess
{
    /// <summary>
    /// {T}&lt;EOMS&gt;功能表/功能結構 {MenuStruct}
    /// </summary>
    public partial class EoMenuStructProvider
    {
        protected override void onSchemaLoaded()
        {
            addTypedCalcHandler()
                .setColumns(AppDataName.EOMS_NodeType_XX)
                .setReferences(AppDataName.EOMS_ParentId)
                .setHandler(dt => {
                    foreach (var row in dt)
                    {
                        if (row.EOMS_ParentId.isNullOrEmpty())
                            row.EOMS_NodeType_XX = "A";
                    }
                    var rows2 = dt.Where(x => x.EOMS_NodeType_XX.isNullOrEmpty()).Select(x=>x).ToArray();
                    var pks = rows2.Select(x => x.EOMS_NodeId).ToArray();
                    var qry = new NsDbQuery();
                    qry.setSelect(s => {
                        var t1 = s.from<EO_MenuStruct>();
                        s.select(t1.EOMS_ParentId);
                        s.Where = t1.EOMS_ParentId.batchin(pks.toConstReq1());
                        s.groupBy(t1.EOMS_ParentId);
                    });

                    //有子的節點
                    var pks2 = qry.queryKeys<string>().ToDictionary(x=> x);

                    foreach (var row2 in rows2)
                    {
                        row2.EOMS_NodeType_XX = pks2.ContainsKey(row2.EOMS_NodeId) ? "B" : "C";
                    }
                });

            addTypedCalcHandler()
                .setColumns(AppDataName.EOMS_MatchSiteId_XX)
                .setReferences(AppDataName.EOMS_ClickMode, AppDataName.EOMS_Url)
                .setHandler(dt => {
                    //var qry = new NsDbQuery();
                    //qry.setSelect(s => {
                    //    var t1 = s.from<EO_SignSite>();
                    //    s.select(t1.EOSS_SiteId, t1.EOSS_FilterUrl1, t1.EOSS_FilterUrl2);                    
                    //    s.Where = t1.EOSS_FilterUrl1 != "" | t1.EOSS_FilterUrl2 != "";
                    //});
                    //var dt1 = qry.queryData<EO_SignSiteDataTable>();

                    //foreach (var row in dt)
                    //{
                    //    if (row.EOMS_ClickMode != "U" || row.EOMS_Url.isNullOrEmpty())
                    //        continue;

                    //    foreach (var row1 in dt1)
                    //    {
                    //        if (!row1.EOSS_FilterUrl1.isNullOrEmpty())
                    //        {
                    //            if (row.EOMS_Url.StartsWith(row1.EOSS_FilterUrl1, true, CultureInfo.InvariantCulture))
                    //            {
                    //                row.EOMS_MatchSiteId_XX = row1.EOSS_SiteId;
                    //                break;
                    //            }
                    //        }

                    //        if (!row1.EOSS_FilterUrl2.isNullOrEmpty())
                    //        {
                    //            if (row.EOMS_Url.StartsWith(row1.EOSS_FilterUrl2, true, CultureInfo.InvariantCulture))
                    //            {
                    //                row.EOMS_MatchSiteId_XX = row1.EOSS_SiteId;
                    //                break;
                    //            }
                    //        }
                    //    }
                    //}               
                });

            addTypedCalcHandler()
                .setColumns(AppDataName.EOMS_ChildCount_XX
                    , AppDataName.EOMS_BrotherCount_XX
                    , AppDataName.EOMS_RootId_XX
                    , AppDataName.EOMS_LevelNo_XX
                    , AppDataName.EOMS_TreeLeftNo_XX
                    , AppDataName.EOMS_TreeRightNo_XX
                )
                .setReferences(AppDataName.EOMS_ParentId)
                .setHandler(dt => {
                    var qry = new NsDbQuery();
                    //調出全部的結構
                    qry.setSelect(s => {
                        var t1 = s.from<EO_MenuStruct>();
                        s.select(t1.EOMS_NodeId, t1.EOMS_ParentId, t1.EOMS_SortNo);
                        //s.Where = t1.EOMS_Viewable == "Y";
                    });
                    var dt1 = qry.queryData<EO_MenuStructDataTable>();

                    //計算樹結構
                    FtdDataHelper.TableTree.calcTreeNo(dt1, "X_TreeNo1", "X_TreeNo2", "X_Level",
                        dt11 => dt11.Where(x => x.EOMS_ParentId.isNullOrEmpty()).Select(x => x)
                        , (dt11, row11) =>
                        {
                            var pk = ((EO_MenuStructRow)row11).EOMS_NodeId;
                            return dt11.Where(x => x.EOMS_ParentId == pk);
                        }
                    );

                    var keys = dt1
                       .GroupBy(x => x.EOMS_ParentId.nullOrEmptyAs("@"))
                       .Select(x => new { ID = x.Key, ChildCount = x.Count() })
                       .ToDictionary(x => x.ID);

                    var roots = dt1.Where(x => x.EOMS_ParentId.isNullOrEmpty()).Select(x => x).ToArray();

                    //計算結點的資訊
                    foreach (var row in dt)
                    {
                        //if (!row.EOMS_Viewable.equalIgnoreCase("Y"))
                        //{
                        //    //row.EOMS_RootId_XX = root.EOMS_NodeId;
                        //    //row.EOMS_LevelNo_XX = level;
                        //    //row.EOMS_TreeLeftNo_XX = no1;
                        //    //row.EOMS_TreeRightNo_XX = no2;
                        //    continue;
                        //}

                        var key = keys.findKey(row.EOMS_NodeId);
                        //1
                        if (row.EOMS_ParentId.isNullOrEmpty())
                        {
                            row.EOMS_NodeType_XX = "A";
                        }
                        else
                        {
                            row.EOMS_NodeType_XX = key != null ? "B" : "C";
                        }

                        //2
                        var pkey = keys.findKey(row.EOMS_ParentId.nullOrEmptyAs("@"));
                        row.EOMS_BrotherCount_XX = (pkey == null) ? 0 : pkey.ChildCount;

                        //3
                        if (key != null)
                            row.EOMS_ChildCount_XX = key.ChildCount;
                        else
                            row.EOMS_ChildCount_XX = 0;

                        //4                        
                        var row1 = dt1.findByPrimaryKey(row.EOMS_NodeId);
                        var no1 = row1.getInt("X_TreeNo1").Value;
                        var no2 = row1.getInt("X_TreeNo2").Value;
                        var level = row1.getInt("X_Level").Value;
                        var root = roots.Where(x => no1 >= x.getInt("X_TreeNo1").Value && no2 <= x.getInt("X_TreeNo2").Value).First();
                        row.EOMS_RootId_XX = root.EOMS_NodeId;
                        row.EOMS_LevelNo_XX = level;
                        row.EOMS_TreeLeftNo_XX = no1;
                        row.EOMS_TreeRightNo_XX = no2;
                    }
                });            

            base.onSchemaLoaded();
        }

    }
}
