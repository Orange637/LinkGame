namespace LinkGame1.Entities
{
    public abstract class Mode
    {
        public string Name { get; protected set; }

        public int RowCount { get; protected set; }

        public int ColumnCount { get; protected set; }

        public int ItemTypeCount { get; protected set; }

        public LinkItem[][] Map { get; protected set; }
    }
}
