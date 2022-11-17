using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelpBankingApplication.Repository
{
    public class Bankrepo
    {

        public void CreateAccount(BankAccountDetails accountDetails)
        {

            string connectionString = "Data Source=DESKTOP-353T3MA;Initial Catalog=KelpBank;User ID=sa;Password=mohini420";
            string queryString = "INSERT INTO BankAccounts (AccountNumber, AccountName, Balance) VALUES(@AccountNumber,@AccountName,@Balance)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {

                    command.Parameters.Add("@AccountNumber", SqlDbType.VarChar, 100).Value = accountDetails.AccountNumber;
                    command.Parameters.Add("@AccountName", SqlDbType.Char, 100).Value = accountDetails.AccountName;
                    command.Parameters.Add("@Balance", SqlDbType.Int).Value = accountDetails.Balance;

                    // open connection, execute INSERT, close connection
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void UpdateBalanceAmount(BankAccountDetails accountDetails)
        {
            string connectionString = "Data Source=DESKTOP-353T3MA;Initial Catalog=KelpBank;User ID=sa;Password=mohini420";
            string queryString = "UPDATE BankAccounts SET Balance = @Balance WHERE AccountNumber = @AccountNumber";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@AccountNumber", SqlDbType.VarChar, 100).Value = accountDetails.AccountNumber;
                    command.Parameters.Add("@Balance", SqlDbType.Int).Value = accountDetails.Balance;

                    // open connection, execute UPDATE, close connection
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public BankAccountDetails ShowBalance(string accountNumber)
        {
            var accountDetails = new BankAccountDetails();

            string connectionString = "Data Source=DESKTOP-353T3MA;Initial Catalog=KelpBank;User ID=sa;Password=mohini420";
            string queryString = "select AccountNumber, AccountName, Balance from BankAccounts WHERE AccountNumber=@AccountNumber";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Parameters.Add("@AccountNumber", SqlDbType.VarChar, 100).Value = accountNumber;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        accountDetails.AccountNumber = Convert.ToString(reader.GetValue(reader.GetOrdinal("AccountNumber")));
                        accountDetails.AccountName = Convert.ToString(reader.GetValue(reader.GetOrdinal("AccountName")));
                        accountDetails.Balance = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Balance")));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return accountDetails;
            }

        }
    }
}
