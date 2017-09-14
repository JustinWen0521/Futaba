using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NPOI.HSSF.UserModel;

namespace ftd.helper
{
    public class ExcelHelper
    {
        public static List<string[]> Parse(Stream datas, int assignSheetIdx, int columnCount, bool includeFirstRow = true)
        {
            if (datas == null || datas.Length < 1)
            {
                return null;
            }

            if (assignSheetIdx < 1)
            {
                return null;
            }

            HSSFWorkbook wk = new HSSFWorkbook(datas);
            if (wk == null)
            {
                return null;
            }

            HSSFSheet hst = wk.GetSheetAt(assignSheetIdx);
            if (hst == null)
            {
                return null;
            }

            // 取得最後一筆資料Idx 
            int idx_LastRow = hst.LastRowNum;
            
            // 若未指定欄位數, 以第一行欄位數為主
            if (columnCount < 1)
            {
                columnCount = hst.GetRow(0).LastCellNum;
            }

            List<string[]> return_data = new List<string[]>();
            for (int _idxRow = 0; _idxRow <= idx_LastRow; _idxRow++)
            {
                // 判斷第一行要不要處理
                if (_idxRow == 0 && !includeFirstRow)
                {
                    continue;
                }

                var _row = hst.GetRow(_idxRow);

                string[] row_datas = new string[columnCount];
                for (int _idxCol = 0; _idxCol < columnCount; _idxCol++)
                {
                    // 如果Idx已經超過欄位數
                    if (_idxCol >= _row.LastCellNum)
                    {
                        row_datas[_idxRow] = "";
                        continue;
                    }

                    var cell = _row.GetCell(_idxCol);
                    if (cell == null || "".equalIgnoreCase(cell.ToString().Trim()))
                    {
                        row_datas[_idxRow] = "";
                        continue;
                    }
                    
                    var data = string.Empty;
                    switch (cell.CellType)
                    {
                        case HSSFCell.CELL_TYPE_STRING:
                            data = cell.StringCellValue;
                            break;
                        case HSSFCell.CELL_TYPE_BOOLEAN:
                            data = cell.BooleanCellValue.ToString();
                            break;
                        case HSSFCell.CELL_TYPE_NUMERIC:
                        case HSSFCell.CELL_TYPE_FORMULA:
                            data = cell.NumericCellValue.ToString();
                            break;
                        case HSSFCell.CELL_TYPE_BLANK:
                        default:
                            data = "";
                            break;
                    }
                    row_datas[_idxRow] = data.ToString().Replace("\"", "").Replace("'", "").Trim();
                }
                return_data.Add(row_datas);
            }

            return return_data;
        }
    }
}
