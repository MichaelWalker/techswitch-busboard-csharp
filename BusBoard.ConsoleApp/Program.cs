using System;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var tflApiClient = new TflApiClient();
            
            var stopPointId = UserInputManager.GetStopPointId();
            var nextBuses = tflApiClient.FetchArrivalPredictionsForStopPoint(stopPointId);
            BusBoardPrinter.PrintArrivalPredictions(nextBuses);
        }
    }
}