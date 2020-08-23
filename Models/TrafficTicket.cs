namespace PruebaInnovatioStrategies
{
    public class TrafficTicket
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int DecreasePoint { get; set; }

        public TrafficTicket(int id, string description, int decreasePoint)
        {
            Id = id;
            Description = description;
            DecreasePoint = decreasePoint;
        }
    }
}