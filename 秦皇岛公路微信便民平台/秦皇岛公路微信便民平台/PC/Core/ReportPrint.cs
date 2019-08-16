
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Reporting.WebForms;

namespace Core
{
    /// <summary>
    /// 通过RDLC向默认打印机输出打印报表
    /// </summary>
    public class ReportPrint : IDisposable
    {
        /// <summary>
        /// 当前打印页号
        /// </summary>
        static int m_currentPageIndex;

        /// <summary>
        /// RDCL转换stream一页对应一个stream
        /// </summary>
        static List<Stream> m_streams;

        /// <summary>
        /// 把report输出成stream
        /// </summary>
        /// <param name="report">传入需要Export的report</param>
        private void Export(LocalReport report)
        {
            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
                //"  <PageWidth>2in</PageWidth>" +
                //"  <PageHeight>20in</PageHeight>" +
                "  <MarginTop>0in</MarginTop>" +
                "  <MarginLeft>0in</MarginLeft>" +
                "  <MarginRight>0in</MarginRight>" +
                "  <MarginBottom>0in</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        /// <summary>
        /// 创建具有指定的名称和格式的流。
        /// </summary>
        private Stream CreateStream(string name, string fileNameExtension,
      Encoding encoding, string mimeType, bool willSeek)
        {
            //name = "D://"+name;
            Stream stream = new FileStream(name + "." + fileNameExtension,
              FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }

        /// <summary>
        /// 打印输出
        /// </summary>
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage =
              new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        /// <summary>
        /// 打印预处理
        /// </summary>
        private void Print()
        {
            PrintDocument printDoc = new PrintDocument();
            string printerName = printDoc.PrinterSettings.PrinterName;
            if (m_streams == null || m_streams.Count == 0)
                return;
            printDoc.PrinterSettings.PrinterName = printerName;
            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format("找不到打印机 \"{0}\".", printerName);
                throw new Exception(msg);
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            StandardPrintController spc = new StandardPrintController();
            printDoc.PrintController = spc;
            printDoc.Print();
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

        /// <summary>
        /// 对外接口,启动打印
        /// </summary>
        /// <param name="dtSource">打印报表对应的数据源</param>
        /// <param name="sReport">打印报表名称</param>
        public static string Run(LocalReport report)
        {
            //LocalReport report = new LocalReport();
            //report.ReportPath = @"..\..\" + sReport;
            //ReportDataSource dataset = new ReportDataSource("DataSet1", dtSource);
            //report.DataSources.Add(dataset);
            try
            {
                m_currentPageIndex = 0;
                ReportPrint ReportPrint = new ReportPrint();
                ReportPrint.Export(report);
                ReportPrint.Print();
                ReportPrint.Dispose();
                return "ok";
            }
            catch(Exception e)
            {

                return "失败："+e.Message;
            }
        }

        /// <summary>
        /// 获取打印机状态
        /// </summary>
        /// <param name="printerName">打印机名称</param>
        /// <param name="status">输出打印机状态</param>
        private static void GetPrinterStatus2(string printerName, ref uint status)
        {
            try
            {

                string lcPrinterName = printerName;
                IntPtr liHandle = IntPtr.Zero;
                if (!Win32.OpenPrinter(lcPrinterName, out liHandle, IntPtr.Zero))
                {
                    Console.WriteLine("print  is close");
                    return;
                }
                UInt32 level = 2;
                UInt32 sizeNeeded = 0;
                IntPtr buffer = IntPtr.Zero;
                Win32.GetPrinter(liHandle, level, buffer, 0, out sizeNeeded);
                buffer = Marshal.AllocHGlobal((int)sizeNeeded);
                if (!Win32.GetPrinter(liHandle, level, buffer, sizeNeeded, out sizeNeeded))
                {
                    Console.WriteLine(Environment.NewLine + "Fail GetPrinter:" + Marshal.GetLastWin32Error());
                    return;
                }

                Win32.PRINTER_INFO_2 info = (Win32.PRINTER_INFO_2)Marshal.PtrToStructure(buffer, typeof(Win32.PRINTER_INFO_2));
                status = info.Status;
                Marshal.FreeHGlobal(buffer);
                Win32.ClosePrinter(liHandle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 对外接口,调去打印机信息
        /// </summary>
        /// <param name="printerName">打印机名称</param>
        /// <returns>返回打印机当前状态</returns>
        public static string GetPrinterStatus(string printerName)
        {
            uint intValue = 0;
            PrintDocument pd = new PrintDocument();
            printerName = printerName == "" ? pd.PrinterSettings.PrinterName : printerName;
            GetPrinterStatus2(printerName, ref intValue);
            string strRet = string.Empty;
            switch (intValue)
            {
                case 0:
                    strRet = "准备就绪（Ready）";
                    break;
                case 4194432:
                    strRet = "被打开（Lid Open）";
                    break;
                case 144:
                    strRet = "打印纸用完（Out of Paper）";
                    break;
                case 4194448:
                    strRet = "被打开并且打印纸用完（Out of Paper && Lid Open）";
                    break;
                case 1024:
                    strRet = "打印中（Printing）";
                    break;
                case 32768:
                    strRet = "初始化（Initializing）";
                    break;
                case 160:
                    strRet = "手工送纸(Manual Feed in Progress)";
                    break;
                case 4096:
                    strRet = "脱机(Offline)";
                    break;
                default:
                    strRet = "未知状态（unknown state）";
                    break;
            }
            return strRet;
        }
    }
    public class Win32
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool OpenPrinter(string printer, out IntPtr handle, IntPtr printerDefaults);
        [DllImport("winspool.drv")]
        public static extern bool ClosePrinter(IntPtr handle);
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GetPrinter(IntPtr handle, UInt32 level, IntPtr buffer, UInt32 size, out UInt32 sizeNeeded);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct PRINTER_INFO_2
        {
            public string pServerName;
            public string pPrinterName;
            public string pShareName;
            public string pPortName;
            public string pDriverName;
            public string pComment;
            public string pLocation;
            public IntPtr pDevMode;
            public string pSepFile;
            public string pPrintProcessor;
            public string pDatatype;
            public string pParameters;
            public IntPtr pSecurityDescriptor;
            public UInt32 Attributes;
            public UInt32 Priority;
            public UInt32 DefaultPriority;
            public UInt32 StartTime;
            public UInt32 UntilTime;
            public UInt32 Status;
            public UInt32 cJobs;
            public UInt32 AveragePPM;
        }
    }
}

