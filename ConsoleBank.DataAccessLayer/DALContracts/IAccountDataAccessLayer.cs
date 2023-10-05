using ConsoleBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBank.DataAccessLayer.DALContracts
{
    /// <summary>
    /// Interface that represents customers data access layer
    /// </summary>
    public interface IAccountDataAccessLayer
    {
        /// <summary>
        /// Returns the list of all accounts
        /// </summary>
        /// <returns>List of all Accounts</returns>
        List<Account> GetAccounts();

        /// <summary>
        /// Adds a Customer account to the Accounts list
        /// </summary>
        /// <param name="account"></param>
        /// <returns>Retunrs true or false depending of success status</returns>
        Guid AddAccount(Account account);

        /// <summary>
        /// Deletes a customer account
        /// </summary>
        /// <param name="account"></param>
        /// <returns>Retunrs true or false depending of success status</returns>
        bool DeleteAccount(Account account);


        /// <summary>
        /// Updates an account's balance
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns>A new balance after the change</returns>
        double UpdateBalance(Guid accountID, double balance);


    }

}
