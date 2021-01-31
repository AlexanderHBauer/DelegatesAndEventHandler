using System;
using EventTest.Classes;

namespace EventTest
{
    class Program
    {
        // Example Code taken from https://docs.microsoft.com/en-us/dotnet/standard/events/how-to-raise-and-consume-events
        // Using a delegat like it is done here is usually only reasonable when one needs to enable legacy code to use the event/code
       
        static void Main(string[] args)
        {
            Counter c = new Counter(new Random().Next(10));

            // Subscribing to a function (right) to the event "attibute" of the class (left)
            c.ThresholdReached += c_ThresholdReached;

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }
        }

        // A function that implements our delegate function "ThresholdReachedEventHandler"
        static void c_ThresholdReached(Object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
            Environment.Exit(0);
        }

    }
}
