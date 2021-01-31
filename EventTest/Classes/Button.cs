using System;
using System.Collections.Generic;
using System.Text;

namespace EventTest.Classes
{
    class Button
    {
        public string userkey;
        public string secretletter;
        public int attempts = 0;

        public Button(string SecretLetter)
        {
            secretletter = SecretLetter;
        }

      
        public void CheckKey()
        {
            attempts++;
            if (attempts > LetterOptions.letterOptions.Count)
            {
                ThresholdExceededEventArgs e2 = new ThresholdExceededEventArgs();
                e2.userAttempts = attempts;
                OnThresholdExceeded(e2);
            }
            if (userkey == secretletter)
            {
                ButtonFoundEventArgs e = new ButtonFoundEventArgs();
                e.key = secretletter;
                OnCorrectButtonClicked(e);
            }
        }

        public virtual void OnCorrectButtonClicked(ButtonFoundEventArgs e)
        {
            ButtonClickedEventHandler handler = CorrectButtonClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public virtual void OnThresholdExceeded(ThresholdExceededEventArgs e2)
        {
            ExceededThresholdEventHandler handler2 = ExceededThreshold;
            if (handler2 != null)
            {
                handler2(this, e2);
            }
        }

        public event ButtonClickedEventHandler CorrectButtonClicked;
        public event ExceededThresholdEventHandler ExceededThreshold;
    }

    public delegate void ButtonClickedEventHandler(Object sender, ButtonFoundEventArgs e);
    public delegate void ExceededThresholdEventHandler(Object sender, ThresholdExceededEventArgs e);

}
