using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Infraestructure.Crosscutting
{
    public static class ImageProces
    {
        public static string GetImage(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Credentials = System.Net.CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return url;
            }
            catch (Exception ex)
            {
                return "assets/images/no-photos.svg";
            }
        }
    }
}
