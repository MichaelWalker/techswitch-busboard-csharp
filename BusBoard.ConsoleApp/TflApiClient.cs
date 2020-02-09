using System;
using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class TflApiClient
    {
        private readonly RestClient _restClient;
        private readonly string _appId;
        private readonly string _appKey;
        
        public TflApiClient()
        {
            _restClient = new RestClient("https://api.tfl.gov.uk");
            _appId = Environment.GetEnvironmentVariable("TFL_APP_ID");
            _appKey = Environment.GetEnvironmentVariable("TFL_APP_KEY");
        }

        public IEnumerable<ArrivalPrediction> FetchArrivalPredictionsForStopPoint(string stopPointId)
        {
            var request = new RestRequest($"StopPoint/{stopPointId}/Arrivals")
                .AddQueryParameter("app_id", _appId)
                .AddQueryParameter("app_key", _appKey);
            var response = _restClient.Get<List<ArrivalPrediction>>(request);
            return response.Data;
        }

        public IEnumerable<BusStop> FindBusStopsNearLocation(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }
    }
}