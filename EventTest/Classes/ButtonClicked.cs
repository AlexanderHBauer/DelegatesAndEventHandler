using System;
using System.Collections.Generic;
using System.Text;

namespace EventTest.Classes
{
    public class ButtonFoundEventArgs : EventArgs
    {
        public int attempts { get; set; }
        public string key { get; set; }
    }    
}
