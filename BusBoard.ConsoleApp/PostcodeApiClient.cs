using RestSharp;

namespace BusBoard
{
    public class PostcodeApiClient
    {
        private readonly RestClient _restClient;

        public PostcodeApiClient()
        {
            _restClient = new RestClient("http://api.postcodes.io");
        }

        public PostcodeData FetchDataForPostcode(string postcode)
        {
            var request = new RestRequest($"postcodes/{postcode}");
            var response = _restClient.Get<PostcodeData>(request);
            return response.Data;
        }
    }
}