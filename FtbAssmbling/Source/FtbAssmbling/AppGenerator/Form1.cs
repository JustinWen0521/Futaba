using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

namespace ftd
{
    public partial class Form1 : Form
    {
        private class TableDefinition
        {
            public string SystemName { get; set; }
            public string TableName { get; set; }
            public string TableDesc { get; set; }
            public string ColumnPrifix { get; set; }
            public TableDefinitionDataSet.FieldDefinitionDataTable Table { get; set; }
        }

        List<TableDefinition> listTableDef = new List<TableDefinition>();
        //TableDefinitionDataSet _ds = null;
        //TableDefinitionDataSet.FieldDefinitionDataTable _dt = null;
        //string _tableName = "";
        //string _tableDesc = "";
        //string _columnPrefix = "";

        //XSSFWorkbook workbook;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSource.Text = Properties.Settings.Default.SourceFolder;
            txtTarget.Text = Properties.Settings.Default.TargetFolder;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //記錄本次開啟的目錄
                if (txtSource.Text.Trim().Length > 0)
                {
                    Properties.Settings.Default.SourceFolder = txtSource.Text.Trim();
                }
                if (txtTarget.Text.Trim().Length > 0)
                {
                    Properties.Settings.Default.TargetFolder = txtTarget.Text.Trim();
                }
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
            }
        }

        private void initSysList()
        {
            cboSysList.Items.Clear();
            if (listTableDef == null || listTableDef.Count == 0)
                return;

            var sysNames = listTableDef
                .Where(x => x.TableName.IndexOf('_') >= 0)
                .Select(x =>
                    x.TableName.Substring(0, x.TableName.IndexOf('_'))
                )
                .Distinct()
                .ToArray();

            if (sysNames.Length == 0)
                return;

            cboSysList.Items.Add("All");
            foreach (var sys in sysNames)
            {
                cboSysList.Items.Add(sys);
            }
            cboSysList.SelectedIndex = 0;
        }

        private void initTableList()
        {
            cboTableList.Items.Clear();
            if (listTableDef == null || listTableDef.Count == 0)
                return;

            foreach (var table in listTableDef)
            {
                cboTableList.Items.Add(table.TableName);
            }
            cboTableList.SelectedIndex = 0;
        }

        private void openFolder_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null)
                return;

            ////設定Filter，過濾檔案 
            //openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";

            ////設定起始目錄為C:\
            //openFileDialog1.InitialDirectory = Properties.Settings.Default.SourceFolder; //"D:\\VS_Working";

            ////設定起始目錄為程式目錄
            ////openFileDialog1.InitialDirectory = Application.StartupPath;

            ////設定dialog的Title
            //openFileDialog1.Title = "Select a Excel file";

            ////假如使用者按下OK鈕，則將檔案名稱顯示於TextBox1上
            //if (openFileDialog1.ShowDialog() != DialogResult.OK)
            //    return;

            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            //if (txt.Text.Length > 0)
            //    folderBrowserDialog1.SelectedPath = txt.Text;

            var result = folderBrowserDialog1.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK)
                return;

            string folder = folderBrowserDialog1.SelectedPath;
            if (btn.Name == btnSource.Name)
            {
                txtSource.Text = folder;
                Properties.Settings.Default.SourceFolder = folder;
                Properties.Settings.Default.Save();

                loadFiles();
            }
            else if (btn.Name == btnTarget.Name)
            {
                txtTarget.Text = folder;
                Properties.Settings.Default.TargetFolder = folder;
                Properties.Settings.Default.Save();
            }
        }

        private void loadFiles()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                //Get Files
                DirectoryInfo dir = new DirectoryInfo(txtSource.Text);
                FileInfo[] files = dir.GetFiles("*.xlsx", SearchOption.TopDirectoryOnly);

                //檔案名稱需符合規範(TableName)
                FileInfo[] approvedFiles = files.Where(x => x.Name.IndexOf('_') >= 0).ToArray();

                //Load Files
                listTableDef.Clear();
                foreach (var fi in approvedFiles)
                {
                    var tableDef = convertToDataTable(fi.FullName);
                    listTableDef.Add(tableDef);
                }

                //系統清單
                initSysList();

                //資料表清單
                initTableList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("讀取檔案發錯誤\r\n{0}", ex.ToString()));
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnGenDataModel_Click(object sender, EventArgs e)
        {
            //結束DataGrid編輯狀態
            dgv.EndEdit();

            if (listTableDef == null || listTableDef.Count == 0)
            {
                MessageBox.Show("請先載入資料定義檔");
                return;
            }

            if (chkGenAll.Checked)
            {
                if (cboSysList.Text.Length == 0)
                {
                    MessageBox.Show("請選擇系統");
                    return;
                }
                renderCodeAll();
            }
            else
            {
                var tableDef = listTableDef.Where(x => x.TableName == cboTableList.Text).FirstOrDefault();
                if (tableDef == null)
                {
                    MessageBox.Show("請選擇資料表");
                    return;
                }
                txtResult.Text = renderCodeOne(tableDef);
                tabControl1.SelectedIndex = 1;
            }
        }

        private TableDefinition convertToDataTable(string fileName)
        {
            XSSFWorkbook workbook;
            using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(file);
            }

            ISheet sheet = workbook.GetSheetAt(0);
            ICell cellKey;
            ICell cellValue;
            ICell cell;
            List<string> columns = new List<string>();

            var tableDef = new TableDefinition();
            var dt = new TableDefinitionDataSet.FieldDefinitionDataTable();

            IEnumerator rows = sheet.GetRowEnumerator();

            while (rows.MoveNext())
            {
                IRow row = (XSSFRow)rows.Current;
                cellKey = row.GetCell(1);
                if (cellKey.ToString().Equals("Table Name", StringComparison.OrdinalIgnoreCase))
                {
                    cellValue = row.GetCell(2);
                    tableDef.TableName = cellValue.ToString();
                    tableDef.SystemName = tableDef.TableName.Substring(0, tableDef.TableName.IndexOf('_'));
                    continue;
                }
                else if (cellKey.ToString().Equals("Table Description", StringComparison.OrdinalIgnoreCase))
                {
                    cellValue = row.GetCell(2);
                    tableDef.TableDesc = cellValue.ToString();
                    continue;
                }
                else if (cellKey.ToString().Equals("Column Prefix", StringComparison.OrdinalIgnoreCase))
                {
                    cellValue = row.GetCell(2);
                    tableDef.ColumnPrifix = cellValue.ToString();
                    continue;
                }
                else if (cellKey.ToString().Equals("ShortName", StringComparison.OrdinalIgnoreCase))
                {
                    //欄位標題
                    for (int i = 1; i < row.LastCellNum; i++)
                    {
                        cell = row.GetCell(i);
                        columns.Add(cell.ToString());
                    }
                    continue;
                }
                else if (cellKey.ToString() == "")
                {
                    continue;
                }

                var dr = dt.NewFieldDefinitionRow();

                for (int i = 0; i < columns.Count; i++)
                {
                    if (!dt.Columns.Contains(columns[i]))
                        continue;

                    cell = row.GetCell(i + 1);
                    if (cell == null)
                    {
                        dr[columns[i]] = DBNull.Value;
                    }
                    else
                    {
                        cell.SetCellType(CellType.String);
                        dr[columns[i]] = cell.StringCellValue;
                        //dr[columns[i]] = cell.ToString();
                    }
                }
                dt.AddFieldDefinitionRow(dr);
            }
            dt.AcceptChanges();
            tableDef.Table = dt;
            return tableDef;
        }

        private void renderCodeAll()
        {
            string[] sysNames = null;
            TableDefinition[] tables = null;
            if (cboSysList.Text.equalIgnoreCase("All"))
            {
                sysNames = listTableDef.Select(x => x.SystemName).Distinct().ToArray();
            }
            else
            {
                sysNames = new[] { cboSysList.Text };
            }

            foreach (var sys in sysNames)
            {
                StringBuilder sb = new StringBuilder();
                tables = listTableDef.Where(x => x.SystemName == sys).ToArray();

                #region //Header
                sb.AppendLine("using System;");
                sb.AppendLine("using System.Collections.Generic;");
                sb.AppendLine("using System.Text;");
                sb.AppendLine("using ftd.data.model.tag;");
                sb.AppendLine("using ftd.data.model.datatype;");
                sb.AppendLine("using ftd.data;");
                sb.AppendLine("using ftd.nsql;");
                sb.AppendLine();
                sb.AppendLine("namespace ftd.data");
                sb.AppendLine("{");
                sb.AppendLine("    /// <summary>");
                sb.AppendLine("    /// 資料名稱");
                sb.AppendLine("    /// </summary>");
                sb.AppendLine("    public partial class AppDataName : FdmDataName");
                sb.AppendLine("    {");
                sb.AppendLine("        /// <summary>");
                sb.AppendFormat("        /// {0}\r\n", sys);
                sb.AppendLine("        /// </summary>        ");
                sb.AppendFormat("        [FdmSystemDef(\"{0}_\")]\r\n", sys);
                sb.AppendFormat("        public const string {0} = \"{0}\";\r\n", sys);
                sb.AppendLine();
                #endregion

                foreach (var table in tables)
                {
                    sb.Append(renderCodeOne(table));
                }
                sb.AppendLine("    }");
                sb.AppendLine("}");

                txtResult.Text = sb.ToString();
                tabControl1.SelectedIndex = 1;

                //Write to file
                string fileName = Path.Combine(txtTarget.Text, string.Format("AppDataName_{0}.cs", sys));
                var sw = null as StreamWriter;
                try
                {
                    var fs = File.Create(fileName, 1024, FileOptions.SequentialScan | FileOptions.WriteThrough);
                    sw = new StreamWriter(new BufferedStream(fs, 64000), Encoding.UTF8);
                    sw.Write(sb.ToString());
                    //sw.Close();
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }
            }
        }

        private string renderCodeOne(TableDefinition tableDef)
        {
            StringBuilder sb = new StringBuilder();
            var tableName = tableDef.TableName;
            var tableDesc = tableDef.TableDesc;
            var columnPrefix = tableDef.ColumnPrifix;
            var dt = tableDef.Table;

            var primaryKey = dt.Where(x => x.KeyType.equalIgnoreCase("PK")).FirstOrDefault();
            var idx = tableName.IndexOf('_');
            string tableClassName = tableName.Substring(0, idx - 1) + tableName[idx - 1].ToString().ToLower() + tableName.Substring(idx + 1);

            #region //資料表定義
            sb.AppendFormat("        #region [{0}]\r\n", tableName);
            sb.AppendLine();
            sb.AppendFormat("        /// <summary>\r\n");
            sb.AppendFormat("        /// {{T}}{0} {{{1}}}\r\n", tableDesc, tableName);
            sb.AppendFormat("        /// </summary>\r\n");
            sb.AppendFormat("        [FdmTableDef(\"{0}\", {1},\r\n", columnPrefix, (primaryKey == null ? "" : "AppDataName." + columnPrefix + primaryKey.ShortName));
            sb.AppendFormat("              RowInsertUserName = AppDataName.{0}CreatorId,\r\n", columnPrefix);
            sb.AppendFormat("              RowInsertDateName = AppDataName.{0}CreateDate,\r\n", columnPrefix);
            sb.AppendFormat("              RowModifyUserName = AppDataName.{0}UpdaterId,\r\n", columnPrefix);
            sb.AppendFormat("              RowModifyDateName = AppDataName.{0}UpdateDate,\r\n", columnPrefix);
            //sb.AppendFormat("              RowUpdateUserName = AppDataName.{0}UpdaterId,\r\n", columnPrefix);
            //sb.AppendFormat("              RowUpdateDateName = AppDataName.{0}UpdateDate,\r\n", columnPrefix);
            sb.AppendFormat("              IsSessionEnable = false)]\r\n");
            sb.AppendFormat("        [FdmTableProvider(\"ftd.dataaccess.{0}Provider, AppService\")]\r\n", tableClassName);
            sb.AppendFormat("        [FdmCodeGen(Title = \"{0}\")]\r\n", tableDesc);
            sb.AppendFormat("        public const string {0} = \"{0}\";\r\n", tableName);
            sb.AppendLine();
            #endregion

            //欄位定義
            foreach (var row in dt)
            {
                sb.AppendFormat("        /// <summary>\r\n");
                sb.AppendFormat("        /// *{0} {1}：【{2}】\r\n", row.DisplayName, getDataLengthDesc(row), row.Example);
                sb.AppendFormat("        /// </summary>\r\n");

                #region //資料型態
                if (row.DataType.StartsWith("DTN_", StringComparison.OrdinalIgnoreCase))
                {
                    sb.AppendFormat("        [FdmStyleType({0})]\r\n", row.DataType);
                }
                else if (row.DataType.equalIgnoreCase("FdmDecimalType"))
                {
                    sb.AppendFormat("        [FdmDecimalType({0}, {1})]\r\n", row.Precision, row.Scale);
                }
                else if (row.DataType.equalIgnoreCase("FdmVarcharType") || row.DataType.equalIgnoreCase("FdmNVarcharType"))
                {
                    sb.AppendFormat("        [{0}({1})]\r\n", row.DataType, row.DataLength);
                }
                #endregion

                #region //CodeGenAttribute
                string codeGenAttribute = getCodeGenAttribute(row);
                sb.AppendFormat("        {0}\r\n", codeGenAttribute);
                #endregion

                #region //延伸欄位
                if (row.ColumnType.equalIgnoreCase("FdmLink"))
                {
                    sb.AppendFormat("        [FdmLink(AppDataName.{0}{1}, AppDataName.{2})]\r\n", columnPrefix, row.ReferenceKey, row.ReferenceField);
                }
                else if (row.ColumnType.equalIgnoreCase("FdmCodeName"))
                {
                    sb.AppendFormat("        [FdmCodeName(\"{0}\", AppDataName.{1}{2})]\r\n", row.ReferenceField, columnPrefix, row.ReferenceKey);
                }
                else if (row.ColumnType.equalIgnoreCase("FdmCalculate"))
                {
                    sb.AppendFormat("        [FdmCalculate]\r\n");
                }
                #endregion

                //欄位名稱
                sb.AppendFormat("        public const string {0}{1} = \"{0}{1}\";\r\n", columnPrefix, row.ShortName);
                sb.AppendLine();
            }

            #region //產生追蹤欄位
            if (chkGenTraceField.Checked)
            {
                var row2 = dt.Where(x => x.ShortName.equalIgnoreCase("CreatorId")).FirstOrDefault();
                if (row2 == null)
                {
                    sb.AppendFormat("        /// <summary>\r\n");
                    sb.AppendFormat("        /// *建立者ID(DTN_NID)：【】\r\n");
                    sb.AppendFormat("        /// </summary>\r\n");
                    sb.AppendFormat("        [FdmStyleType(DTN_NID)]\r\n");
                    sb.AppendFormat("        [FdmCodeGen(Title = \"建立者ID\", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsVisible = false)]\r\n");
                    sb.AppendFormat("        public const string {0}CreatorId = \"{0}CreatorId\";\r\n", columnPrefix);
                    sb.AppendFormat("");
                }

                row2 = dt.Where(x => x.ShortName.equalIgnoreCase("CreatorName_XX")).FirstOrDefault();
                if (row2 == null)
                {
                    sb.AppendFormat("        /// <summary>\r\n");
                    sb.AppendFormat("        /// *建立者姓名(20)：【】\r\n");
                    sb.AppendFormat("        /// </summary>\r\n");
                    sb.AppendFormat("        [FdmStyleType(DTN_NVARCHAR20)]\r\n");
                    sb.AppendFormat("        [FdmLink(AppDataName.{0}CreatorId, AppDataName.EOE_EmployeeName)]\r\n", columnPrefix);
                    sb.AppendFormat("        [FdmCodeGen(Title = \"建立者姓名\", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsVisible = false)]\r\n");
                    sb.AppendFormat("        public const string {0}CreatorName_XX = \"{0}CreatorName_XX\";\r\n", columnPrefix);
                    sb.AppendFormat("");
                }

                row2 = dt.Where(x => x.ShortName.equalIgnoreCase("CreateDate")).FirstOrDefault();
                if (row2 == null)
                {
                    sb.AppendFormat("        /// <summary>\r\n");
                    sb.AppendFormat("        /// *建立日期(DateTime19)：【】\r\n");
                    sb.AppendFormat("        /// </summary>\r\n");
                    sb.AppendFormat("        [FdmStyleType(DTN_DATETIME_19)]\r\n");
                    sb.AppendFormat("        [FdmCodeGen(Title = \"建立日期\", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsVisible = false)]\r\n");
                    sb.AppendFormat("        public const string {0}CreateDate = \"{0}CreateDate\";\r\n", columnPrefix);
                    sb.AppendFormat("");
                }

                row2 = dt.Where(x => x.ShortName.equalIgnoreCase("UpdaterId")).FirstOrDefault();
                if (row2 == null)
                {
                    sb.AppendFormat("        /// <summary>\r\n");
                    sb.AppendFormat("        /// *異動者ID(DTN_NID)：【】\r\n");
                    sb.AppendFormat("        /// </summary>\r\n");
                    sb.AppendFormat("        [FdmStyleType(DTN_NID)]\r\n");
                    sb.AppendFormat("        [FdmCodeGen(Title = \"異動者ID\", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsVisible = false)]\r\n");
                    sb.AppendFormat("        public const string {0}UpdaterId = \"{0}UpdaterId\";\r\n", columnPrefix);
                    sb.AppendFormat("");
                }

                row2 = dt.Where(x => x.ShortName.equalIgnoreCase("UpdaterName_XX")).FirstOrDefault();
                if (row2 == null)
                {
                    sb.AppendFormat("        /// <summary>");
                    sb.AppendFormat("        /// *異動者姓名{UpdaterName_XX}：【】\r\n");
                    sb.AppendFormat("        /// </summary>\r\n");
                    sb.AppendFormat("        [FdmStyleType(DTN_NVARCHAR20)]\r\n");
                    sb.AppendFormat("        [FdmLink(AppDataName.{0}UpdaterId, AppDataName.EOE_EmployeeName)]\r\n", columnPrefix);
                    sb.AppendFormat("        [FdmCodeGen(Title = \"異動者姓名\", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsVisible = false)]\r\n");
                    sb.AppendFormat("        public const string {0}UpdaterName_XX = \"{0}UpdaterName_XX\";\r\n", columnPrefix);
                    sb.AppendFormat("");
                }

                row2 = dt.Where(x => x.ShortName.equalIgnoreCase("UpdateDate")).FirstOrDefault();
                if (row2 == null)
                {
                    sb.AppendFormat("        /// <summary>");
                    sb.AppendFormat("        /// *異動日期{UpdateDate}：【】\r\n");
                    sb.AppendFormat("        /// </summary>\r\n");
                    sb.AppendFormat("        [FdmStyleType(DTN_DATETIME_19)]\r\n");
                    sb.AppendFormat("        [FdmCodeGen(Title = \"異動日期\", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsVisible = false)]\r\n");
                    sb.AppendFormat("        public const string {0}UpdateDate = \"{0}UpdateDate\";\r\n", columnPrefix);
                    sb.AppendFormat("");
                }
            }
            #endregion

            sb.AppendLine("        #endregion");
            sb.AppendLine();
            return sb.ToString();
        }

        private string getCodeGenAttribute(TableDefinitionDataSet.FieldDefinitionRow row)
        {
            string format = "[FdmCodeGen(" 
                + "Title = \"{0}\", "
                + "IsRequired = {1}, " 
                + "IsUnique = {2}, " 
                + "IsSearch = {3}, " 
                + "IsSearchRange = {4}, " 
                + "IsListVisible = {5}, "
                + "IsCreateVisible = {6}, "
                + "IsEditVisible = {7}"
                + ")]";

            string codeGenAttr = string.Format(format
                , row.DisplayName
                , row.IsRequired == "Y" ? "true" : "false"
                , row.KeyType.equalIgnoreCase("UK") ? "true" : "false"
                , row.IsSearch == "Y" ? "true" : "false"
                , row.IsSearchRange == "Y" ? "true" : "false"
                , row.IsListVisible == "N" ? "false" : "true"
                , row.IsCreateVisible == "N" ? "false" : "true"
                , row.IsEditVisible == "N" ? "false" : "true"
                );
            return codeGenAttr;
        }

        private string getDataLengthDesc(TableDefinitionDataSet.FieldDefinitionRow row)
        {
            if (row.DataType.StartsWith("DTN_", StringComparison.OrdinalIgnoreCase))
                return string.Format("{{{0}}}", row.DataType);

            switch (row.DataType)
            {
                //case "DTN_ID":
                //case "DTN_NID":
                //    return "15";
                //case "DTN_DECIMAL":
                //    return "18";
                //case "DTN_INTEGER":
                //    return "INTEGER";
                //case "DTN_DOUBLE":
                //    return "DOUBLE";
                //case "DTN_BOOL_TF":
                //case "DTN_NBOOL_TF":
                //    return "1";
                //case "DTN_DATETIME_19":
                //    return "DateTime19";
                //case "DTN_DATETIME_10":
                //    return "DateTime10";
                //case "DTN_DATE_8":
                //    return "DateTime8";
                //case "DTN_DATETIME_16":
                //    return "DateTime16";
                //case "DTN_NVARCHAR1":
                //case "DTN_VARCHAR1":
                //    return "1";
                //case "DTN_NVARCHAR10":
                //case "DTN_VARCHAR10":
                //    return "10";
                //case "DTN_NVARCHAR20":
                //case "DTN_VARCHAR20":
                //    return "20";
                //case "DTN_NVARCHAR50":
                //case "DTN_VARCHAR50":
                //    return "50";
                //case "DTN_NVARCHAR100":
                //case "DTN_VARCHAR100":
                //    return "100";
                //case "DTN_NVARCHAR200":
                //case "DTN_VARCHAR200":
                //    return "200";
                //case "DTN_NVARCHAR500":
                //case "DTN_VARCHAR500":
                //    return "500";
                //case "DTN_NVARCHAR1000":
                //case "DTN_VARCHAR1000":
                //    return "1000";
                //case "DTN_NVARCHAR4000":
                //case "DTN_VARCHAR4000":
                //    return "4000";
                //case "DTN_TEXT":
                //    return "TEXT";
                //case "DTN_NTEXT":
                //    return "NTEXT";
                //case "DTN_EMAIL":
                //    return "EMAIL";
                //case "DTN_NEMAIL":
                //    return "NEMAIL";
                case "FdmDecimalType":
                    return string.Format("{{Decimal({0},{1})}}", row.Precision, row.Scale);
                case "FdmVarcharType":
                    return string.Format("{{Varchar({0})}}", row.DataLength);
                case "FdmNVarcharType":
                    return string.Format("{{NVarchar({0})}}", row.DataLength);
                default:
                    return "";
            }
        }

        private void cboTableList_SelectedValueChanged(object sender, EventArgs e)
        {
            dgv.DataSource = null;

            var dt = listTableDef.Where(x => x.TableName == cboTableList.Text).FirstOrDefault();
            if (dt == null)
                return;

            dgv.DataSource = dt.Table;
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            tabControl1.SelectedIndex = 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadFiles();
        }
    }
}
