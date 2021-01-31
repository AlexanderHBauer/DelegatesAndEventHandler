using System;
using System.Collections.Generic;
using System.Text;

namespace EventTest.Classes
{
    // Defining the arguments our event can relay to its subscribed functions
    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}
