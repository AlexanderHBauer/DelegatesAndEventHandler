using System;
using NewEventTest.Classes;

namespace NewEventTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the correct passwort (Hint: It rhymes with \'best\'!");
            string userPW = "";

            string secretPW = "test";
            PasswordChecker checker = new PasswordChecker(secretPW);
            checker.SubmittedCorredPassphrase += c_CorrectPW;

            while (userPW != secretPW)
            {
                userPW = Console.ReadLine();
                checker.CheckPassword(userPW);
            }
        }

        static void c_CorrectPW(Object sender, PassphraseEventArg e)
        {
            Console.WriteLine("Congratulations, you entered the correct password at {0}", e.time);
        }
    }


}
