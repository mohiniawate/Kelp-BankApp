using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelpBankingApplication
{
    internal class Program
    {
        public static void BankingMenu()
        {

            Console.WriteLine("Enter 1 to Create account, 2 to Deposit amount, 3 to Withdraw amount, 4 to Show balance");
            string StringMenu = Console.ReadLine();
            int NextChoice = Convert.ToInt32(StringMenu);
            var bankTransactionManager = new BankTransactionManager();

            switch (NextChoice)
            {
                case 1:
                    bankTransactionManager.CreateAccount();
                    break;
                case 2:
                    bankTransactionManager.DepositAmount();
                    break;
                case 3:
                    bankTransactionManager.WithdrawAmount();
                    break;
                case 4:
                    bankTransactionManager.ShowBalance();
                    break;
            }
        }
       

        static void Main(string[] args)
        {
            BankingMenu();

        }
    }
}

