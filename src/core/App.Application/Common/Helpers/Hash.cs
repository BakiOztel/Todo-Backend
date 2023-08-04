using App.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;

namespace App.Application.Common.Helpers
{
    public class Hash : IHash
    {

        private const string key = "deneme";
        private readonly IDataProtectionProvider _dataProtectionProvider;
        
        

        public Hash(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtectionProvider = dataProtectionProvider;
        }

        public string Encryption(string pw)
        {
            var protector = _dataProtectionProvider.CreateProtector(key);
            return protector.Protect(pw);
        }

        public string Decryption(string pw)
        {
            var protector = _dataProtectionProvider.CreateProtector(key);
            return protector.Unprotect(pw);
        }
    }
}
