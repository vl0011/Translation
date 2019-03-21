using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naver_API_KEY
{
    public static class API_KEY
    {
        private static Naver_API_KEY_Data key1 = new Naver_API_KEY_Data("eBvFCejk4ZxPNuHfen2U", "_md0SVfUfo");
        public static Naver_API_KEY_Data GetNaverAPI_KEY()
        {
            return key1;
        }
    }

    public class Naver_API_KEY_Data
    {
        internal Naver_API_KEY_Data(string id, string secret)
        {
            client_ID = id;
            client_Secret = secret;
        }
        private string client_ID;
        private string client_Secret;

        public string Client_ID { get => client_ID; }
        public string Client_Secret { get => client_Secret; }
    }
}
