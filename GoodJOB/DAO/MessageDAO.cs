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
    internal class MessageDAO
    {
        ConnectSql sql = new ConnectSql();

        Message? message;

        string companyID = "";

        string seekerID = "";

        public MessageDAO(Message? message)
        {
            this.message = message;
        }

        public MessageDAO(string  companyID, string seekerID)
        {
            this.companyID = companyID;
            this.seekerID = seekerID;
        }

        public bool SendMessage()
        {
            if (sql.SendMessage(message!.CompanyID, message!.SeekerID, message.Role, message.Mess, message.Time)) return true;
            return false;
        }

        public List<Message> LoadMessage()
        {
            List<Message> list = sql.LoadMessage(companyID, seekerID);
            return list;
        }
    }
}
