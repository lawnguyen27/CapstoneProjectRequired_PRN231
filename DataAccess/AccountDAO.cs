using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        public static readonly object instanceLock = new object();
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Account> GetAccounts()
        {
            var accounts = new List<Account>();
            try
            {
                using var context = new CPRContext();
                accounts = context.Accounts.Include(a => a.Role).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accounts;
        }

        public int GetAccountIdByCode(string? code)
        {
            int id;
            Account account = null;
            try
            {
                using var context = new CPRContext();
                account = context.Accounts.SingleOrDefault(m => m.Code.Equals(code));
                if (account != null)
                {
                    id = account.Id;
                }
                else id = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return id;
        }

        public void Create(Account account)
        {
            try
            {
                Account _account = new Account();
                _account.Id = GetAccountIdByCode(account.Code);
                if (_account.Id == 0)
                {
                    using var context = new CPRContext();
                    context.Accounts.Add(account);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Account is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
