namespace LinkGame1.Entities
{
    public class EasyMode : Mode
    {
        public EasyMode()
        {
            this.Name = "Easy";
            this.RowCount = 10;
            this.ColumnCount = 10;
            this.ItemTypeCount = 10;
            this.Map = new LinkItem[this.RowCount][];
            for (var row = 0; row < this.RowCount; row++)
            {
                this.Map[row] = new LinkItem[this.ColumnCount];
            }
        }
    }
}
