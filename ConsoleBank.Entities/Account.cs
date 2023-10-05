using ConsoleBank.Entities.Contracts;
using ConsoleBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBank.Entities
{
    public class Account : IAccount, ICloneable
    {
        private Guid _accountID;
        private double _balance;
        private long _customerCode;
        private Customer _customer;


        public Guid AccountID { get => _accountID; set => _accountID = value; }

        public double Balance
        {
            get => _balance;
            set
            {
                if (value >= 0)
                {
                    _balance = value;
                }
                else
                {
                    throw new AccountException("Balance should not be a negative number");
                }
            }
        }

        public long CustomerCode { get => _customerCode; set => _customerCode = value; }

        public Customer Customer { get => _customer; set => _customer = value; }


        public object Clone()
        {
            return new Account() { AccountID = this.AccountID, Balance = this.Balance, CustomerCode = this.CustomerCode, Customer = this.Customer };
        }
    }

}
