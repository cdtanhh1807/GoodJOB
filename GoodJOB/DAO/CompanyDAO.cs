using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GoodJOB
{
    internal class CompanyDAO
    {
        ConnectSql sql = new ConnectSql();
        Company? company;
        string accountID = "";

        public CompanyDAO(Company company)
        {
            this.company = company;
        }

        public CompanyDAO(string  accountID)
        {
            this.accountID = accountID;
        }

        public Company? GetInforCompany()
        {
            Company? company = sql.GetInforCompany(accountID);
            return company;
        }

        public bool EditInforCompany()
        {
            if (sql.EditInforCompany(company!)) return true;
            return false;
        }

        public byte[]? DownloadGPKD()
        {
            byte[]? fileContent = sql.DownloadGPKD(accountID);
            return fileContent;
        }

        public string GetNameCompany()
        {
            return sql.GetNameCompany(accountID);
        }

        public bool LikeCompany(int like)
        {
            if (sql.LikeCompany(accountID, like)) return true;
            return false;
        }

        public byte[]? DownloadAvtCompany()
        {
            byte[]? fileContent = sql.DownloadAvtCompany(accountID);
            return fileContent;
        }

        public bool EditInforAvtCompany()
        {
            if (sql.EditInforAvtCompany(company!)) return true;
            return false;
        }

        public bool EditInforGPKDCompany()
        {
            if (sql.EditInforGPKDCompany(company!)) return true;
            return false;
        }

        public bool EditInforNonPicCompany()
        {
            if (sql.EditInforNonPicCompany(company!)) return true;
            return false;
        }
    }
}
