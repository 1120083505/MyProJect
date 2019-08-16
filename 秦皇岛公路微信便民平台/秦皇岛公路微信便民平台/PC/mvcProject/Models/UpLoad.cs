using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    /// <summary>
    /// 关于文件上传
    /// </summary>
    public class UpLoad
    {
        /// <summary>
        /// 是否允许多文件上传 true，false
        /// </summary>
        public bool multi { get; set; }
        /// <summary>
        /// 允许上传的文件后缀 格式：*.jpg;*.jpeg;
        /// </summary>
        public string fileExt { get; set; }
        /// <summary>
        /// 允许上传的文件中文说明 格式：只能选择图片格式;
        /// </summary>
        public string fileDesc { get; set; }

    }
}