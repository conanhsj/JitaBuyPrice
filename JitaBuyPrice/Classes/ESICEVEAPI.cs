﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using JitaBuyPrice.Objects;
using Newtonsoft.Json;

namespace JitaBuyPrice.Classes
{
    public static class ESICEVEAPI
    {

        public static List<ESIAssets> lstAssets = new List<ESIAssets>();
 

        //https://shimo.im/docs/DhCG9tWHtjVyTqwc/read
        //https://image.evepc.163.com/Home
        //获取角色ID：https://esi.evepc.163.com/latest/search/?categories=character&datasource=serenity&language=zh&search=军用馒头&strict=true 
        //获取军团ID：https://esi.evepc.163.com/latest/characters/410614068/?datasource=serenity
        //伏尔戈 10000002 吉他 30000142 格式 必须为 xml 或 json (全部小写)
        //https://www.ceve-market.org/api/market/region/10000002/system/30000142/type/{物品ID}.json
        public static string SearchCharacter(string strUserName)
        {

            //请求
            string strReqPath = string.Format("https://esi.evepc.163.com/latest/search/?categories=character&datasource=serenity&language=zh&search={0}&strict=true", strUserName);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strReqPath);
            request.Method = "GET";

            using (WebResponse response = request.GetResponse())
            {
     
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                //JsonTextReader jsonReader = new JsonTextReader(sr);

                XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(sr.ReadToEnd());
                XmlNode rootNode = xmlDoc.SelectSingleNode("character");

                return rootNode.InnerText;
            }
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
                        if(lstAllAsset.Count != 1000)
                        {
                            break;
                        }
                    }
                }
            }
            catch(Exception ex)
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
    }
}
