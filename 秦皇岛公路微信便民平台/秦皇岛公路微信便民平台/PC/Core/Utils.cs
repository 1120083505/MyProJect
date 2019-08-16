using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;


namespace Core
{
    /// <summary>
    /// 常用方法类
    /// </summary>
    public class Utils
    {
        #region 判断是否正数包含正小数
        /// <summary>
        /// 判断是否正数包含正小数
        /// </summary>
        /// <param name="sNum"></param>
        /// <returns></returns>
        public static bool IsPositiveNumber(object sNum)
        {
            decimal num;   //临时变量
            if (sNum == null)
            {
                //如果传入的值为NULL，返回False
                return false;
            }
            //尝试转换传入的值
            if (decimal.TryParse(sNum.ToString(), out num))
            {
                if (num > 0)
                {
                    //成功返回True
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //失败返回False
                return false;
            }
        }
        #endregion

        #region 判断是否正数
        /// <summary>
        /// 判断是否正数
        /// </summary>
        /// <param name="sNum">值</param>
        /// <returns></returns>
        public static bool IsPositiveNumberOrLing(object sNum)
        {
            decimal num;   //临时变量
            if (sNum == null)
            {
                //如果传入的值为NULL，返回False
                return false;
            }
            //尝试转换传入的值
            if (decimal.TryParse(sNum.ToString(), out num))
            {
                if (num >= 0)
                {
                    //成功返回True
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //失败返回False
                return false;
            }
        }
        #endregion

        #region 判断是否为时间格式
        /// <summary>
        /// 判断是否为时间格式
        /// </summary>
        /// <param name="sNum"></param>
        /// <returns></returns>
        public static bool IsDateTime(object sNum)
        {
            DateTime num;   //临时变量
            if (sNum == null)
            {
                //如果传入的值为NULL，返回False
                return false;
            }
            //尝试转换传入的值
            if (DateTime.TryParse(sNum.ToString(), out num))
            {
                //成功返回True
                return true;
            }
            else
            {
                //失败返回False
                return false;
            }
        }
        #endregion

        #region 判断是否为正整数
        /// <summary>
        /// 判断是否为正整数
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns>是正整数返回true,不是返回false</returns>
        public static bool isNumber(string strValue)
        {
            Regex regex = new Regex("^[0-9]*[1-9][0-9]*$");
            return regex.IsMatch(strValue.Trim());
        }
        #endregion

        #region 去除HTML标记
        /// <summary>
        ///  去除HTML标记
        /// </summary>
        /// <param name="Htmlstring">包括HTML标签的源码</param>
        /// <returns>已经去除后的文字</returns>
        public static string NoHTML(string Htmlstring)
        {
            //Delete脚本 
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //DeleteHTML 
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;

        }
        #endregion

        #region 获得图片地址
        public static string GetImgUrl(string HTMLStr)
        {
            string str = string.Empty;
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>",
                RegexOptions.Compiled);
            Match m = r.Match(HTMLStr.ToLower());
            if (m.Success)
                str = m.Result("${url}");
            return str;
        }
        #endregion

        #region 脏字过滤
        /// <summary>
        /// 脏字过滤
        /// </summary>
        /// <param name="content"></param>
        /// <param name="dirty"></param>
        /// <returns></returns>
        public static string Dirty_Filter(string content, string dirty)
        {
            return Regex.Replace(content, dirty, "***", RegexOptions.IgnoreCase);
        }
        #endregion

        #region 换行替换
        /// <summary>
        /// 换行替换
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Line_Replace(string content)
        {
            return content.Replace("<br>", "\n").Replace("<br />", "\n").Replace("<br/>", "\n");
        }
        #endregion

        #region 换行反替换
        /// <summary>
        /// 换行反替换
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Line_UnReplace(string content)
        {
            return content.Replace("\n", "<br />");
        }
        #endregion

        #region 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        public static bool PostMail(string Smtp, int Port, string Usr, string Pwd, string From, string FromName, string To, string ToName, string Subject, string Body)
        {
            MailMessage email = new MailMessage(new MailAddress(From, FromName), new MailAddress(To, ToName));
            email.BodyEncoding = Encoding.UTF8;
            email.IsBodyHtml = true;
            email.Subject = Subject;
            email.Body = Body;
            SmtpClient Client = new SmtpClient(Smtp);
            Client.UseDefaultCredentials = false;
            Client.Credentials = new NetworkCredential(Usr, Pwd);
            Client.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                Client.Send(email);
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region MD5加密
        /// <summary>
        /// md5加密
        /// </summary>
        public static string MD5(string Scode)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Scode.Trim(), "MD5").ToLower();
        }
        #endregion

        #region 获取文件夹大小
        /// <summary>
        /// 获取文件夹大小
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static long GetDirectoryLength(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                return 0;
            }
            long len = 0;
            DirectoryInfo di = new DirectoryInfo(dirPath);
            foreach (FileInfo fi in di.GetFiles())
            {
                len += fi.Length;
            }
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    len += GetDirectoryLength(dis[i].FullName);
                }
            }
            return len;
        }
        #endregion

        #region 复制文件
        public static void CopyFile(string SourceFile, string ObjectFile)
        {
            string sourceFile = HttpContext.Current.Server.MapPath(SourceFile);
            string objectFile = HttpContext.Current.Server.MapPath(ObjectFile);
            if (System.IO.File.Exists(sourceFile))
            {
                System.IO.File.Copy(sourceFile, objectFile, true);
            }
        }
        #endregion

        #region  生成缩略图MakeThumbnail
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式 H-指定高，宽按比例 W：指定宽，高按比例，Cut 是裁剪 HW 指定宽高缩放</param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode.ToLower())
            {
                case "hw"://指定高宽缩放（可能变形）                
                    break;
                case "w"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "h"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception)
            {

            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        #endregion

        #region 生成随机字母字符串(数字字母混和)
        public static int rep = 0;
        /// <summary>
        /// 生成随机字母字符串(数字字母混和)
        /// </summary>
        /// <param name="codeCount">待生成的位数</param>
        /// <returns>生成的字母字符串</returns>
        public static string GenerateCheckCode(int codeCount)
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codeCount; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }
        #endregion

        #region 获得数字形式的随机字符串
        /// <summary>
        /// 获得数字形式的随机字符串
        /// </summary>
        /// <returns>数字形式的随机字符串</returns>
        public static string mikecat_GetNumberRandom()
        {
            int mikecat_intNum;
            long mikecat_lngNum;
            string mikecat_strNum = System.DateTime.Now.ToString();
            mikecat_strNum = mikecat_strNum.Replace(":", "");
            mikecat_strNum = mikecat_strNum.Replace("-", "");
            mikecat_strNum = mikecat_strNum.Replace(" ", "");
            mikecat_strNum = mikecat_strNum.Replace("/", "");

            mikecat_lngNum = long.Parse(mikecat_strNum);
            System.Random mikecat_ran = new Random();
            mikecat_intNum = mikecat_ran.Next(1, 99999);
            mikecat_ran = null;
            mikecat_lngNum += mikecat_intNum;
            return mikecat_lngNum.ToString();
        }
        #endregion

        #region  可逆加密/解密
        /// <summary>
        /// 加密-可逆
        /// </summary>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static string DESEncryptMethod(string rs)
        {
            byte[] desKey = new byte[] { 0x16, 0x09, 0x14, 0x15, 0x07, 0x01, 0x05, 0x08 };
            byte[] desIV = new byte[] { 0x16, 0x09, 0x14, 0x15, 0x07, 0x01, 0x05, 0x08 };

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {
                byte[] inputByteArray = Encoding.Default.GetBytes(rs);
                //byte[] inputByteArray=Encoding.Unicode.GetBytes(rs);

                des.Key = desKey;  // ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = desIV;   //ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(),
                 CryptoStreamMode.Write);
                //Write the byte array into the crypto stream
                //(It will end up in the memory stream)
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                //Get the data back from the memory stream, and into a string
                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    //Format as hex
                    ret.AppendFormat("{0:X2}", b);
                }
                ret.ToString();
                return ret.ToString();
            }
            catch
            {
                return rs;
            }
            finally
            {
                des = null;
            }
        }
        /// <summary>
        /// 解密-可逆
        /// </summary>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static string DESDecryptMethod(string rs)
        {
            byte[] desKey = new byte[] { 0x16, 0x09, 0x14, 0x15, 0x07, 0x01, 0x05, 0x08 };
            byte[] desIV = new byte[] { 0x16, 0x09, 0x14, 0x15, 0x07, 0x01, 0x05, 0x08 };

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {
                //Put the input string into the byte array
                byte[] inputByteArray = new byte[rs.Length / 2];
                for (int x = 0; x < rs.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(rs.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                des.Key = desKey;   //ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = desIV;    //ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                //Flush the data through the crypto stream into the memory stream
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                //Get the decrypted data back from the memory stream
                StringBuilder ret = new StringBuilder();

                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch
            {
                return rs;
            }
            finally
            {
                des = null;
            }
        }
        #endregion

        #region 获取当前时间
        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns></returns>
        public static string GetDateTimeNowStr()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }
        #endregion

        #region 判断后缀是否为图片
        /// <summary>
        /// 文件名称
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static bool checkIMG(string FileName)
        {
            string[] temp = FileName.Split('.');
            string hz = temp[temp.Length - 1].ToLower();
            if (hz == "jpg" || hz == "gif" || hz == "bmp" || hz == "png" || hz == "jpeg")
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 将datatable数据转换成JSON数据
        /// <summary>
        /// 将datatable数据转换成JSON数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            DataRowCollection drc = dt.Rows;
            for (int i = 0; i < drc.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string strKey = dt.Columns[j].ColumnName;
                    string strValue = drc[i][j].ToString();
                    Type type = dt.Columns[j].DataType;
                    jsonString.Append("\"" + strKey + "\":");
                    strValue = StringFormat(strValue, type);
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append(strValue + ",");
                    }
                    else
                    {
                        jsonString.Append(strValue);
                    }
                }
                jsonString.Append("},");
            }
            if (drc.Count > 0)
            {
                jsonString.Remove(jsonString.Length - 1, 1);
            }
            jsonString.Append("]");
            return jsonString.ToString();
        }
        /// <summary>  
        /// 过滤特殊字符  
        /// </summary>  
        /// <param name="s"></param>  
        /// <returns></returns>  
        private static string String2Json(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\""); break;
                    case '\\':
                        sb.Append("\\\\"); break;
                    case '/':
                        sb.Append("\\/"); break;
                    case '\b':
                        sb.Append("\\b"); break;
                    case '\f':
                        sb.Append("\\f"); break;
                    case '\n':
                        sb.Append("\\n"); break;
                    case '\r':
                        sb.Append("\\r"); break;
                    case '\t':
                        sb.Append("\\t"); break;
                    default:
                        sb.Append(c); break;
                }
            }
            return sb.ToString();
        }

        /// <summary>  
        /// 格式化字符型、日期型、布尔型  
        /// </summary>  
        /// <param name="str"></param>  
        /// <param name="type"></param>  
        /// <returns></returns>  
        private static string StringFormat(string str, Type type)
        {
            if (type == typeof(string))
            {
                str = String2Json(str);
                str = "\"" + str + "\"";
            }
            else if (type == typeof(DateTime))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
            }
            return str;
        }
        #endregion

        #region 将datatable数据转换成JSON数据，加返回值
        /// <summary>
        /// 将datatable数据转换成JSON数据，加返回值
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="Status">返回状态</param>
        /// <param name="TotalCount">总行数</param>
        /// <param name="memo">备注</param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dt, string Status, string TotalCount, string memo)
        {
            string str = DataTableToJson(dt);
            return "[{\"Status\":\"" + Status + "\",\"TotalCount\":\"" + TotalCount + "\",\"Count\":\"" + dt.Rows.Count + "\",\"Memo\":\"" + memo + "\",\"data\":" + str + "}]";
        }
        #endregion

        #region 获取时间格式新ID
        /// <summary>
        /// 获取时间格式新ID
        /// </summary>
        /// <returns></returns>
        public static string GetNewDateID()
        {
            string id = "{0}{1}{2}";
            string[] param ={
                            DateTime.Now.ToString("yyyyMMddHHmmssffff"),
                            Guid.NewGuid().ToString().Substring(8, 6),
                            GenerateCheckCode(6)
                            };
            id = string.Format(id, param);
            return id.ToLower();
        }
        #endregion

        #region 自动创建文件夹
        /// <summary>
        /// 自动创建文件夹
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static bool AutoCreatDir(string Path)
        {
            if (Directory.Exists(Path) == false) //检查主目录File是否存在
            {
                try
                {
                    DirectoryInfo info = new DirectoryInfo(Path);
                    info.Create();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 写入文件

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <param name="contents"></param>
        public static void WriteFile(string path, string filename, string contents)
        {
            //写入文件
            //创建文件夹
            AutoCreatDir(path);
            path = path + "/" + filename;

            //打开或者创建文件
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            //如果原来存在文件则 清空原来文件的内容
            fs.SetLength(0);
            //创建文本写入流
            StreamWriter st = new StreamWriter(fs, Encoding.UTF8);
            //将字符串写入文件
            st.WriteLine(contents);
            //关闭流
            st.Close();
            fs.Close();
        }
        #endregion

        #region 写入文件

        /// <summary>
        /// 写入文件,文件存在则继续写入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <param name="contents"></param>
        public static void WriteFileContinue(string path, string filename, string contents)
        {
            AutoCreatDir(path);
            path = path + "/" + filename;
            StreamWriter st = new StreamWriter(path, true, Encoding.UTF8);
            st.WriteLine(contents);
            st.Close();
        }
        #endregion

        #region 导出Excel
        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="page"></param>
        /// <param name="dtSource"></param>
        public static void ExportToExcel(Page page, DataTable dtSource, string filename)
        {
            page.Response.Clear();
            page.Response.BufferOutput = false;
            page.Response.ContentEncoding = System.Text.Encoding.UTF8;
            page.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("gb2312");
            page.Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            page.Response.ContentType = "application/ms-excel";
            StarTech.NPOI.NPOIHelper.ExportExcel(dtSource, page.Response.OutputStream);
            page.Response.Close();
        }
        #endregion

        #region 计算两GPS的距离
        /// <summary>
        ///计算两点GPS坐标的距离
        /// </summary>
        /// <param name="n1">第一点的纬度坐标</param>
        /// <param name="e1">第一点的经度坐标</param>
        /// <param name="n2">第二点的纬度坐标</param>
        /// <param name="e2">第二点的经度坐标</param>
        /// <returns></returns>
        public static double GPS_Distance(double n1, double e1, double n2, double e2)
        {
            double jl_jd = 102834.74258026089786013677476285;
            double jl_wd = 111712.69150641055729984301412873;
            double b = Math.Abs((e1 - e2) * jl_jd);
            double a = Math.Abs((n1 - n2) * jl_wd);
            return Math.Sqrt((a * a + b * b));

        }
        #endregion

        #region 获取时间戳
        /// <summary>  
        /// 获取时间戳  
        /// </summary>  
        /// <returns></returns>  
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString(); 
        }
        #endregion


        #region httpPost提交
        /// <summary>
        /// httpPost提交
        /// </summary>
        /// <param name="Url">请求地址</param>
        /// <param name="postDataStr">参数</param>
        /// <returns></returns>
        public static string HttpPost(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            //request.CookieContainer = cookie;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //response.Cookies = cookie.GetCookies(response.ResponseUri);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
        #endregion


        #region httpGet提交
        /// <summary>
        /// HttpGet请求
        /// </summary>
        /// <param name="Url">请求地址</param>
        /// <param name="DataStr">参数</param>
        /// <returns></returns>
        public static string HttpGet(string Url, string DataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (DataStr == "" ? "" : "?") + DataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
        #endregion
    }
}
