using JitaBuyPrice.ObjectsOther;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JitaBuyPrice.Classes
{
    public static class OtherNetApis
    {
        public static string getSetu()
        {
            string serverUrl  = "https://api.lolicon.app/setu/";

            var reqResponse = (HttpWebRequest)WebRequest.Create(serverUrl);
            //reqResponse.
            //{
            //    Timeout = 3000,
            //    Params = new Dictionary<string, string>
            //        {
            //            {"apikey", apiKey}
            //        },
            //    isCheckSSLCert = hso.CheckSSLCert
            //});

            SetuResponce result = null;
            using (WebResponse response = reqResponse.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string strJson = sr.ReadToEnd();

                result = JsonConvert.DeserializeObject<SetuResponce>(strJson); ;
            }

            return result.data[0].url;
        }


        public static string ReadZGJMWorm(string regionID)
        {

            Random random = new Random();
            //请求
            string strReqPath = string.Format("https://www.zgjm.net/chouqian/guanyinlingqian/{0}.html", random.Next(101));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strReqPath);
            request.Method = "GET";

            using (WebResponse response = request.GetResponse())
            {

                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                //JsonTextReader jsonReader = new JsonTextReader(sr);
                string strJson = sr.ReadToEnd();

                strJson = WebUtility.HtmlDecode(strJson);
                //strJson = strJson.Trim('[', ']');
                //XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(strJson);
                HtmlAgilityPack.HtmlDocument xmlDoc = new HtmlAgilityPack.HtmlDocument();

                xmlDoc.LoadHtml(strJson);
                List<HtmlAgilityPack.HtmlNode> lstNode = xmlDoc.DocumentNode.SelectNodes("//article").ToList();
                if (lstNode.Count > 0)
                {
                    string strResult = lstNode[0].InnerText;
                    strResult = strResult.Replace('\t', '\n');
                    strResult = strResult.Substring(0, strResult.IndexOf("〖四句解说〗"));
                    strResult = strResult.Trim('\n', '\r');
                    strResult += "\n\n" + "全文地址：" + strReqPath;

                    return strResult;
                }
            }


            return "";
        }


        public static string GetVersion()
        {
            string strVersion = string.Empty;

            //请求
            string strReqPath = string.Format(@"https://eve-static-data-export.s3-eu-west-1.amazonaws.com/tranquility/checksum");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strReqPath);
            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {

                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string strJson = sr.ReadToEnd();

            }


            return strVersion;
        }
    }
}
