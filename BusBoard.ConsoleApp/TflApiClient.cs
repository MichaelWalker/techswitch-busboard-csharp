using System;
using System.Collections;
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
            var request = new RestRequest("StopPoint/{stopPointId}/Arrivals")
                .AddUrlSegment("stopPointId", stopPointId);
            return MakeGetRequest<List<ArrivalPrediction>>(request);
        }

        public IEnumerable<BusStop> FindBusStopsNearLocation(double latitude, double longitude)
        {
            var request = new RestRequest("StopPoint")
                .AddQueryParameter("stopTypes", "NaptanPublicBusCoachTram")
                .AddQueryParameter("radius", "1000")
                .AddQueryParameter("lat", $"{latitude}")
                .AddQueryParameter("lon", $"{longitude}");
            return MakeGetRequest<List<BusStop>>(request);
        }

        private T MakeGetRequest<T>(IRestRequest request) where T : new()
        {
            request.AddQueryParameter("app_id", _appId)
                .AddQueryParameter("app_key", _appKey);
            
            return _restClient.Get<T>(request).Data;
        }
    }
}