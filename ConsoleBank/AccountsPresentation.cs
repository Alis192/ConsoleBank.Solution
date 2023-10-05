using ConsoleBank.BusinessLogicLayer;
using ConsoleBank.BusinessLogicLayer.BALContracts;
using ConsoleBank.Entities;

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

                Customer cust = customersBLL.GetCustomersByCondition(c => c.CustomerCode == account.CustomerCode).FirstOrDefault();
                accountsLL.AddAccount(account, cust);



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
                    Console.WriteLine($"Account ID : {account.AccountNo}\n");
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
