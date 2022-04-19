using ATM.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.ATMApp
{
    class Entry
    {
        static void Main(string[] args)
        {
            AppScreen.Welcome();
            ATM atmApp = new ATM();
            atmApp.InitializeData();
            atmApp.ChecUserCardNumAndPassword();
            atmApp.Welcome();
            //long cardNumber = Validator.Convert<long>("Your card number");
            //Console.WriteLine($"Your card number is {cardNumber}");

            Utility.PressEnterToContinue();
        }
    }
}
