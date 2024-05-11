using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodJOB
{
    class Company
    {
        string accountID = "";
        string name = "";
        string phone = "";
        string address = "";
        string email = "";
        string vpdd = "";
        string ceoName = "";
        string? gpkdName;
        byte[]? gpkdContent;
        string vatID = "";
        string introduce = "";
        int like;
        string avtName = "";
        byte[]? avtContent;

        public Company(string accountID, string name, string phone, string address, string email, string vpdd, string ceoName, string? gpkdName, byte[]? gpkdContent, string vatID, string introduce, int like, string avtName, byte[] avtContent)
        {
            AccountID = accountID;
            Name = name;
            Phone = phone;
            Address = address;
            Email = email;
            Vpdd = vpdd;
            CeoName = ceoName;
            GpkdName = gpkdName;
            GpkdContent = gpkdContent;
            VatID = vatID;
            Introduce = introduce;
            Like = like;
            AvtName = avtName;
            AvtContent = avtContent;
        }

        public Company() { }

        public string AccountID { get => accountID; set => accountID = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string Vpdd { get => vpdd; set => vpdd = value; }
        public string CeoName { get => ceoName; set => ceoName = value; }
        public string? GpkdName { get => gpkdName; set => gpkdName = value; }
        public byte[]? GpkdContent { get => gpkdContent; set => gpkdContent = value; }
        public string VatID { get => vatID; set => vatID = value; }
        public string Introduce { get => introduce; set => introduce = value; }
        public int Like { get => like; set => like = value; }
        public string AvtName { get => avtName; set => avtName = value; }
        public byte[]? AvtContent { get => avtContent; set => avtContent = value; }
    }
}
