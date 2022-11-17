using KelpBankingApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelpBankingApplication
{
    public class BankTransactionManager
    {
        public void CreateAccount()
        {

            Console.WriteLine("Enter Account Number: ");
            string accountNumber= Console.ReadLine();

            Console.WriteLine("Enter Account Name: ");
            string accountName = Console.ReadLine();

            var accountDetails = new BankAccountDetails();
            accountDetails.AccountNumber = accountNumber;
            accountDetails.AccountName = accountName;
            accountDetails.Balance = 0;

            var bankrepo = new Bankrepo();
            bankrepo.CreateAccount(accountDetails);

            var bankAccountDetails = bankrepo.ShowBalance(accountNumber);
            Console.WriteLine("#########################################################################");
            Console.WriteLine($"Bank Account with Name: {bankAccountDetails.AccountName} and Account Number: {bankAccountDetails.AccountNumber} Created Successfully");
            Console.WriteLine("#########################################################################");
            Console.ReadLine();
        }

        public void DepositAmount()
        {
            Console.WriteLine("Enter Account Number: ");
            string accountNumber = Console.ReadLine();

            Console.WriteLine("Enter the amount you want to deposit : ");
            string depositAmount = Console.ReadLine();
            int inputAmount = Convert.ToInt32(depositAmount);

            var bankrepo = new Bankrepo();
            var bankAccountDetails = bankrepo.ShowBalance(accountNumber);

            var accountDetails = new BankAccountDetails();
            accountDetails.AccountNumber = accountNumber;
            // Add Amount from existing balance
            accountDetails.Balance = bankAccountDetails.Balance + inputAmount;

            bankrepo.UpdateBalanceAmount(accountDetails);

            Console.WriteLine("#########################################################################");
            Console.WriteLine($"Amount: {inputAmount} Deposited in Account Number: {bankAccountDetails.AccountNumber}  Successfully");
            Console.WriteLine("#########################################################################");
            Console.ReadLine();
        }

        public void WithdrawAmount()
        {           

            Console.WriteLine("Enter Account Number: ");
            string accountNumber = Console.ReadLine();

            Console.WriteLine("Enter the amount you want to withdraw: ");
            string withdrawAmount = Console.ReadLine();
            int inputAmount = Convert.ToInt32(withdrawAmount);

            var bankrepo = new Bankrepo();
            var bankAccountDetails = bankrepo.ShowBalance(accountNumber);

            var accountDetails = new BankAccountDetails();
            accountDetails.AccountNumber = accountNumber;
            // Reduce Amount from existing balance
            accountDetails.Balance = Convert.ToInt32(bankAccountDetails.Balance - inputAmount);

            bankrepo.UpdateBalanceAmount(accountDetails);

            Console.WriteLine("#########################################################################");
            Console.WriteLine($"Amount: {inputAmount} withdrawn from Account Number: {bankAccountDetails.AccountNumber}  Successfully");
            Console.WriteLine("#########################################################################");
            Console.ReadLine();
        }

        public void ShowBalance()
        {
            Console.WriteLine("Enter Account Number: ");
            string accountNumber = Console.ReadLine();

            var bankrepo = new Bankrepo();
            var bankAccountDetails = bankrepo.ShowBalance(accountNumber);

            Console.WriteLine("#########################################################################");
            Console.WriteLine($"{bankAccountDetails.AccountName} {bankAccountDetails.Balance}");
            Console.WriteLine("#########################################################################");
            Console.ReadLine();
        }
    }
}
