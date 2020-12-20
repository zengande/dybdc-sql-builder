﻿using System;

namespace Dybdc.Data.Sql.Builder.Select
{
    /// <summary>
    ///     Represents an ORDER BY column in an SQL statement.
    /// </summary>
    public class OrderByClause : ICloneable
    {
        private readonly string column;

        private readonly bool asc;

        /// <summary>
        ///     The column to order by.
        /// </summary>
        public string Column => this.column;

        /// <summary>
        ///     Whether to order in ascending or descending order.
        /// </summary>
        public bool Asc => this.asc;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderByClause"/> class.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <param name="asc">if set to <c>true</c> [asc].</param>
        public OrderByClause(string column, bool asc)
        {
            this.column = column;
            this.asc = asc;
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A clone of this instance.</returns>
        public OrderByClause Clone()
        {
            return new OrderByClause(this.Column, this.Asc);
        }
    }
}
