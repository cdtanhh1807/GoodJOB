using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodJOB
{
    public class Seeker
    {
        string accountID = "";
        string name = "";
        string phone = "";
        string email = "";
        bool sex;
        string major = "";
        string languageDegree = "";
        string birthday = "";
        int like;
        string cvPath = "";
        byte[]? cvBytes;
        string avtName = "";
        byte[]? avtContent;

        public Seeker() { }

        //public Seeker(string accountID, string name, string phone, string email, bool sex, string major, string languageDegree, string birthday, int like)
        //{
        //    AccountID = accountID;
        //    Name = name;
        //    Phone = phone;
        //    Email = email;
        //    Sex = sex;
        //    Major = major;
        //    LanguageDegree = languageDegree;
        //    Birthday = birthday;
        //    Like = like;
        //}

        public Seeker(string accountID, string name, string phone, string email, bool sex, string major, string languageDegree, string birthday, int like, string cvPath, byte[] cvBytes, string avtName, byte[] avtContent)
        {
            AccountID = accountID;
            Name = name;
            Phone = phone;
            Email = email;
            Sex = sex;
            Major = major;
            LanguageDegree = languageDegree;
            Birthday = birthday;
            Like = like;
            CvPath = cvPath;
            CvBytes = cvBytes;
            AvtName = avtName;
            AvtContent = avtContent;
        }

        public Seeker(string accountID, string name, string phone, string email, bool sex, string major, string languageDegree, string birthday, int like)
        {
            AccountID = accountID;
            Name = name;
            Phone = phone;
            Email = email;
            Sex = sex;
            Major = major;
            LanguageDegree = languageDegree;
            Birthday = birthday;
            Like = like;
            CvPath = "";
            CvBytes = null;
            AvtName = "";
            AvtContent = null;
        }

        public string AccountID { get => accountID; set => accountID = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public bool Sex { get => sex; set => sex = value; }
        public string Major { get => major; set => major = value; }
        public string LanguageDegree { get => languageDegree; set => languageDegree = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public int Like { get => like; set => like = value; }
        public string CvPath { get => cvPath; set => cvPath = value; }
        public byte[]? CvBytes { get => cvBytes; set => cvBytes = value; }
        public string AvtName { get => avtName; set => avtName = value; }
        public byte[]? AvtContent { get => avtContent; set => avtContent = value; }
    }
}
