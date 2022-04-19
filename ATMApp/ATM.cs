using ATM.Domain.Entities;
using ATM.Domain.Interfaces;
using ATM.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ATM
{
     public class ATM : IUserLogin
    {
        private List<UserAccount> userAccountList;
        private UserAccount selectedAccount;

       
        public void InitializeData()
        {
            userAccountList = new List<UserAccount>
            {
                new UserAccount{Id =1, FullName = "Maureen Perez", AccountNumber =123456, CardNumber = 321321, CardPin = 123123, AccountBalance = 6000.00m,IsLocked=false},
                new UserAccount{Id =2, FullName = "Lisa Larry", AccountNumber =456789, CardNumber = 654654, CardPin = 456456, AccountBalance = 5000.00m,IsLocked=false},
                new UserAccount{Id =3, FullName = "Olivia Olive", AccountNumber =123444, CardNumber = 987987, CardPin = 789789, AccountBalance = 4000.00m,IsLocked=true}
            };
        }

        public void ChecUserCardNumAndPassword()
        {
            bool isCorrectLogin = false;
            while (isCorrectLogin == false)
            {
                UserAccount inputAccount = AppScreen.UserLoginForm();
                AppScreen.LoginProgress();
                foreach(UserAccount account in userAccountList)
                {
                    selectedAccount = account;
                    if(inputAccount.CardNumber.Equals(selectedAccount.CardNumber))
                    {
                        selectedAccount.TotalLogin++;
                        if(inputAccount.CardPin.Equals(selectedAccount.CardPin))
                        {
                            selectedAccount = account;
                            if(selectedAccount.IsLocked || selectedAccount.TotalLogin > 3)
                            {
                                AppScreen.PrintLockScreen();

                            }
                            else
                            {
                                selectedAccount.TotalLogin = 0;
                                isCorrectLogin = true;
                                break;
                            }
                        }
                    }
                    if (isCorrectLogin == false)
                    {
                        Utility.PrintMessage("\nInvalid Card Number or PIN", false);
                        selectedAccount.IsLocked = selectedAccount.TotalLogin == 3;
                        if (selectedAccount.IsLocked)
                        {
                            AppScreen.PrintLockScreen();
                        }
                    }
                    Console.Clear();
                }
            }
           
        }


        public void Welcome()
        {
            Console.WriteLine($"Welcome Back, {selectedAccount.FullName}");
        }
        

    }
}
