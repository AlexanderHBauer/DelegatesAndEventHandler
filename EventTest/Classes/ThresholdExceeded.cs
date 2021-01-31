using System;
using System.Collections.Generic;
using System.Text;

namespace EventTest.Classes
{
    public class ThresholdExceededEventArgs : EventArgs
    {
        public int userAttempts;
        public int maxAttempts = LetterOptions.letterOptions.Count;
    }
}
