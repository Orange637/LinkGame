namespace LinkGame1.Entities
{
    public class NormalMode : Mode
    {
        public NormalMode()
        {
            this.Name = "Normal";
            this.RowCount = 10;
            this.ColumnCount = 14;
            this.ItemTypeCount = 15;
            this.Map = new LinkItem[10][];
            for (var row = 0; row < this.RowCount; row++)
            {
                this.Map[row] = new LinkItem[this.ColumnCount];
            }
        }
    }
}
