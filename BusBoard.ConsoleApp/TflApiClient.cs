using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class TflApiClient
    {
        private readonly RestClient _restClient;
        
        public TflApiClient()
        {
            _restClient = new RestClient("https://api.tfl.gov.uk");
        }

        public IEnumerable<ArrivalPrediction> FetchArrivalPredictionsForStopPoint(string stopPointId)
        {
            var request = new RestRequest($"StopPoint/{stopPointId}/Arrivals");
            var response = _restClient.Get<List<ArrivalPrediction>>(request);
            return response.Data;
        }
    }
}