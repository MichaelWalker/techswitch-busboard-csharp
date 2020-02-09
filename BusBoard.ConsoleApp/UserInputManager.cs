using System;

namespace BusBoard
{
    public class UserInputManager
    {
        public static string GetStopPointId()
        {
            Console.WriteLine("Welcome to BusBoard!");
            Console.WriteLine("====================");
            Console.WriteLine("Please enter your stop code \n");

            return Console.ReadLine();
        }
    }
}