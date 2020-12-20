using System;
using System.Collections.Generic;
using System.Text;

namespace Dybdc.Data.Sql.Builder
{
    /// <summary>
    /// 函数
    /// </summary>
    public class Functions
    {
        public static string Aggregate(string column, string function)
        {
            switch (function.ToUpper())
            {
                case "MAX":
                    return Max(column);
                case "MIN":
                    return Min(column);
                case "AVG":
                    return Avg(column);
                case "SUM":
                    return Sum(column);
                case "COUNT":
                    return Count(column);
                default:
                    throw new ArgumentException("聚合函数“{0}”不是有效的值", function);
            }
        }

        public static string Max(string column) => string.Format("MAX({0})", column);

        public static string Min(string column) => string.Format("MIN({0})", column);

        public static string Avg(string column) => string.Format("AVG({0})", column);

        public static string Sum(string column) => string.Format("SUM({0})", column);

        public static string Count(string column) => string.Format("COUNT({0})", column);

    }
}
