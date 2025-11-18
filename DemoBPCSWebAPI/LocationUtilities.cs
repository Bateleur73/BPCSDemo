using DemoBPCSWebAPI.Data;

namespace DemoBPCSWebAPI
{
    public class LocationUtilities(IDBData db)
    {
        private readonly IDBData _db = db;

        public int GetLocationID(string locationName)
        {
            foreach (var item in _db.Locations)
            {
                if (item.LocationName == locationName)
                {
                    return item.ID;
                }
            }

            return -1;
        }
    }
}
