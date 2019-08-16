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
    /// Excel���ɲ�����
    /// </summary>
    public class NPOIHelper
    {
        /// <summary>
        /// ��������
        /// </summary>
        public static System.Collections.SortedList ListColumnsName;
        /// <summary>
        /// ����Excel
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param>
        public static void ExportExcel(DataTable dtSource, string filePath)
        {
            if (ListColumnsName == null || ListColumnsName.Count == 0)
                throw (new Exception("���ListColumnsName����Ҫ������������"));

            HSSFWorkbook excelWorkbook = CreateExcelFile();
            InsertRow(dtSource, excelWorkbook);
            SaveExcelFile(excelWorkbook, filePath);
        }
        /// <summary>
        /// ����Excel
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param>
        public static void ExportExcel(DataTable dtSource, Stream excelStream)
        {
            if (ListColumnsName == null || ListColumnsName.Count == 0)
                throw (new Exception("���ListColumnsName����Ҫ������������"));

            HSSFWorkbook excelWorkbook = CreateExcelFile();
            InsertRow(dtSource, excelWorkbook);
            SaveExcelFile(excelWorkbook, excelStream);
        }
        /// <summary>
        /// ����Excel�ļ�
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
        /// ����Excel�ļ�
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
        /// ����Excel�ļ�
        /// </summary>
        /// <param name="filePath"></param>
        protected static HSSFWorkbook CreateExcelFile()
        {
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            return hssfworkbook;
        }
        /// <summary>
        /// ����excel��ͷ
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="excelSheet"></param>
        protected static void CreateHeader(ISheet excelSheet)
        {
            int cellIndex = 0;
            //ѭ��������
            IRow newRow = excelSheet.CreateRow(0);
            foreach (System.Collections.DictionaryEntry de in ListColumnsName)
            {
                ICell newCell = newRow.CreateCell(cellIndex);
                newCell.SetCellValue(de.Value.ToString());
                cellIndex++;
            }
        }
        /// <summary>
        /// ����������
        /// </summary>
        protected static void InsertRow(DataTable dtSource, HSSFWorkbook excelWorkbook)
        {
            int rowCount = 0;
            int sheetCount = 1;
            ISheet newsheet = null;

            //ѭ������Դ�������ݼ�
            newsheet = excelWorkbook.CreateSheet("Sheet" + sheetCount);
            CreateHeader(newsheet);
            foreach (DataRow dr in dtSource.Rows)
            {
                rowCount++;
                //����10000������ �����µĹ�����
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
        /// ����������
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
                //������
                string columnsName = ListColumnsName.GetKey(cellIndex).ToString();
                ICell newCell = null;
                System.Type rowType = drSource[columnsName].GetType();
                string drValue = drSource[columnsName].ToString().Trim();
                switch (rowType.ToString())
                {
                    case "System.String"://�ַ�������
                        drValue = drValue.Replace("&", "&");
                        drValue = drValue.Replace(">", ">");
                        drValue = drValue.Replace("<", "<");
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(drValue);
                        break;
                    case "System.DateTime"://��������
                        DateTime dateV;
                        DateTime.TryParse(drValue, out dateV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(dateV.ToString());

                        //��ʽ����ʾ
                        //ICellStyle cellStyle = excelWorkBook.CreateCellStyle();
                        //IDataFormat format = excelWorkBook.CreateDataFormat();
                        //cellStyle.DataFormat = format.GetFormat("yyyy-mm-dd hh:mm:ss");
                        //newCell.CellStyle = cellStyle;

                        break;
                    case "System.Boolean"://������
                        bool boolV = false;
                        bool.TryParse(drValue, out boolV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(boolV);
                        break;
                    case "System.Int16"://����
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Byte":
                        int intV = 0;
                        int.TryParse(drValue, out intV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(intV.ToString());
                        break;
                    case "System.Decimal"://������
                    case "System.Double":
                        double doubV = 0;
                        double.TryParse(drValue, out doubV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(doubV);
                        break;
                    case "System.DBNull"://��ֵ����
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue("");
                        break;
                    default:
                        throw (new Exception(rowType.ToString() + "�����������޷�����!"));
                }

            }
        }

        /**************Excel����*****************/

        /// ��Excel����DataTable
        /// </summary>
        /// <param name="excelFileStream">Excel�ļ���</param>
        /// <param name="sheetName">Excel����������</param>
        /// <param name="headerRowIndex">Excel��ͷ������</param>
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
        /// ��Excel����DataTable
        /// </summary>
        /// <param name="excelFilePath">Excel�ļ�·����Ϊ����·����</param>
        /// <param name="sheetName">Excel����������</param>
        /// <param name="headerRowIndex">Excel��ͷ������</param>
        /// <returns>DataTable</returns>
        public static DataTable ImportDataTableFromExcel(string excelFilePath, string sheetName, int headerRowIndex)
        {
            using (FileStream stream = System.IO.File.OpenRead(excelFilePath))
            {
                return ImportDataTableFromExcel(stream, sheetName, headerRowIndex);
            }
        }

        /// <summary>
        /// ��Excel����DataTable
        /// </summary>
        /// <param name="excelFileStream">Excel�ļ���</param>
        /// <param name="sheetName">Excel����������</param>
        /// <param name="headerRowIndex">Excel��ͷ������</param>
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
                    // ���������һ�����У����ټ�������ȡ
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
                    // ���������һ�����У����ټ�������ȡ
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
                        //���wps�Ľ���try--catch  ����wps��excel��ֵ��ʱ��ֱ������Ϊnull
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
        /// ��Excel����DataTable
        /// </summary>
        /// <param name="excelFilePath">Excel�ļ�·����Ϊ����·����</param>
        /// <param name="sheetName">Excel����������</param>
        /// <param name="headerRowIndex">Excel��ͷ������</param>
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


            #region ��ʼѭ��DS�е�Table,DS�е�ÿ������һ��Sheet
            for (int p = 0; p < ds.Tables.Count; p++)
            {
                #region ����һ��sheet
                ISheet sheet = workbook.CreateSheet(ds.Tables[p].TableName);
                //���ô������   
                int rowCount = 0;


                //����ȫ���п���и�   
                sheet.DefaultColumnWidth = 14; //ȫ���п�   
                sheet.DefaultRowHeightInPoints = 15; //ȫ���и�   
                //���ñ���������   
                int a = 0;


                IRow row1 = sheet.CreateRow(rowCount); //���������ͷ������   
                string[] columnHeaders = header.Split(new char[] { ',' });//�����Ų�ֱ���
                // var style = SetCellBorder(workbook);

                for (int k = 0; k < columnHeaders.Length; k++)
                {  //�����ݹ������ַ�����ͷ���в�ֵ�Excel

                    string columnName = columnHeaders[k];
                    ICell cell = row1.CreateCell(a);
                    cell.SetCellValue(columnName);

                    #region ���õ�Ԫ��ı߿�
                    // cell.CellStyle = style;
                    #endregion
                    a++;
                }

                //��дds���ݽ�excel   
                for (int i = 0; i < ds.Tables[p].Rows.Count; i++) //д������   
                {
                    IRow row2 = sheet.CreateRow(i + rowCount + 1);
                    int b = 0;
                    for (int j = 0; j < ds.Tables[p].Columns.Count; j++)
                    {
                        string dgvValue = string.Empty;
                        dgvValue = ds.Tables[p].Rows[i][j].ToString();
                        ICell cell = row2.CreateCell(b);
                        cell.SetCellValue(dgvValue);

                        #region ���õ�Ԫ��ı߿�
                        //cell.CellStyle = style;
                        #endregion
                        b++;
                    }
                }

                #endregion
            }
            #endregion

            //����excel   
            MemoryStream memoryStream = new MemoryStream();
            workbook.Write(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }
        /// <summary>
        /// �������sheet
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static MemoryStream ExportToExcelByDataSet(DataSet ds)
        {
            IWorkbook workbook = null;

            workbook = new HSSFWorkbook();//2003


            #region ��ʼѭ��DS�е�Table,DS�е�ÿ������һ��Sheet
            for (int p = 0; p < ds.Tables.Count; p++)
            {
                #region ����һ��sheet
                ISheet sheet = workbook.CreateSheet(ds.Tables[p].TableName);
                //���ô������   
                int rowCount = 0;


                //����ȫ���п���и�   
                sheet.DefaultColumnWidth = 14; //ȫ���п�   
                sheet.DefaultRowHeightInPoints = 15; //ȫ���и�   
                //���ñ���������   
                int a = 0;


                IRow row1 = sheet.CreateRow(rowCount); //���������ͷ������   
                // var style = SetCellBorder(workbook);

                for (int k = 0; k < ds.Tables[p].Columns.Count; k++)
                {  //�����ݹ������ַ�����ͷ���в�ֵ�Excel

                    string columnName = ds.Tables[p].Columns[k].ColumnName;
                    ICell cell = row1.CreateCell(a);
                    cell.SetCellValue(columnName);

                    #region ���õ�Ԫ��ı߿�
                    // cell.CellStyle = style;
                    #endregion
                    a++;
                }

                //��дds���ݽ�excel   
                for (int i = 0; i < ds.Tables[p].Rows.Count; i++) //д������   
                {
                    IRow row2 = sheet.CreateRow(i + rowCount + 1);
                    int b = 0;
                    for (int j = 0; j < ds.Tables[p].Columns.Count; j++)
                    {
                        string dgvValue = string.Empty;
                        dgvValue = ds.Tables[p].Rows[i][j].ToString();
                        ICell cell = row2.CreateCell(b);
                        cell.SetCellValue(dgvValue);

                        #region ���õ�Ԫ��ı߿�
                        //cell.CellStyle = style;
                        #endregion
                        b++;
                    }
                }

                #endregion
            }
            #endregion

            //����excel   
            MemoryStream memoryStream = new MemoryStream();
            workbook.Write(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }

    }
    //����ʵ�ֽӿ� ���������� �������˳�򵼳�
    public class NoSort : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            return -1;
        }
    }


}
