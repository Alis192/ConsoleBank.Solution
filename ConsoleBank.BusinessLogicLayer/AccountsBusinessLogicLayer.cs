using ConsoleBank.BusinessLogicLayer.BALContracts;
using ConsoleBank.DataAccessLayer;
using ConsoleBank.DataAccessLayer.DALContracts;
using ConsoleBank.Entities;
using ConsoleBank.Exceptions;

namespace ConsoleBank.BusinessLogicLayer
{
    public class AccountsBusinessLogicLayer : IAccountsBusinessLogicLayer
    {

        private IAccountDataAccessLayer _dal;

        public AccountsBusinessLogicLayer()
        {
            _dal = new AccountsDataAccessLayer();
        }


        private IAccountDataAccessLayer AccountDataAccessLayer
        {
            get => _dal;
            set => _dal = value;
        }

        public Guid AddAccount(Account account, Customer customer)
        {
            try
            {
                account.Customer = customer;

                List<Account> accounts = AccountDataAccessLayer.GetAccounts();

                //Determining last used Account Code
                long maxAccCode = 0;
                foreach(var acc in accounts)
                {
                    if (acc.AccountNo > maxAccCode)
                    {
                        maxAccCode = acc.AccountNo;
                    }

                }

                //
                if (accounts.Count > 0)
                {
                    account.AccountNo = maxAccCode + 1;
                } 
                else
                {
                    account.AccountNo = ConsoleBank.Configuration.Settings.BaseAccountNo + 1;
                }


                return AccountDataAccessLayer.AddAccount(account);
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAccounts()
        {
            try
            {
                return AccountDataAccessLayer.GetAccounts();
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public double UpdateBalance(Guid accountID, double balance)
        {
            throw new NotImplementedException();
        }
    }

}