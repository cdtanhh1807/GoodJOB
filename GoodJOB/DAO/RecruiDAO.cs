using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GoodJOB.Home;

namespace GoodJOB.DAO
{
    internal class RecruiDAO
    {
        ConnectSql sql = new ConnectSql();

        Recrui? recrui;

        string companyID = "";

        string seekerID = "";

        int id;

        Account? account;

        public RecruiDAO(Recrui recrui)
        {
            this.recrui = recrui;
        }

        public RecruiDAO(string companyID)
        {
            this.companyID = companyID;
        }

        public RecruiDAO(string seekerID, bool seeker)
        {
            this.seekerID = seekerID;
        }

        public RecruiDAO(int id)
        {
            this.id = id;
        }

        public RecruiDAO(Account account)
        {
            this.account = account;
        }

        public byte[]? DownLoadCV()
        {
            byte[]? fileContent = sql.DownLoadCV(recrui!.PostID, recrui.SeekerID);
            return fileContent;
        }

        public List<RecruiUC> LoadJobPostRecrui()
        {
            List<RecruiUC> list = sql.LoadJobPostRecrui(companyID);
            return list;
        }

        public List<ResumeApplyUC> LoadRecrui()
        {
            List<ResumeApplyUC> list = sql.LoadRecrui(id);
            return list;
        }

        public bool Interview(string result, DateTime dt, string address)
        {
            if (sql.Interview(recrui!, result, dt, address)) return true;
            return false;
        }

        public Interview? GetInterview()
        {
            return sql.GetInterview(recrui!);
        }

        public bool Reply(string result)
        {
            if (sql.Reply(recrui!, result)) return true;
            return false;
        }

        public List<ManageRecruiUC> LoadManegeRecrui()
        {
            List<ManageRecruiUC> list = sql.LoadManegeRecrui(account!);
            return list;
        }

        public List<ManageRecruiUC> LoadManegeRecruiNon()
        {
            List<ManageRecruiUC> list = sql.LoadManegeRecruiNon(account!);
            return list;
        }

        public List<ItemSeekerChatUC> LoadSeekerItemChat()
        {
            List<ItemSeekerChatUC> list = sql.LoadSeekerItemChat(companyID);
            return list;
        }

        public List<ItemCompanyChatUC> LoadCompanyItemChat()
        {
            List<ItemCompanyChatUC> list = sql.LoadCompanyItemChat(seekerID);
            return list;
        }
    }
}
