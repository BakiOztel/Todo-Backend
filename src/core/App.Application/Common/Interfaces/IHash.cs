using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Application.Common.Interfaces
{
    public interface IHash
    {
        public string Encryption(string pw);
        public string Decryption(string pw);
    }
}
