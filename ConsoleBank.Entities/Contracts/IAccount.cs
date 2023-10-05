using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBank.Entities.Contracts
{
    /// <summary>
    /// Represents interface for Customer accounts entity
    /// </summary>
    public interface IAccount
    {
        #region Properties


        Guid AccountID { get; set; }
        double Balance { get; set; }
        long CustomerCode { get; set; }
        Customer Customer { get; set; }

        #endregion
    }
}
