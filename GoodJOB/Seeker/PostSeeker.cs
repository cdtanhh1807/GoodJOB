using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodJOB
{
    public class PostSeeker
    {
        string job = "";
        string field = "";
        string time = "";
        string exp = "";
        string salary = "";
        string skill = "";
        string accountID = "";

        public PostSeeker() { }

        public PostSeeker(string job, string field, string time, string exp, string salary, string skill, string accountID)
        {
            Job = job;
            Field = field;
            Time = time;
            Exp = exp;
            Salary = salary;
            Skill = skill;
            AccountID = accountID;
        }

        public string Job { get => job; set => job = value; }
        public string Field { get => field; set => field = value; }
        public string Time { get => time; set => time = value; }
        public string Exp { get => exp; set => exp = value; }
        public string Salary { get => salary; set => salary = value; }
        public string Skill { get => skill; set => skill = value; }
        public string AccountID { get => accountID; set => accountID = value; }
    }
}
