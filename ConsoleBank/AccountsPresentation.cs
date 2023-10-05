using ConsoleBank.BusinessLogicLayer;
using ConsoleBank.BusinessLogicLayer.BALContracts;
using ConsoleBank.Entities;
using ConsoleBank.Exceptions;

namespace ConsoleBank.Presentation
{
    static class AccountsPresentation
    {
        internal static void AddAccount()
        {
            try
            {
                Account account = new Account();

                //read all details from the user
                Console.WriteLine("\n********ADD ACCOUNT*************");
                Console.Write("Enter Customer Code: ");
                string customerCode = Console.ReadLine();
                account.CustomerCode = (long)Convert.ToDouble(customerCode);

                IAccountsBusinessLogicLayer accountsLL = new AccountsBusinessLogicLayer();
                ICustomersBusinessLogicLayer customersBLL = new CustomersBusinessLogicLayer();
                
                //Retrieving specific customer from List
                Customer? cust = customersBLL.GetCustomersByCondition(c => c.CustomerCode == account.CustomerCode).FirstOrDefault();
                if (cust == null)
                    throw new CustomerException("Customer is not found");

                accountsLL.AddAccount(account, cust);

                Console.WriteLine("Account is added!");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void ViewAccounts()
        {
            try
            {
                Console.WriteLine("\n**********ALL CUSTOMERS*************");
                IAccountsBusinessLogicLayer accountsBLL = new AccountsBusinessLogicLayer();
                List<Account> accounts = accountsBLL.GetAccounts();

                accounts.ForEach(account =>
                {
                    Console.WriteLine($"Account Customer Code: {account.CustomerCode}");
                    Console.WriteLine($"Account Holder Name: {account.Customer.CustomerName}");
                    Console.WriteLine($"Account ID : {account.AccountNo}");
                    Console.WriteLine($"Balance: ${account.Balance}\n");
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
    }

}
