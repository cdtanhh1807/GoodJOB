using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodJOB
{
    public class Exp
    {
        private string accountID = "";
        private string jobName = "";
        private string workTime = "";
        private string companyName = "";
        private string description = "";

        public Exp() { }

        public Exp(string accountID, string jobName, string workTime, string companyName, string description)
        {
            AccountID = accountID;
            JobName = jobName;
            WorkTime = workTime;
            CompanyName = companyName;
            Description = description;
        }

        public string AccountID { get => accountID; set => accountID = value; }
        public string JobName { get => jobName; set => jobName = value; }
        public string WorkTime { get => workTime; set => workTime = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string Description { get => description; set => description = value; }
    }
}
