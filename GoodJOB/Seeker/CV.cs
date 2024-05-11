using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodJOB
{
    class CV
    {
        string filePath = "";
        byte[]? fileBytes;

        public string FilePath { get => filePath; set => filePath = value; }
        public byte[]? FileBytes { get => fileBytes; set => fileBytes = value; }

        public CV(string filePath, byte[]? fileBytes)
        {
            FilePath = filePath;
            FileBytes = fileBytes;
        }
    }
}
