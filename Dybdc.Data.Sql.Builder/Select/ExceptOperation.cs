﻿namespace Dybdc.Data.Sql.Builder.Select
{
    /// <summary>
    ///     The SQL EXCEPT operation.
    /// </summary>
    public class ExceptOperation : SetOperation<ExceptOperation>
    {
        private readonly bool all;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptOperation"/> class.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="all">if set to <c>true</c> [all].</param>
        public ExceptOperation(ISetQuery first, ISetQuery second, bool all = false)
            : base(first, second)
        {
            this.all = all;
        }

        /// <summary>
        ///     If true, will perform a EXCEPT ALL query instead of simple EXCEPT.
        /// </summary>
        public bool All => this.all;

        /// <summary>
        /// Gets the set operator of the operation.
        /// </summary>
        protected override string SetOperator
        {
            get { return "EXCEPT" + (this.All ? " ALL" : string.Empty); }
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A cloned instance.</returns>
        public override ExceptOperation Clone()
        {
            return new ExceptOperation((ISetQuery)this.First.Clone(), (ISetQuery)this.Second.Clone());
        }
    }
}
