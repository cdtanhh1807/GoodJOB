using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodJOB
{
    internal class Interview
    {
        DateTime interviewDay;
        string address = "";
        int postID;
        string seekerID = "";

        public Interview(DateTime interviewDay, string address, int postID, string seekerID)
        {
            InterviewDay = interviewDay;
            Address = address;
            PostID = postID;
            SeekerID = seekerID;
        }

        public DateTime InterviewDay { get => interviewDay; set => interviewDay = value; }
        public string Address { get => address; set => address = value; }
        public int PostID { get => postID; set => postID = value; }
        public string SeekerID { get => seekerID; set => seekerID = value; }
    }
}
