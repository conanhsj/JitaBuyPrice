using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using JitaBuyPrice.Helper;
using JitaBuyPrice.Objects;
using JitaBuyPrice.ObjectsJson;
using Newtonsoft.Json;

namespace JitaBuyPrice.Classes
{
    public static class CEVESwaggerAPI
    {

        public static List<ESIAssets> lstAssets = new List<ESIAssets>();


        //https://shimo.im/docs/DhCG9tWHtjVyTqwc/read
        //https://image.evepc.163.com/Home
        //获取角色ID：https://esi.evepc.163.com/latest/search/?categories=character&datasource=serenity&language=zh&search=军用馒头&strict=true 
        //获取军团ID：https://esi.evepc.163.com/latest/characters/410614068/?datasource=serenity
        //伏尔戈 10000002 吉他 30000142 格式 必须为 xml 或 json (全部小写)
        //https://www.ceve-market.org/api/market/region/10000002/system/30000142/type/{物品ID}.json
        public static List<Character> SearchNameToID(string strUserName)
        {
            SearchIDResult SearchIDResult = new SearchIDResult();
            List<Character> lstCharacter = new List<Character>();
            List<JOIDtoName> lstResult = new List<JOIDtoName>();

            //请求
            string strReqPath = string.Format("https://esi.evepc.163.com/latest/universe/ids/?datasource=serenity&language=zh");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strReqPath);
            request.Method = "POST";

            request.KeepAlive = false;
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            byte[] postData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new List<string>() { strUserName }));   //使用utf-8格式组装post参数
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);

            using (WebResponse response = request.GetResponse())
            {

                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string strJson = sr.ReadToEnd();
                SearchIDResult = JsonConvert.DeserializeObject<SearchIDResult>(strJson);
            }

            //if (SearchIDResult.Character.Count > 0)
            //{
            //    foreach (long IDResult in SearchIDResult.Character)
            //    {
            //        //请求
            //        string strCharacterRequest = string.Format("https://esi.evepc.163.com/latest/characters/410614068/?datasource=serenity", IDResult);
            //        request = (HttpWebRequest)WebRequest.Create(strReqPath);
            //        request.Method = "GET";

            //        using (WebResponse response = request.GetResponse())
            //        {

            //            Stream stream = response.GetResponseStream();
            //            StreamReader sr = new StreamReader(stream);
            //            string strJson = sr.ReadToEnd();
            //            Character chara = JsonConvert.DeserializeObject<Character>(strJson);
            //            lstCharacter.Add(chara);
            //        }
            //    }
            //}
            return lstCharacter;
        }

        public static string ReadSearchCharacter(string UserName)
        {
            SearchIDResult SearchIDResult = new SearchIDResult();
            Random random = new Random();
            //请求
            string strReqPath = string.Format("https://esi.evepc.163.com/latest/search/?categories=character&datasource=serenity&language=zh&search={0}&strict=true", "绯舞之夜");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strReqPath);
            request.Method = "GET";

            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                //JsonTextReader jsonReader = new JsonTextReader(sr);
                string strJson = sr.ReadToEnd();
                SearchIDResult = JsonConvert.DeserializeObject<SearchIDResult>(strJson);
            }


            return "";
        }




        public static void SearchScope(string scope)
        {
            scope = "esi-assets.read_assets.v1";
            string returnurl = "/v2/oauth/authorize?response_type=token&client_id=bc90aa496a404724a93f41b4f4e97761&redirect_uri=https%3A%2F%2Fesi.evepc.163.com%2Fui%2Foauth2-redirect.html&realm=ESI&device_id=kb_ceve_market&state=kb_ceve_market&scope=" + WebUtility.UrlEncode(scope);
            string url = "https://login.evepc.163.com/account/logoff?returnUrl=" + WebUtility.UrlEncode(returnurl);

            //chrome
            System.Diagnostics.Process.Start("chrome.exe", url);
        }

        public static List<string> lstLostTypeId = new List<string>();
        public static void ReadAssets(string strUserID, string strAccessToken)
        {
            lstAssets.Clear();
            try
            {
                for (int page = 1; ; page++)
                {
                    //请求
                    string strReqPath = string.Format("https://esi.evepc.163.com/latest/characters/{0}/assets/?datasource=serenity&page={1}&token={2}", strUserID, page.ToString(), strAccessToken);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strReqPath);
                    request.Method = "GET";
                    using (WebResponse response = request.GetResponse())
                    {

                        Stream stream = response.GetResponseStream();
                        StreamReader sr = new StreamReader(stream);
                        //JsonTextReader jsonReader = new JsonTextReader(sr);
                        string strJson = sr.ReadToEnd();
                        //strJson = strJson.Trim('[', ']');
                        //XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(strJson);
                        List<ESIAssets> lstAllAsset = JsonConvert.DeserializeObject<List<ESIAssets>>(strJson);

                        foreach (ESIAssets Asset in lstAllAsset)
                        {
                            Item item = CEVEMarketFile.lstItem.Find(obj => obj.TypeID == Asset.type_id);

                            if (item == null)
                            {
                                lstLostTypeId.Add(Asset.type_id);
                                continue;
                            }

                            if (item.Name.Contains("蓝图"))
                            {
                                Asset.item_Name = item.Name;
                                lstAssets.Add(Asset);
                            }

                        }

                        //遍历完成
                        if (lstAllAsset.Count != 1000)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static List<string> ReadMarketTypeID(string regionID)
        {
            List<string> lstTypeID = new List<string>();
            for (int page = 1; ; page++)
            {
                //请求
                string strReqPath = string.Format("https://esi.evepc.163.com/latest/markets/{0}/types/?datasource=serenity&page={1}", regionID, page);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strReqPath);
                request.Method = "GET";
                using (WebResponse response = request.GetResponse())
                {

                    Stream stream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    //JsonTextReader jsonReader = new JsonTextReader(sr);
                    string strJson = sr.ReadToEnd();
                    //strJson = strJson.Trim('[', ']');
                    //XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(strJson);
                    List<string> lstTypeIDPage = JsonConvert.DeserializeObject<List<string>>(strJson);

                    lstTypeID.AddRange(lstTypeIDPage);
                    //遍历完成
                    if (lstTypeIDPage.Count != 1000)
                    {
                        break;
                    }
                }
            }

            return lstTypeID;
        }


        public static Wormhole ReadWikiWormhole(string regionID)
        {
            Wormhole wh = new Wormhole();

            //请求
            string strReqPath = string.Format("http://eve.huijiwiki.com/wiki/{0}", regionID);
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
                List<HtmlAgilityPack.HtmlNode> lstNode = xmlDoc.DocumentNode.SelectNodes("//div//table").ToList();
                List<HtmlAgilityPack.HtmlNode> lsttd = lstNode[0].SelectNodes("//td").ToList();

                wh.Code = lstNode[0].SelectSingleNode("//th").GetDirectInnerText();
                wh.Come = lsttd[0].InnerText.Trim('\n');
                wh.To = lsttd[1].InnerText.Trim('\n');
                wh.Keep = lsttd[2].InnerText.Trim('\n');
                wh.Pass = lsttd[3].InnerText.Trim('\n');
                wh.Max = lsttd[4].InnerText.Trim('\n');
            }


            return wh;
        }

        public static string ReadEVEAlmanac(string regionID)
        {

            Random random = new Random();
            //请求
            string strReqPath = string.Format("https://www.linodas.com/eve.html");
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
                List<HtmlAgilityPack.HtmlNode> lstNode = xmlDoc.DocumentNode.SelectNodes("//table//td").ToList();
                if (lstNode.Count > 0)
                {
                    string strResult = lstNode[0].InnerText;
                    strResult = strResult.Replace('\t', '\n');

                    strResult = strResult.Trim('\n', '\r');
                    strResult += "\n\n" + "全文地址：" + strReqPath;

                    return strResult;
                }
            }


            return "";
        }




        public static string ReadWormholeWeb(string regionID)
        {

            string strContents;
            string strBasePath = Application.StartupPath;

            List<string> lstEffect = new List<string>();
            lstEffect.Add("Black Hole");
            lstEffect.Add("Cataclysmic Variable");
            lstEffect.Add("Magnetar");
            lstEffect.Add("Pulsar");
            lstEffect.Add("Red Giant");
            lstEffect.Add("Wolf-Rayet Star");
            List<WormholeSystem> lstSystems = new List<WormholeSystem>();

            using (var sr = new StreamReader(strBasePath + @"\SDE\Web\WH Database - WHDBX.html", Encoding.UTF8))
            {

                strContents = sr.ReadToEnd();

                strContents = WebUtility.HtmlDecode(strContents);
                //strJson = strJson.Trim('[', ']');
                //XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(strJson);
                HtmlAgilityPack.HtmlDocument xmlDoc = new HtmlAgilityPack.HtmlDocument();
                xmlDoc.LoadHtml(strContents);
                List<HtmlAgilityPack.HtmlNode> lstNode = xmlDoc.DocumentNode.SelectNodes("//div[@id='jsystem_search_results']").ToList();
                string strInfoValue = lstNode[0].InnerText;
                List<string> lstHole = strInfoValue.Split('#').ToList();
                lstHole.RemoveAt(0);
                lstHole.RemoveAt(0);

                foreach (string strHole in lstHole)
                {
                    WormholeSystem hole = new WormholeSystem();
                    string strElse = string.Empty;
                    if (strHole.IndexOf('J') > 0)
                    {
                        hole.Name = strHole.Substring(strHole.IndexOf('J'), 7);
                        strElse = strHole.Substring(strHole.IndexOf('J') + 7).Trim();
                    }
                    else
                    {
                        hole.Name = "席拉";
                        hole.Class = "席拉";
                        strElse = strHole.Substring(strHole.IndexOf("Thera") + 10).Trim();
                    }

                    hole.Class = strElse.Substring(0, strElse.IndexOf("[ZKB]")).Trim();
                    strElse = strElse.Substring(strElse.IndexOf("[ZKB]") + 5);

                    string strEffect = lstEffect.Find(eff => strElse.StartsWith(eff));
                    if (!string.IsNullOrEmpty(strEffect))
                    {
                        hole.Effects = strEffect;
                        strElse = strElse.Substring(strEffect.Length);
                    }
                    hole.Statics = strElse;
                    lstSystems.Add(hole);
                }

            }

            FilesHelper.OutputJsonFile("SDE\\Wormhole", JsonConvert.SerializeObject(lstSystems, Newtonsoft.Json.Formatting.Indented));
            return "";
        }

        public static List<JOSovereignty> SovereigntyMap()
        {
            List<JOSovereignty> lstResult = new List<JOSovereignty>();

            //请求
            string strReqPath = string.Format("https://esi.evepc.163.com/latest/sovereignty/map/?datasource=serenity");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strReqPath);
            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {

                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string strJson = sr.ReadToEnd();
                lstResult = JsonConvert.DeserializeObject<List<JOSovereignty>>(strJson);

            }
            return lstResult;
        }

        public static List<JOIDtoName> SovereigntyGetNames(List<long> lstIDs)
        {
            List<JOIDtoName> lstResult = new List<JOIDtoName>();
            //请求
            string strReqPath = string.Format("https://esi.evepc.163.com/latest/universe/names/?datasource=serenity");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strReqPath);
            request.Method = "POST";

            request.KeepAlive = false;
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            byte[] postData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(lstIDs));   //使用utf-8格式组装post参数
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);

            using (WebResponse response = request.GetResponse())
            {

                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string strJson = sr.ReadToEnd();
                lstResult = JsonConvert.DeserializeObject<List<JOIDtoName>>(strJson);

            }
            return lstResult;
        }
    }
}
