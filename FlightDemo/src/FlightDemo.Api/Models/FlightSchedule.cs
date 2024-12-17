namespace FlightDemo.Api.Models;

public class FlightSchedule
{
    public string FlightId { get; set; } = null!;
    public string DepartureCity { get; set; } = null!;
    public string ArrivalCity { get; set; } = null!;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
}
