using System;
using System.Collections.Generic;

namespace BusBoard
{
    public class BusBoardPrinter
    {
        private const int ColumnWidth = 30;

        public static void PrintArrivalPredictions(IEnumerable<ArrivalPrediction> arrivalPredictions)
        {
            Console.WriteLine("\n");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            PrintRow("Line", "Destination", "Time To Arrival");
            PrintRow("==============================", "==============================", "==============================");

            foreach (var arrival in arrivalPredictions)
            {
                PrintArrivalPrediction(arrival);
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
        }

        private static void PrintArrivalPrediction(ArrivalPrediction arrivalPrediction)
        {
            var timeToArrivalString = GetTimeToArrivalMessage(arrivalPrediction.TimeToStation);
                PrintRow(arrivalPrediction.LineName, arrivalPrediction.DestinationName, timeToArrivalString);
        }

        private static string GetTimeToArrivalMessage(int secondsToArrival)
        {
            if (secondsToArrival < 30)
            {
                return "due";
            }

            if (secondsToArrival < 90)
            {
                return "1 min";
            }

            var minutesToArrival = secondsToArrival / 60.0;
            var roundedMinsRemaining = Math.Round(minutesToArrival, 0);
            return $"{roundedMinsRemaining} mins";
        }

        private static void PrintRow(params object[] items)
        {
            var outputString = "| ";
            foreach (var item in items)
            {
                outputString += item.ToString().PadRight(ColumnWidth);
                outputString += " | ";
            }
            Console.WriteLine(outputString);
        }
    }
}