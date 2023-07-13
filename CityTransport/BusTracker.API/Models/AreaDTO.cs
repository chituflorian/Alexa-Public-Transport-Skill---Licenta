namespace BusTracker.API.Models
{
    public class AreaDTO
    {
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public int CityID { get; set; }
        public CityDTO City { get; set; }
    }
}
