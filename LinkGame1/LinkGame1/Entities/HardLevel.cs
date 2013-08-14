namespace LinkGame1.Entities
{
    public class HardMode : Mode
    {
        public HardMode()
        {
            this.Name = "Hard";
            this.RowCount = 14;
            this.ColumnCount = 20;
            this.ItemTypeCount = 20;
            this.Map = new LinkItem[14][];
            for (var row = 0; row < this.RowCount; row++)
            {
                this.Map[row] = new LinkItem[this.ColumnCount];
            }
        }
    }
}
