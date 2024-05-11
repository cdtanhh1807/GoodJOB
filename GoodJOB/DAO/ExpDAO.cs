using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GoodJOB.DAO
{
    internal class ExpDAO
    {
        ConnectSql sql = new ConnectSql();
        SeekerInforUC? seekerInforUC;
        string accountID = "";
        Exp? exp;
        public ExpDAO(string accountID, SeekerInforUC seekerInforUC)
        {
            this.accountID = accountID;
            this.seekerInforUC = seekerInforUC;
        }

        public List<ExpUC> LoadExp()
        {
            List<ExpUC> list = sql.LoadExp(accountID, seekerInforUC!);
            return list;
        }

        public ExpDAO(Exp exp)
        {
            this.exp = exp;
        }

        public bool MinusExp()
        {
            if (sql.MinusExp(exp!)) return true;
            return false;
        }

        public bool AddExp()
        {
            if (sql.AddExp(exp!)) return true;
            return false;
        }

        public bool EditExp(string tempJobName, string tempCompanyName, string tempWorkTime, string tempDescription)
        {
            if (sql.EditExp(exp!, tempJobName, tempCompanyName, tempWorkTime, tempDescription)) return true;
            return false;
        }
    }
}
