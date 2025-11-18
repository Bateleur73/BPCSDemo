namespace DemoBPCSWebAPI.Data
{
    public class Location(int id, string locationName)
    {
        public int ID { get; set; } = id;
        public string LocationName { get; set; } = locationName;
    }
}
