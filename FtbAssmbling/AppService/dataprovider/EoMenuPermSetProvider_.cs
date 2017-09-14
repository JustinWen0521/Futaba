using System.Collections.Generic;
using System.Collections;
using System.Linq;
using ftd.data;
using ftd.nsql;
using ftd.service;
namespace ftd.dataaccess
{
    /// <summary>
    /// {T}&lt;EOMPS&gt;功能表/授權功能{MenuPermSet}
    /// </summary>
    public partial class EoMenuPermSetProvider
    {
        protected override void onSchemaLoaded()
        {
            addTypedCalcHandler()
                .setColumns(AppDataName.EOMPS_MenuItemNoName_XX)
                .setReferences(AppDataName.EOMPS_MenuItemNo, AppDataName.EOMPS_MenuId_XX)
                .setHandler(dt => {
                    var menuIds = dt.Select(x => x.EOMPS_MenuId_XX).Distinct().ToArray();
                    foreach (var menuId in menuIds)
                    {
                        var itemNos = EoDataService.Instance.queryMenuFunctions(menuId, "itemNo", "title")
                            //.Select(x => x.Attributes["itemNo"]).ToArray()
                            .GroupBy(x => x.Attributes["itemNo"])
                            .Select(x => new { no = x.Key, cnt = x.Count() }).ToArray()
                            .Where(x => x.cnt > 1).ToArray()
                            ;

                        var mitems = EoDataService.Instance.queryMenuFunctions(menuId, "itemNo", "title").ToDictionary(x => x.Attributes["itemNo"]);
                        foreach (var row in dt.Where(x => x.EOMPS_MenuId_XX == menuId))
                        {
                            var key = mitems.findKey(row.EOMPS_MenuItemNo);
                            if (key == null)
                                row.EOMPS_MenuItemNoName_XX = row.EOMPS_MenuItemNo;
                            else
                                row.EOMPS_MenuItemNoName_XX = key.Attributes["title"];
                        }
                    }
                });

            base.onSchemaLoaded();
        }
    }
}
