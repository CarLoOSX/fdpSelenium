using MdasFdpPractica3.Enum;

namespace MdasFdpPractica3.Dto
{
    public class SearchFlightDto
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DatesEnum Outbound { get; set; }
        public string Return { get; set; }
        public int Passengers { get; set; }
    }
}
