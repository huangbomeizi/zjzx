using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace zjzx.entity
{
    public class DataRecordTable
    {
        /// <summary>
        /// 数据表
        /// </summary>
        public DataTable Table { get; set; }
        /// <summary>
        /// 第几页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int RecordCount { get; set; }
    }
}
