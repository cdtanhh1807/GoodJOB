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
    internal class PostDAO
    {
        ConnectSql sql = new ConnectSql();

        JobPost? jobPost;

        int id;

        string accountID = "";

        public PostDAO(JobPost jobPost)
        {
            this.jobPost = jobPost;
        }

        public PostDAO(int id)
        {
            this.id = id;
        }

        public PostDAO(string accountID)
        {
            this.accountID = accountID;
        }

        public PostDAO(string accountID, int id)
        {
            this.accountID = accountID;
            this.id = id;
        }

        public bool Post()
        {
            if (sql.Post(jobPost!)) return true;
            return false;
        }

        public bool EditPost()
        {
            if (sql.EditPost(jobPost!)) return true;
            return false;
        }

        public bool ApplyJob(string seekerID, string filePath, byte[] fileBytes)
        {
            if (sql.ApplyJob(id, accountID, seekerID, filePath, fileBytes)) return true;
            return false;
        }

        public string GetJobName()
        {
            return sql.GetJobName(id);
        }

        public bool DeletePost()
        {
            if (sql.DeletePost(id)) return true;
            return false;
        }

        public List<EditPostUC> LoadEditJob()
        {
            List<EditPostUC> list = sql.LoadEditJob(accountID);
            return list;
        }

        public JobPost GetPost()
        {
            JobPost post = sql.GetPost(id);
            return post;
        }
    }
}
