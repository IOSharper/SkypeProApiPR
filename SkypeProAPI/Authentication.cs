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

        public void GetSecurityToken(string login, string password){
            string url = "https://login.live.com/RST.srf";
            string content = @"<Envelope xmlns=""http://schemas.xmlsoap.org/soap/envelope/""
   xmlns:wsse=""http://schemas.xmlsoap.org/ws/2003/06/secext""
   xmlns:wsp=""http://schemas.xmlsoap.org/ws/2002/12/policy""
   xmlns:wsa=""http://schemas.xmlsoap.org/ws/2004/03/addressing""
   xmlns:wst=""http://schemas.xmlsoap.org/ws/2004/04/trust""
   xmlns:ps=""http://schemas.microsoft.com/Passport/SoapServices/PPCRL"">
   <Header>
       <wsse:Security>
           <wsse:UsernameToken Id=""user"">
               <wsse:Username>" + login + @"</wsse:Username>
               <wsse:Password>" + password + @"</wsse:Password>
           </wsse:UsernameToken>
       </wsse:Security>
   </Header>
   <Body>
       <ps:RequestMultipleSecurityTokens Id=""RSTS"">
           <wst:RequestSecurityToken Id=""RST0"">
               <wst:RequestType>http://schemas.xmlsoap.org/ws/2004/04/security/trust/Issue</wst:RequestType>
               <wsp:AppliesTo>
                   <wsa:EndpointReference>
                       <wsa:Address>wl.skype.com</wsa:Address>
                   </wsa:EndpointReference>
               </wsp:AppliesTo>
               <wsse:PolicyReference URI=""MBI_SSL""></wsse:PolicyReference>
           </wst:RequestSecurityToken>
       </ps:RequestMultipleSecurityTokens>
   </Body>
</Envelope>";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/xml";
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)";

            byte[] requestBytes = new ASCIIEncoding().GetBytes(content);
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(requestBytes, 0, requestBytes.Length);
            requestStream.Close();            

            request.Timeout = 5000;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            var encoding = ASCIIEncoding.ASCII;
            if(response.StatusCode == HttpStatusCode.OK)
            {
                using (var reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    string responseText = reader.ReadToEnd();
                    MSSecurity = responseText;
                }
                response.Close();
            }
            else
            {
                response.Close();
            }
        }
        public void GetSkypeToken(string SecurityToken){

        }
    }
}