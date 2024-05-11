using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodJOB.Home
{
    public class Account
    {
        private string userName = "";
        private string pass = "";
        private string role = "";
        private string accountID = "";

        public string UserName { get => userName; set => userName = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Role { get => role; set => role = value; }
        public string AccountID { get => accountID; set => accountID = value; }

        public Account(string userName, string pass, string role, string accountID)
        {
            UserName = userName;
            Pass = pass;
            Role = role;
            AccountID = accountID;
        }

        public Account(string userName, string pass)
        {
            UserName = userName;
            Pass = pass;
        }

        public Account() { }
    }
}
