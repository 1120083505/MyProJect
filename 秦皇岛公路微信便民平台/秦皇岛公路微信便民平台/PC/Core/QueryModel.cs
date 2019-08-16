using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{

    /// <summary>
    /// 查询条件实体QueryStr
    /// </summary>
    public class QueryModel
    {
        /// <summary>
        /// 字段名
        /// </summary>
        public string filed { get; set; }
        /// <summary>
        /// 字段值
        /// </summary>
        public string text { get; set; }
    }
}
