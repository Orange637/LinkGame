using LinkGame1.Common;

namespace LinkGame1.Entities
{
    public class Player : ObservableObject
    {
        private string name;

        private int scores;

        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value, () => this.Name); }
        }

        public int Scores
        {
            get { return this.scores; }
            set { this.SetProperty(ref this.scores, value, () => this.Scores); }
        }

        public GameInfo GameInfo { get; set; }
    }
}
