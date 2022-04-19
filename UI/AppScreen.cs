using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ATM.Domain.Entities;
using System.Threading;

namespace ATM.UI
{
    public static class AppScreen
    {
        internal static void Welcome()
        {

            Console.Clear();
            Console.Title = "My ATM";
            Console.ForegroundColor = ConsoleColor.Blue;


            Console.WriteLine("\n\n-------------Welcome to my ATM !-------------\n\n");
            Console.WriteLine("Please insert your ATM Card");
            Console.WriteLine("Note: Actual ATM Machine will accept and validate" +
                "a physical ATM Card, read the card number and Validate it.");
            Utility.PressEnterToContinue();
        }

        internal static UserAccount UserLoginForm()
        {
            UserAccount tempUserAccount = new UserAccount();

            tempUserAccount.CardNumber = Validator.Convert<long>("Your card number.");
            tempUserAccount.CardPin = Convert.ToInt32(Utility.GetSecretInput("Enter your card PIN"));
            return tempUserAccount;
        }

        internal static void LoginProgress()
        {
            Console.WriteLine("\nChecking card number and PIN...");
            Utility.PrintDotAnimation();
        }

        internal static void PrintLockScreen()
        {
            Console.Clear();
            Utility.PrintMessage("Your account is locked. Please go to the nearest branch to unlock your account. Thank You.", true);
            Utility.PressEnterToContinue();
            Environment.Exit(1);
        }



    }
}
