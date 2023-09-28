using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        public void Create(Account account) => AccountDAO.Instance.Create(account);

        public IEnumerable<Account> GetAccounts() => AccountDAO.Instance.GetAccounts();
    }
}
