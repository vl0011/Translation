using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Naver_API_KEY;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Translation_API.Papago
{
    public delegate void PapagoTranslationEventHandler(object sender, PapagoTranslationEventArgs e);
    public enum Language { ko, en }
    public enum Translate_mode { NMT, SMT }
    public class Papago
    {
        JObject resultText;

        private Thread translationThread; // 쓰레드를 사용하여 나름 비동기로 처리한다.

        private event PapagoTranslationEventHandler CompletedTranslationEvent; 
        private event PapagoTranslationEventHandler FailedTranslationEvent;

        private StreamReader reader;
        private Stream requestStream, responseStream;
        private HttpWebResponse response;
        private byte[] byteDataParams;

        private string client_id;
        private string client_secret;

        private Language source;
        private Language target;
        private string text;

        bool isTasking = false;

        private readonly Dictionary<Language, string> LanguageCode = new Dictionary<Language, string>()
        {
            {Language.ko, "ko" }, {Language.en, "en"}
        };
        private readonly string nmt_url = "https://openapi.naver.com/v1/papago/n2mt";
        private readonly string smt_url = "https://openapi.naver.com/v1/language/translate";
        Translate_mode mode = Translate_mode.NMT;

        public bool IsTasking { get => isTasking; set => isTasking = value; }

        public Papago()
        {
            client_id = API_KEY.GetNaverAPI_KEY().Client_ID;
            client_secret = API_KEY.GetNaverAPI_KEY().Client_Secret;
        }
        public Papago(Translate_mode mode)
        {
            this.mode = mode;
            client_id = API_KEY.GetNaverAPI_KEY().Client_ID;
            client_secret = API_KEY.GetNaverAPI_KEY().Client_Secret;
        }


        private HttpWebRequest makeRequest()
        {
            HttpWebRequest req = null;
            if (mode == Translate_mode.NMT)
            {
                req = (HttpWebRequest)WebRequest.Create(nmt_url);
            }
            else if (mode == Translate_mode.SMT)
            {
                req = (HttpWebRequest)WebRequest.Create(smt_url);
            }
            if (req == null)
                return null;
            req.Headers.Add("X-Naver-Client-Id", client_id);
            req.Headers.Add("X-Naver-Client-Secret", client_secret);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            return req;
        }

        public void Translate(Language source, Language target, string text)
        {
            if(isTasking == true)
                return;

            isTasking = true;
            this.source = source;
            this.target = target;
            this.text = text;
            translationThread = new Thread(new ThreadStart(translate));
            translationThread.Start();
        }

        /*
         * 실질적으로 번역을 요청하고 받아오는함수
         * 번역을 수신을 성공하거나 실패하면, 해당하는 이벤트를 호출한다.
         * 
         */
        private void translate()
        {
            HttpWebRequest request = makeRequest();
            string result = string.Empty;
            try
            {
                byteDataParams = Encoding.UTF8.GetBytes(string.Format("source={0}&target={1}&text=", LanguageCode[source], LanguageCode[target]) + text);
                request.ContentLength = byteDataParams.Length;
                requestStream = request.GetRequestStream();
                requestStream.Write(byteDataParams, 0, byteDataParams.Length);
                response = (HttpWebResponse)request.GetResponse();
                responseStream = response.GetResponseStream();
                reader = new StreamReader(responseStream, Encoding.UTF8);
                result = reader.ReadToEnd();
                //CompletedTranslationEvent?.Invoke(this, new PapagoTranslationEventArgs(result));
                sendTranslatedData(result);
            }
            catch(WebException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
                responseStream = e.Response.GetResponseStream();
                reader = new StreamReader(responseStream, Encoding.UTF8);
                result = reader.ReadToEnd();
                closer();
                FailedTranslationEvent?.Invoke(this, new PapagoTranslationEventArgs(result));
            }
            closer();
            isTasking = false;
        }

        void closer()
        {
            requestStream.Close();
            responseStream.Close();
            reader.Close();
            response.Close();
            isTasking = false;
        }

        

        /*
         * 파파고가 제동하는 두가지 번역 API중 하나를 택하는 함수
         */
        public void ChangeTranslateMode(Translate_mode mode)
        {
            if(this.mode != mode)
            {
                this.mode = mode;
            }
        }

        /*
         * 이벤트 등록 함수
         * 번역 성공, 실패시 호출될 함수를 등록한다.
         */
        public void RegistTranslationEventHandler(PapagoTranslationEventHandler CompleteFunc, PapagoTranslationEventHandler FailFunc)
        {
            CompletedTranslationEvent += CompleteFunc;
            FailedTranslationEvent += FailFunc;
        }

        private void sendTranslatedData(string jsonData)
        {
            resultText = JObject.Parse(jsonData);
            string str = resultText["message"]["result"]["translatedText"].ToString();
            CompletedTranslationEvent?.Invoke(this, new PapagoTranslationEventArgs(str));
        }
    }

    public class PapagoTranslationEventArgs : EventArgs
    {
        public PapagoTranslationEventArgs(string text)
        {
            TranslationText = text;
        }
        public string TranslationText { get; }
    }
}
