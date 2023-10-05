using ConsoleBank.DataAccessLayer.DALContracts;
using ConsoleBank.Entities;
using ConsoleBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBank.DataAccessLayer
{
    public class AccountsDataAccessLayer : IAccountDataAccessLayer
    {
        /// <summary>
        /// List of all accounts in current application runtime
        /// </summary>
        private static List<Account> _accounts;


        /// <summary>
        /// Constructor
        /// </summary>
        static AccountsDataAccessLayer()
        {
            _accounts = new List<Account>();
        }


        private List<Account> Accounts { get => _accounts; set => _accounts = value; }




        public Guid AddAccount(Account account)
        {
            try
            {

                account.AccountID = Guid.NewGuid();
                account.Balance = 0;


                Accounts.Add(account);

                return account.AccountID;
            }
            catch (AccountException)
            {
                throw;
            }
            catch (CustomerException)
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
                List<Account> accounts = new List<Account>();

                Accounts.ForEach(account => accounts.Add(account.Clone() as Account));

                return accounts;
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
