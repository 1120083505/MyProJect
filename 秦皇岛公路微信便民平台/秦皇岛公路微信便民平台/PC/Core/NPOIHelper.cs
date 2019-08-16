using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using StarTech.NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace StarTech.NPOI
{
    /// <summary>
    /// Excel生成操作类
    /// </summary>
    public class NPOIHelper
    {
        /// <summary>
        /// 导出列名
        /// </summary>
        public static System.Collections.SortedList ListColumnsName;
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param>
        public static void ExportExcel(DataTable dtSource, string filePath)
        {
            if (ListColumnsName == null || ListColumnsName.Count == 0)
                throw (new Exception("请对ListColumnsName设置要导出的列名！"));

            HSSFWorkbook excelWorkbook = CreateExcelFile();
            InsertRow(dtSource, excelWorkbook);
            SaveExcelFile(excelWorkbook, filePath);
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param>
        public static void ExportExcel(DataTable dtSource, Stream excelStream)
        {
            if (ListColumnsName == null || ListColumnsName.Count == 0)
                throw (new Exception("请对ListColumnsName设置要导出的列名！"));

            HSSFWorkbook excelWorkbook = CreateExcelFile();
            InsertRow(dtSource, excelWorkbook);
            SaveExcelFile(excelWorkbook, excelStream);
        }
        /// <summary>
        /// 保存Excel文件
        /// </summary>
        /// <param name="excelWorkBook"></param>
        /// <param name="filePath"></param>
        protected static void SaveExcelFile(HSSFWorkbook excelWorkBook, string filePath)
        {
            FileStream file = null;
            try
            {
                file = new FileStream(filePath, FileMode.Create);
                excelWorkBook.Write(file);
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }
        /// <summary>
        /// 保存Excel文件
        /// </summary>
        /// <param name="excelWorkBook"></param>
        /// <param name="filePath"></param>
        protected static void SaveExcelFile(HSSFWorkbook excelWorkBook, Stream excelStream)
        {
            try
            {
                excelWorkBook.Write(excelStream);
            }
            finally
            {

            }
        }
        /// <summary>
        /// 创建Excel文件
        /// </summary>
        /// <param name="filePath"></param>
        protected static HSSFWorkbook CreateExcelFile()
        {
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            return hssfworkbook;
        }
        /// <summary>
        /// 创建excel表头
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="excelSheet"></param>
        protected static void CreateHeader(ISheet excelSheet)
        {
            int cellIndex = 0;
            //循环导出列
            IRow newRow = excelSheet.CreateRow(0);
            foreach (System.Collections.DictionaryEntry de in ListColumnsName)
            {
                ICell newCell = newRow.CreateCell(cellIndex);
                newCell.SetCellValue(de.Value.ToString());
                cellIndex++;
            }
        }
        /// <summary>
        /// 插入数据行
        /// </summary>
        protected static void InsertRow(DataTable dtSource, HSSFWorkbook excelWorkbook)
        {
            int rowCount = 0;
            int sheetCount = 1;
            ISheet newsheet = null;

            //循环数据源导出数据集
            newsheet = excelWorkbook.CreateSheet("Sheet" + sheetCount);
            CreateHeader(newsheet);
            foreach (DataRow dr in dtSource.Rows)
            {
                rowCount++;
                //超出10000条数据 创建新的工作簿
                if (rowCount == 10000)
                {
                    rowCount = 1;
                    sheetCount++;
                    newsheet = excelWorkbook.CreateSheet("Sheet" + sheetCount);
                    CreateHeader(newsheet);
                }

                IRow newRow = newsheet.CreateRow(rowCount);
                InsertCell(dtSource, dr, newRow, newsheet, excelWorkbook);
            }
        }
        /// <summary>
        /// 导出数据行
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="drSource"></param>
        /// <param name="currentExcelRow"></param>
        /// <param name="excelSheet"></param>
        /// <param name="excelWorkBook"></param>
        protected static void InsertCell(DataTable dtSource, DataRow drSource, IRow currentExcelRow, ISheet excelSheet, HSSFWorkbook excelWorkBook)
        {
            for (int cellIndex = 0; cellIndex < ListColumnsName.Count; cellIndex++)
            {
                //列名称
                string columnsName = ListColumnsName.GetKey(cellIndex).ToString();
                ICell newCell = null;
                System.Type rowType = drSource[columnsName].GetType();
                string drValue = drSource[columnsName].ToString().Trim();
                switch (rowType.ToString())
                {
                    case "System.String"://字符串类型
                        drValue = drValue.Replace("&", "&");
                        drValue = drValue.Replace(">", ">");
                        drValue = drValue.Replace("<", "<");
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(drValue);
                        break;
                    case "System.DateTime"://日期类型
                        DateTime dateV;
                        DateTime.TryParse(drValue, out dateV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(dateV.ToString());

                        //格式化显示
                        //ICellStyle cellStyle = excelWorkBook.CreateCellStyle();
                        //IDataFormat format = excelWorkBook.CreateDataFormat();
                        //cellStyle.DataFormat = format.GetFormat("yyyy-mm-dd hh:mm:ss");
                        //newCell.CellStyle = cellStyle;

                        break;
                    case "System.Boolean"://布尔型
                        bool boolV = false;
                        bool.TryParse(drValue, out boolV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(boolV);
                        break;
                    case "System.Int16"://整型
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Byte":
                        int intV = 0;
                        int.TryParse(drValue, out intV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(intV.ToString());
                        break;
                    case "System.Decimal"://浮点型
                    case "System.Double":
                        double doubV = 0;
                        double.TryParse(drValue, out doubV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(doubV);
                        break;
                    case "System.DBNull"://空值处理
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue("");
                        break;
                    default:
                        throw (new Exception(rowType.ToString() + "：类型数据无法处理!"));
                }

            }
        }

        /**************Excel导入*****************/

        /// 由Excel导入DataTable
        /// </summary>
        /// <param name="excelFileStream">Excel文件流</param>
        /// <param name="sheetName">Excel工作表名称</param>
        /// <param name="headerRowIndex">Excel表头行索引</param>
        /// <returns>DataTable</returns>
        public static DataTable ImportDataTableFromExcel(Stream excelFileStream, string sheetName, int headerRowIndex)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(excelFileStream);
            ISheet sheet = workbook.GetSheet(sheetName);

            DataTable table = new DataTable();

            IRow headerRow = sheet.GetRow(headerRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                    dataRow[j] = row.GetCell(j).ToString();
            }

            excelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        /// <summary>
        /// 由Excel导入DataTable
        /// </summary>
        /// <param name="excelFilePath">Excel文件路径，为物理路径。</param>
        /// <param name="sheetName">Excel工作表名称</param>
        /// <param name="headerRowIndex">Excel表头行索引</param>
        /// <returns>DataTable</returns>
        public static DataTable ImportDataTableFromExcel(string excelFilePath, string sheetName, int headerRowIndex)
        {
            using (FileStream stream = System.IO.File.OpenRead(excelFilePath))
            {
                return ImportDataTableFromExcel(stream, sheetName, headerRowIndex);
            }
        }

        /// <summary>
        /// 由Excel导入DataTable
        /// </summary>
        /// <param name="excelFileStream">Excel文件流</param>
        /// <param name="sheetName">Excel工作表索引</param>
        /// <param name="headerRowIndex">Excel表头行索引</param>
        /// <returns>DataTable</returns>
        public static DataTable ImportDataTableFromExcel(Stream excelFileStream, int sheetIndex, int headerRowIndex)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(excelFileStream);
            ISheet sheet = workbook.GetSheetAt(sheetIndex);

            DataTable table = new DataTable();

            IRow headerRow = sheet.GetRow(headerRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {

                //row.getCell(i).setCellType(CELL_TYPE_NUMERIC); 
                if (headerRow.GetCell(i) == null || headerRow.GetCell(i).StringCellValue.Trim() == "")
                {
                    // 如果遇到第一个空列，则不再继续向后读取
                    cellCount = i + 1;
                    break;
                }
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            for (int i = (sheet.FirstRowNum + 1 + headerRowIndex); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row == null || row.GetCell(0) == null || row.GetCell(0).ToString().Trim() == "")
                {
                    // 如果遇到第一个空行，则不再继续向后读取
                    break;
                }

                DataRow dataRow = table.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    try
                    {
                        row.GetCell(j).SetCellType(CellType.STRING);
                        ICell cel = row.GetCell(j);
                        dataRow[j] = cel.Row.Cells[j];
                    }
                    catch
                    {
                        //针对wps改进。try--catch  遇到wps的excel空值的时候，直接设置为null
                        dataRow[j] = null;
                    }
                }
                table.Rows.Add(dataRow);
            }
            excelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }
        /// <summary>
        /// 由Excel导入DataTable
        /// </summary>
        /// <param name="excelFilePath">Excel文件路径，为物理路径。</param>
        /// <param name="sheetName">Excel工作表索引</param>
        /// <param name="headerRowIndex">Excel表头行索引</param>
        /// <returns>DataTable</returns>
        public static DataTable ImportDataTableFromExcel(string excelFilePath, int sheetIndex, int headerRowIndex)
        {
            using (FileStream stream = System.IO.File.OpenRead(excelFilePath))
            {
                return ImportDataTableFromExcel(stream, sheetIndex, headerRowIndex);
            }
        }
        public static MemoryStream ExportToExcel(DataSet ds, string header)
        {
            IWorkbook workbook = null;

            workbook = new HSSFWorkbook();//2003


            #region 开始循环DS中的Table,DS中的每个表创建一个Sheet
            for (int p = 0; p < ds.Tables.Count; p++)
            {
                #region 创建一个sheet
                ISheet sheet = workbook.CreateSheet(ds.Tables[p].TableName);
                //设置大标题行   
                int rowCount = 0;


                //设置全局列宽和行高   
                sheet.DefaultColumnWidth = 14; //全局列宽   
                sheet.DefaultRowHeightInPoints = 15; //全局行高   
                //设置标题行数据   
                int a = 0;


                IRow row1 = sheet.CreateRow(rowCount); //创建报表表头标题列   
                string[] columnHeaders = header.Split(new char[] { ',' });//按逗号拆分标题
                // var style = SetCellBorder(workbook);

                for (int k = 0; k < columnHeaders.Length; k++)
                {  //将传递过来的字符串表头进行拆分到Excel

                    string columnName = columnHeaders[k];
                    ICell cell = row1.CreateCell(a);
                    cell.SetCellValue(columnName);

                    #region 设置单元格的边框
                    // cell.CellStyle = style;
                    #endregion
                    a++;
                }

                //填写ds数据进excel   
                for (int i = 0; i < ds.Tables[p].Rows.Count; i++) //写行数据   
                {
                    IRow row2 = sheet.CreateRow(i + rowCount + 1);
                    int b = 0;
                    for (int j = 0; j < ds.Tables[p].Columns.Count; j++)
                    {
                        string dgvValue = string.Empty;
                        dgvValue = ds.Tables[p].Rows[i][j].ToString();
                        ICell cell = row2.CreateCell(b);
                        cell.SetCellValue(dgvValue);

                        #region 设置单元格的边框
                        //cell.CellStyle = style;
                        #endregion
                        b++;
                    }
                }

                #endregion
            }
            #endregion

            //创建excel   
            MemoryStream memoryStream = new MemoryStream();
            workbook.Write(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }
        /// <summary>
        /// 导出多个sheet
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static MemoryStream ExportToExcelByDataSet(DataSet ds)
        {
            IWorkbook workbook = null;

            workbook = new HSSFWorkbook();//2003


            #region 开始循环DS中的Table,DS中的每个表创建一个Sheet
            for (int p = 0; p < ds.Tables.Count; p++)
            {
                #region 创建一个sheet
                ISheet sheet = workbook.CreateSheet(ds.Tables[p].TableName);
                //设置大标题行   
                int rowCount = 0;


                //设置全局列宽和行高   
                sheet.DefaultColumnWidth = 14; //全局列宽   
                sheet.DefaultRowHeightInPoints = 15; //全局行高   
                //设置标题行数据   
                int a = 0;


                IRow row1 = sheet.CreateRow(rowCount); //创建报表表头标题列   
                // var style = SetCellBorder(workbook);

                for (int k = 0; k < ds.Tables[p].Columns.Count; k++)
                {  //将传递过来的字符串表头进行拆分到Excel

                    string columnName = ds.Tables[p].Columns[k].ColumnName;
                    ICell cell = row1.CreateCell(a);
                    cell.SetCellValue(columnName);

                    #region 设置单元格的边框
                    // cell.CellStyle = style;
                    #endregion
                    a++;
                }

                //填写ds数据进excel   
                for (int i = 0; i < ds.Tables[p].Rows.Count; i++) //写行数据   
                {
                    IRow row2 = sheet.CreateRow(i + rowCount + 1);
                    int b = 0;
                    for (int j = 0; j < ds.Tables[p].Columns.Count; j++)
                    {
                        string dgvValue = string.Empty;
                        dgvValue = ds.Tables[p].Rows[i][j].ToString();
                        ICell cell = row2.CreateCell(b);
                        cell.SetCellValue(dgvValue);

                        #region 设置单元格的边框
                        //cell.CellStyle = style;
                        #endregion
                        b++;
                    }
                }

                #endregion
            }
            #endregion

            //创建excel   
            MemoryStream memoryStream = new MemoryStream();
            workbook.Write(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }

    }
    //排序实现接口 不进行排序 根据添加顺序导出
    public class NoSort : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            return -1;
        }
    }


}
