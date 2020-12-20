using System;
using System.Collections.Generic;
using System.Text;

namespace Dybdc.Data.Sql.Builder
{
    /// <summary>
    /// 条件判断
    /// </summary>
    public class Conditions
    {
        /// <summary>
        /// 相等
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="value">值</param>
        /// <returns>column_name = value</returns>
        public static string Equal(string column, string value) => string.Format("{0} = {1}", column, value);


    }
}
