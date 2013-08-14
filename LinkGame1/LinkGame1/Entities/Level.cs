using LinkGame1.Common;

namespace LinkGame1.Entities
{
    public class Level : ObservableObject
    {
        private int index;

        public Level(Mode mode, int index)
        {
            this.Mode = mode;
            this.Index = index;
        }

        public Mode Mode { get; private set; }

        public int Index
        {
            get { return this.index; }
            set { this.SetProperty(ref this.index, value, () => this.Index); }
        }
    }
}
