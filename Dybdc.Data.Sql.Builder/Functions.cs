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
        public static string Aggregate(string column, string function, string alias = null)
        {
            switch (function.ToUpper())
            {
                case "MAX":
                    return Max(column, alias);
                case "MIN":
                    return Min(column, alias);
                case "AVG":
                    return Avg(column, alias);
                case "SUM":
                    return Sum(column, alias);
                case "COUNT":
                    return Count(column, alias);
                default:
                    throw new ArgumentException("聚合函数“{0}”不是有效的值", function);
            }
        }

        public static string Max(string column, string alias) => string.Format("MAX({0}) {1}", column, alias);

        public static string Min(string column, string alias) => string.Format("MIN({0}) {1}", column, alias);

        public static string Avg(string column, string alias) => string.Format("AVG({0}) {1}", column, alias);

        public static string Sum(string column, string alias) => string.Format("SUM({0}) {1}", column, alias);

        public static string Count(string column, string alias) => string.Format("COUNT({0}) {1}", column, alias);

    }
}
