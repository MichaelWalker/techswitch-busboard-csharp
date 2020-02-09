using System.Collections.Generic;
using System.Linq;

namespace BusBoard
{
    public class BusArrivalsService
    {
        private readonly TflApiClient _tflApiClient;
        
        public BusArrivalsService(TflApiClient tflApiClient)
        {
            _tflApiClient = tflApiClient;
        }

        public IEnumerable<ArrivalPrediction> GetArrivalsForStopPoint(string stopPointId)
        {
            return _tflApiClient
                .FetchArrivalPredictionsForStopPoint(stopPointId)
                .OrderBy(arrival => arrival.TimeToStation)
                .Take(5);
        }
    }
}