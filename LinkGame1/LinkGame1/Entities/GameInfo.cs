using System.Collections.Generic;

namespace LinkGame1.Entities
{
    public class GameInfo
    {
        public GameInfo()
        {
            this.Levels = new List<Level>
                {
                    new Level(new EasyMode(), 1),
                    new Level(new NormalMode(), 2),
                    new Level(new HardMode(), 3)
                };
        }

        public IList<Level> Levels { get; private set; }
    }
}
