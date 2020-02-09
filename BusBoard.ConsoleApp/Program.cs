using System;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopPointId = UserInputManager.GetStopPointId();
            Console.WriteLine($"The stop code is {stopPointId}");
        }
    }
}