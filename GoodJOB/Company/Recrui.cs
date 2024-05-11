using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodJOB
{
    public class Recrui
    {
        int postID;
        string companyID = "";
        string seekerID = "";
        string fileName = "";
        byte[]? fileContent;
        bool? result;

        public Recrui() { }

        public Recrui(int postID, string companyID, string seekerID, string fileName, byte[] fileContent, bool? result)
        {
            PostID = postID;
            CompanyID = companyID;
            SeekerID = seekerID;
            FileName = fileName;
            FileContent = fileContent;
            this.result = result;
            Result = result;
        }

        public int PostID { get => postID; set => postID = value; }
        public string CompanyID { get => companyID; set => companyID = value; }
        public string SeekerID { get => seekerID; set => seekerID = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public byte[]? FileContent { get => fileContent; set => fileContent = value; }
        public bool? Result { get => result; set => result = value; }
    }
}
