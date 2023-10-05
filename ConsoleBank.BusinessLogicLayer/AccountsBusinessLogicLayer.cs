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