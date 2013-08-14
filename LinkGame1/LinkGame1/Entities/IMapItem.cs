namespace LinkGame1.Entities
{
    public interface IMapItem
    {
        int Row { get; set; }

        int Column { get; set; }

        int Value { get; set; }

        bool IsDead { get; set; }
    }
}
