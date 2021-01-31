using System;
using System.Collections.Generic;
using System.Text;


namespace EventTest.Classes
{
    class Counter
    {
        private int threshold;
        private int total;

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
            {
                // Defining arguments of the event that will be fed to the event handler
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.Threshold = threshold;
                args.TimeReached = DateTime.Now;
                // Callin the function containing the event handler
                OnThresholdReached(args);
            }
        }


        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            // Creating the event handler that is based on the delegate defined below
            ThresholdReachedEventHandler handler = ThresholdReached;
            if (handler != null)
            {
                // Assigning the arguments that the event handler will give to its subscribing functions
                handler(this, e);
            }
        }
        // Defining the event handler via the delegate function; it is treated like an "attribute" of the class
        public event ThresholdReachedEventHandler ThresholdReached;
    }

    // Delegate function that is used a a "template" that functions need to fulfill to be able to subscribe to related events
    public delegate void ThresholdReachedEventHandler(Object sender, ThresholdReachedEventArgs e);
}
