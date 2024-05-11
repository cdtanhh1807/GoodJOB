using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GoodJOB.Home
{
    class AccountDAO
    {
        ConnectSql cnSql = new ConnectSql();
        Account? account;

        public AccountDAO(Account account)
        {
            this.account = account;
        }

        public bool Login(ref Account account, ref string infor)
        {
            if (cnSql.ExcuLogin(ref account, "SELECT * FROM dbo.Account WHERE UserName = @userName AND Pass = @pass", ref infor)) return true;
            return false;
        }

        public bool SignUp(Account account)
        {
            if (cnSql.ExcuSignUp(account, "INSERT dbo.Account VALUES(@userName, @pass, @role, @accountID)")) return true;
            return false;
        }

        public bool AddCompany()
        {
            if (cnSql.AddCompany(account!.AccountID)) return true;
            return false;
        }

        public bool AddSeeker()
        {
            if (cnSql.AddSeeker(account!.AccountID)) return true;
            return false;
        }
    }
}
