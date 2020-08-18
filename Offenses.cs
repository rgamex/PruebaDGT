namespace PruebaInnovatioStrategies
{
    public class Offenses
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int DecreasePoint { get; set; }

        public Offenses(int id, string description, int decreasePoint)
        {
            Id = id;
            Description = description;
            DecreasePoint = decreasePoint;
        }
    }
}