namespace Flightboard.API.Models
{
    public class Flight
    {
        public Flight()
        {
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string WeekDay { get; set; }
    }
}
