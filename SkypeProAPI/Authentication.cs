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
            string url = "https://login.live.com/RST.srf";
            string content = 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.method = "POST";
            request.ContentType = "application/xml";
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)";

            request.Timeout = 5000;
        }
        public void GetSkypeToken(SecurityToken){
            
        }
    }
}