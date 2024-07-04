using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace SkypeProAPI
{
    public struct Credentials
    {
        public string MSSecurity;
        public string SkypeToken;
        public string RegistrationToken;

        public void GetSecurityToken(login, password){
            string url = "https://login.live.com/RST.srf"
        }
        public void GetSkypeToken(SecurityToken){
            
        }
    }
}