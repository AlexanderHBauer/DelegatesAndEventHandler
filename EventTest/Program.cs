using System;
using EventTest.Classes;
using System.Collections.Generic;

namespace EventTest
{
    class Program
    {
        // Example Code taken from https://docs.microsoft.com/en-us/dotnet/standard/events/how-to-raise-and-consume-events
        // Using a delegat like it is done here is usually only reasonable when one needs to enable legacy code to use the event/code
       
        static void Main(string[] args)
        {

            //Counter c = new Counter(new Random().Next(10));

            //// Subscribing to a function (right) to the event "attibute" of the class (left)
            //c.ThresholdReached += c_ThresholdReached;

            //Console.WriteLine("press 'a' key to increase total");
            //while (Console.ReadKey(true).KeyChar == 'a')
            //{
            //    Console.WriteLine("adding one");
            //    c.Add(1);
            //}

            Random myRand = new Random();
            int myIndx = myRand.Next(0, LetterOptions.letterOptions.Count);
            string mySecret = LetterOptions.letterOptions[myIndx];
            Button myButton = new Button(mySecret);
            myButton.CorrectButtonClicked += c_CorrectButtonClicked;
            myButton.ExceededThreshold += c_ExceededThreshold;
            Console.WriteLine("Guess the letter that is the secret key and press the button you suspect.");
            Console.WriteLine("The letter lies within the range of (including) {0} - {1}", LetterOptions.letterOptions[0], LetterOptions.letterOptions[LetterOptions.letterOptions.Count - 1]);
            // giving the user a generous (2 x Options Amount) attempts
            int i = 0;
            while (i < (LetterOptions.letterOptions.Count * 2))
            {
                myButton.userkey = Console.ReadLine();
                myButton.attempts = i + 1;
                myButton.CheckKey();
                i++;
            }

        }

        // A function that implements our delegate function "ThresholdReachedEventHandler"
        //static void c_ThresholdExceeded(Object sender, ThresholdReachedEventArgs e)
        //{
        //    Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
        //    Environment.Exit(0);
        //}

        // Function needs to be static to be eligible to subscribe to the event
        static void c_CorrectButtonClicked(Object sender, ButtonFoundEventArgs e)
        {
            Console.WriteLine("Congratulations! You found the secret key \'{0}\' \n({1} attempts needed)", e.key, e.attempts);
            Environment.Exit(0);
        }

        static void c_ExceededThreshold(Object sender, ThresholdExceededEventArgs e2)
        {
            Console.WriteLine("You guessed wrong as many times as there are letter options ({0})!\nThe program will exit now.", e2.maxAttempts);
            Environment.Exit(0);
        }
    }
}
