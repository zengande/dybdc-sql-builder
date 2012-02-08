﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.Sql.Builder
{
    /// <summary>
    ///     The basics of an SQL statement.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SqlStatement<T>
        where T : SqlStatement<T>
    {
        /// <summary>
        ///     Indentation to use when indenting query sub-parts.
        /// </summary>
        protected const string Indentation = "    ";
        protected const string Separator = ", ";

        private readonly List<string> tables;
        private readonly List<WhereClause> whereClauses;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlStatement&lt;T&gt;"/> class.
        /// </summary>
        protected SqlStatement()
        {
            this.tables = new List<string>();
            this.whereClauses = new List<WhereClause>();
        }

        /// <summary>
        ///     Adds a table to the FROM list of the statement.
        /// </summary>
        /// <param name="tables">The tables.</param>
        /// <returns></returns>
        public T From(params string[] tables)
        {
            this.tables.AddRange(tables);
            return (T)this;
        }

        /// <summary>
        ///     Adds a WHERE clause to the statement
        /// </summary>
        /// <param name="clause">The clause.</param>
        /// <param name="or">if set to <c>true</c> [or].</param>
        /// <returns></returns>
        public T Where(string clause, bool or = false)
        {
            this.whereClauses.Add(new WhereClause(clause, or));
            return (T)this;
        }

        /// <summary>
        ///     Returns the statement as an SQL string.
        /// </summary>
        /// <returns></returns>
        public abstract string ToSql();

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.ToSql();
        }

        /// <summary>
        ///     Appends the FROM statement to the builder.
        /// </summary>
        /// <returns></returns>
        protected void AppendFrom(StringBuilder builder)
        {
            builder.AppendLine("FROM");
            builder.AppendLine(Indentation + string.Join(Separator, this.tables));
        }

        /// <summary>
        ///     Appends the WHERE statement to the builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected void AppendWhere(StringBuilder builder)
        {
            if (this.whereClauses.Any())
            {
                builder.AppendLine("WHERE");
                int i = 0;
                foreach (var clause in this.whereClauses)
                {
                    builder.Append(Indentation + clause.Clause);
                    if (i < this.whereClauses.Count - 1) // Last clause
                    {
                        builder.AppendLine(" AND");
                    }
                    else
                    {
                        builder.AppendLine();
                    }
                    i++;
                }
            }
        }
    }
}