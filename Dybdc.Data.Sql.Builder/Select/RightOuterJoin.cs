namespace Dybdc.Data.Sql.Builder.Select
{
    /// <summary>
    ///     An SQL Right Outer Join.
    /// </summary>
    public class RightOuterJoin : JoinClause<RightOuterJoin>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RightOuterJoin"/> class.
        /// </summary>
        /// <param name="firstTable">The first table.</param>
        /// <param name="secondTable">The second table.</param>
        /// <param name="onClause">The on clause.</param>
        public RightOuterJoin(IFromClause firstTable, IFromClause secondTable, string onClause)
            : base(firstTable, secondTable, onClause)
        {
        }

        /// <summary>
        /// Gets the name of the clause.
        /// </summary>
        /// <value>
        /// The name of the clause.
        /// </value>
        protected override string ClauseName
        {
            get { return "RIGHT OUTER"; }
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A clone of this instance.</returns>
        public override RightOuterJoin Clone()
        {
            return new RightOuterJoin(this.FirstTable.CloneFrom(), this.SecondTable.CloneFrom(), this.OnClause);
        }
    }
}
