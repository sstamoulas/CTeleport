using CTeleportTest.Models;
using CTeleportTest.Repositories;
using GeoCoordinatePortable;

namespace CTeleportTest.Services
{
    public class AirportService : IAirportService
    {
        private Airport sourceAirport;
        private Airport targetAirport;
        private const double METERS_TO_MILES_CONVERSION = 1609.344;
        private static readonly string URL = "https://places-dev.cteleport.com/airports/";
        private IGenericRepository<Airport> _airportRepository;

        public AirportService(IGenericRepository<Airport> repository)
        {
            _airportRepository = repository;
            sourceAirport = new Airport();
            targetAirport = new Airport();
        }

        public double GetByIATA(string sourceIATA, string targetIATA)
        {
            sourceAirport = _airportRepository.DownloadSerializedJsonData<Airport>(URL + sourceIATA.ToUpper());
            targetAirport = _airportRepository.DownloadSerializedJsonData<Airport>(URL + targetIATA.ToUpper());

            if (sourceAirport.IATA != null && targetAirport.IATA != null)
            {
                // get geo-coordinates of each airport
                var locA = new GeoCoordinate(sourceAirport.Location["lat"], sourceAirport.Location["lon"]);
                var locB = new GeoCoordinate(targetAirport.Location["lat"], targetAirport.Location["lon"]);

                // get distance in meters between airports
                double distance = locA.GetDistanceTo(locB);

                // distance is returned in meters so convert to miles
                return distance / METERS_TO_MILES_CONVERSION;
            }

            return 0;
        }
    }
}
