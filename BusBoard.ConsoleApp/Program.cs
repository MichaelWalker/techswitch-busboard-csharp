namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var tflApiClient = new TflApiClient();
            var busArrivalsService = new BusArrivalsService(tflApiClient);
            
            var stopPointId = UserInputManager.GetStopPointId();
            var arrivalPredictions = busArrivalsService.GetArrivalsForStopPoint(stopPointId);
            BusBoardPrinter.PrintArrivalPredictions(arrivalPredictions);
        }
    }
}