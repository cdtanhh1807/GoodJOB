using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodJOB
{
    public class JobPost
    {
        string jobName = "";
        string field = "";
        string workingTime = "";
        string typeOfWork = "";
        string salary = "";
        string exp = "";
        string skill = "";
        string description = "";
        int numOfRecrui;
        DateTime dateOfPost;
        string accountID = "";
        int postID;
        DateTime postingDate;
        string welfare = "";

        public JobPost() { }

        public JobPost(string jobName, string field, string workingTime, string typeOfWork, string salary, string exp, string skill, string description, int numOfRecrui, DateTime dateOfPost, string accountID, int postID, DateTime postingDate, string welfare)
        {
            JobName = jobName;
            Field = field;
            WorkingTime = workingTime;
            TypeOfWork = typeOfWork;
            Salary = salary;
            Exp = exp;
            Skill = skill;
            Description = description;
            NumOfRecrui = numOfRecrui;
            DateOfPost = dateOfPost;
            AccountID = accountID;
            PostID = postID;
            PostingDate = postingDate;
            Welfare = welfare;
        }

        public string JobName { get => jobName; set => jobName = value; }
        public string Field { get => field; set => field = value; }
        public string WorkingTime { get => workingTime; set => workingTime = value; }
        public string TypeOfWork { get => typeOfWork; set => typeOfWork = value; }
        public string Salary { get => salary; set => salary = value; }
        public string Exp { get => exp; set => exp = value; }
        public string Skill { get => skill; set => skill = value; }
        public string Description { get => description; set => description = value; }
        public int NumOfRecrui { get => numOfRecrui; set => numOfRecrui = value; }
        public DateTime DateOfPost { get => dateOfPost; set => dateOfPost = value; }
        public string AccountID { get => accountID; set => accountID = value; }
        public int PostID { get => postID; set => postID = value; }
        public DateTime PostingDate { get => postingDate; set => postingDate = value; }
        public string Welfare { get => welfare; set => welfare = value; }
    }
}
