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
    internal class SeekerDAO
    {
        ConnectSql sql = new ConnectSql();

        Seeker? seeker;

        string accountID = "";

        public SeekerDAO(Seeker seeker)
        {
            this.seeker = seeker;
        }

        public SeekerDAO(string accountID)
        {
            this.accountID = accountID;
        }

        public SeekerDAO() { }

        public bool EditInforSeeker()
        {
            if (sql.EditInforSeeker(seeker!)) return true;
            return false;
        }

        public List<JobPostUC> LoadJobPost(ref HashSet<string> hsField)
        {
            hsField.Add("Lĩnh vực");
            List<JobPostUC> list = sql.LoadJobPost(ref hsField, accountID);
            return list;
        }

        public List<JobPostUC> SearchJob(string txbJobName, string cbbField, string cbbExp, string cbbSalary, string cbbTypeOfWork, string cbbLocation)
        {
            List<JobPostUC> list = sql.SearchJob(accountID, txbJobName, cbbField, cbbExp, cbbSalary, cbbTypeOfWork, cbbLocation);
            return list;
        }

        public Seeker? GetInforSeeker()
        {
            Seeker? seeker = sql.GetInforSeeker(accountID);
            return seeker;
        }

        public bool LikeSeeker(int like)
        {
            if (sql.LikeSeeker(accountID, like)) return true;
            return false;
        }

        public List<TopSeekerUC> LoadTopSeeker(bool check)
        {
            string role = "";
            if (check == true) role = "Company";
            else role = "Seeker";
            List<TopSeekerUC> list = sql.LoadTopSeeker(role);
            return list;
        }

        public byte[]? DownloadCVSeeker()
        {
            byte[]? fileContent = sql.DownloadCVSeeker(accountID);
            return fileContent;
        }

        public byte[]? DownloadAvtSeeker()
        {
            byte[]? fileContent = sql.DownloadAvtSeeker(accountID);
            return fileContent;
        }

        public bool EditInforAvtSeeker()
        {
            if (sql.EditInforAvtSeeker(seeker!)) return true;            
            return false;
        }

        public bool EditInforCVSeeker()
        {
            if (sql.EditInforCVSeeker(seeker!)) return true;
            return false;
        }

        public bool EditInforNonPicSeeker()
        {
            if (sql.EditInforNonPicSeeker(seeker!)) return true;
            return false;
        }
    }
}
