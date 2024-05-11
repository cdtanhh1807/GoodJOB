using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodJOB
{
    public class JobPostRecrui
    {
        int postID;
        string companyID = "";
        int count;

        JobPostRecrui() { }

        public JobPostRecrui(int postID, string companyID, int count)
        {
            PostID = postID;
            CompanyID = companyID;
            Count = count;
        }

        public int PostID { get => postID; set => postID = value; }
        public string CompanyID { get => companyID; set => companyID = value; }
        public int Count { get => count; set => count = value; }
    }
}
