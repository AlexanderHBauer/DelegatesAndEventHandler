using System;
using System.Collections.Generic;
using System.Text;

namespace NewEventTest.Classes
{
    public class PasswordChecker
    {  
        private readonly string phrase;

        public PasswordChecker(string Phrase)
        {
            phrase = Phrase;
        }

        public void CheckPassword(string userPW)
        {
            if (userPW == phrase)
            {
                PassphraseEventArg args = new PassphraseEventArg();
                args.time = DateTime.Now;
                OnSubmitCorrectPW(args);
            }
        }

        public virtual void OnSubmitCorrectPW(PassphraseEventArg e)
        {
            SubmittedCorrectPassphraseEventHandler handler = SubmittedCorredPassphrase;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event SubmittedCorrectPassphraseEventHandler SubmittedCorredPassphrase;
        
    }

    public delegate void SubmittedCorrectPassphraseEventHandler(object sender, PassphraseEventArg e);
}
