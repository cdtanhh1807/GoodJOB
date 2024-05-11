using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodJOB
{
    class Message
    {
        string companyID = "";
        string seekerID = "";
        string role = "";
        string mess = "";
        DateTime time;

        public Message(string companyID, string seekerID, string role, string mess, DateTime time)
        {
            CompanyID = companyID;
            SeekerID = seekerID;
            Role = role;
            Mess = mess;
            Time = time;
        }

        public string CompanyID { get => companyID; set => companyID = value; }
        public string SeekerID { get => seekerID; set => seekerID = value; }
        public string Role { get => role; set => role = value; }
        public string Mess { get => mess; set => mess = value; }
        public DateTime Time { get => time; set => time = value; }
    }
}
