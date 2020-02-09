using System.Collections.Generic;
using System.Linq;

namespace BusBoard
{
    public class StopLocatorService
    {
        private readonly PostcodeApiClient _postcodeApiClient;
        private readonly TflApiClient _tflApiClient;

        public StopLocatorService(PostcodeApiClient postcodeApiClient, TflApiClient tflApiClient)
        {
            _postcodeApiClient = postcodeApiClient;
            _tflApiClient = tflApiClient;
        }

        public IEnumerable<BusStop> FindNearestTwoBusStops(string postcode)
        {
            var postcodeData = _postcodeApiClient.FetchDataForPostcode(postcode);
            return _tflApiClient
                .FindBusStopsNearLocation(postcodeData.Lat, postcodeData.Lon)
                .Take(2);
        }
    }
}