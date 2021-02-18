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
    public static class CEVEMarketAPI
    {
        public static List<Price> lstPriceCache = new List<Price>();
        public static List<SearchingResult> lstResult = new List<SearchingResult>();
        public static BriefChart baseChart = new BriefChart();
        public static IceChart iceChart = new IceChart();
        //https://www.ceve-market.org/api/

        //https://www.ceve-market.org/api/market/region/{星域ID}/system/{星系ID}/type/{物品ID}.{格式}
        //https://www.ceve-market.org/api/market/type/34.xml
        //https://www.ceve-market.org/api/market/region/10000002/type/34.json

        //https://www.ceve-market.org/api/market
        //https://www.ceve-market.org/api/marketstat
        //https://www.ceve-market.org/api/evemon
        //https://www.ceve-market.org/api/quicklook
        //https://www.ceve-market.org/api/searchname

        //伏尔戈 10000002 吉他 30000142 格式 必须为 xml 或 json (全部小写)
        //https://www.ceve-market.org/api/market/region/10000002/system/30000142/type/{物品ID}.json
        public static void SearchPrice(List<SearchingItem> lstItem)
        {
            lstResult.Clear();
            foreach (SearchingItem Item in lstItem)
            {
                if (!string.IsNullOrEmpty(Item.ItemID))
                {
                    continue;
                }
                Objects.Item objItem = CEVEMarketFile.lstItem.Find(X => (X.Name == Item.Name));
                if (objItem == null)
                {
                    MessageBox.Show("请先导入物品ID");
                    return;
                }
                Item.ItemID = objItem.TypeID;
            }

            foreach (SearchingItem Item in lstItem)
            {
                //请求
                string strReqPath = string.Format("https://www.ceve-market.org/api/market/region/10000002/system/30000142/type/{0}.xml", Item.ItemID);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strReqPath);
                request.Method = "GET";

                using (WebResponse response = request.GetResponse())
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    string strXML = sr.ReadToEnd();

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(strXML);
                    XmlNode rootNode = xmlDoc.SelectSingleNode("cevemarket");
                    string strBuy = xmlDoc.SelectSingleNode("cevemarket/buy/max").InnerText;
                    string strSell = xmlDoc.SelectSingleNode("cevemarket/sell/min").InnerText;
                    string strBuyVolume = xmlDoc.SelectSingleNode("cevemarket/buy/volume").InnerText;
                    string strSellVolume = xmlDoc.SelectSingleNode("cevemarket/sell/volume").InnerText;
                    SearchingResult PriceStat = new SearchingResult();
                    PriceStat.Name = Item.Name;
                    PriceStat.Volume = Item.Volume.ToString();
                    PriceStat.Buy1 = strBuy;
                    PriceStat.Buy1Volume = strBuyVolume;
                    PriceStat.Sell1 = strSell;
                    PriceStat.Sell1Volume = strSellVolume;
                    PriceStat.BasePrice = Item.BasePrice;
                    PriceStat.Size = Item.Size;
                    lstResult.Add(PriceStat);


                    Price Cached = lstPriceCache.Find(X => X.TypeId == Item.ItemID);
                    if (Cached != null)
                    {
                        Cached.buy.max = Commons.ReadDouble(strBuy);
                        Cached.buy.volume = Commons.ReadInt(strBuyVolume);
                        Cached.sell.min = Commons.ReadDouble(strSell);
                        Cached.buy.volume = Commons.ReadInt(strSellVolume);
                    }
                    else
                    {
                        Cached = new Price();
                        Cached.TypeId = Item.ItemID;
                        Cached.Name = Item.Name;
                        Cached.buy.max = Commons.ReadDouble(strBuy);
                        Cached.buy.volume = Commons.ReadInt(strBuyVolume);
                        Cached.sell.min = Commons.ReadDouble(strSell);
                        Cached.buy.volume = Commons.ReadInt(strSellVolume);
                        lstPriceCache.Add(Cached);
                    }
                }

            }

        }

        internal static void SearchChart()
        {
            //标准矿价收单请求接口
            string strReqPath = string.Format("https://www.ceve-market.org/api/evemon");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strReqPath);
            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string strXML = sr.ReadToEnd();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(strXML);
                XmlNode rootNode = xmlDoc.SelectSingleNode("minerals");

                baseChart.Tri = double.Parse(xmlDoc.SelectSingleNode("minerals/mineral[name/text()='三钛合金']/price").InnerText);
                baseChart.Pye = double.Parse(xmlDoc.SelectSingleNode("minerals/mineral[name/text()='类晶体胶矿']/price").InnerText);
                baseChart.Mex = double.Parse(xmlDoc.SelectSingleNode("minerals/mineral[name/text()='类银超金属']/price").InnerText);
                baseChart.Iso = double.Parse(xmlDoc.SelectSingleNode("minerals/mineral[name/text()='同位聚合体']/price").InnerText);
                baseChart.Noc = double.Parse(xmlDoc.SelectSingleNode("minerals/mineral[name/text()='超新星诺克石']/price").InnerText);
                baseChart.Zyd = double.Parse(xmlDoc.SelectSingleNode("minerals/mineral[name/text()='晶状石英核岩']/price").InnerText);
                baseChart.Meg = double.Parse(xmlDoc.SelectSingleNode("minerals/mineral[name/text()='超噬矿']/price").InnerText);
            }

            OutputJitaMinePrice();
            //16272   重水
            //16273   液化臭氧
            //16275   锶包合物
            //16274   氦同位素
            //17887   氧同位素
            //17888   氮同位素
            //17889   氢同位素

            string strReqPathIce = "https://www.ceve-market.org/api/marketstat?usesystem=30000142&typeid=16272&typeid=16273&typeid=16274&typeid=16275&typeid=17887&typeid=17888&typeid=17889";
            HttpWebRequest reqIce = (HttpWebRequest)WebRequest.Create(strReqPathIce);
            reqIce.Method = "GET";
            using (WebResponse response = reqIce.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string strXML = sr.ReadToEnd();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(strXML);
                XmlNode rootNode = xmlDoc.SelectSingleNode("evec_api/marketstat");

                iceChart.HvWater = double.Parse(rootNode.SelectSingleNode("type[@id='16272']/buy/max").InnerText);
                iceChart.LqOzone = double.Parse(rootNode.SelectSingleNode("type[@id='16273']/buy/max").InnerText);
                iceChart.Strontium = double.Parse(rootNode.SelectSingleNode("type[@id='16275']/buy/max").InnerText);
                iceChart.A_Helium_Isotopesogen = double.Parse(rootNode.SelectSingleNode("type[@id='16274']/buy/max").InnerText);
                iceChart.G_Oxy_Isotopesogen = double.Parse(rootNode.SelectSingleNode("type[@id='17887']/buy/max").InnerText);
                iceChart.C_Nitro_Isotopesogen = double.Parse(rootNode.SelectSingleNode("type[@id='17888']/buy/max").InnerText);
                iceChart.M_Hydro_Isotopesogen = double.Parse(rootNode.SelectSingleNode("type[@id='17889']/buy/max").InnerText);
            }

        }

        private static void OutputJitaMinePrice()
        {
            List<Item> lstBaseChart = new List<Item>();
            lstBaseChart.Add(new Item() { Name = "三钛合金", TypeID = "34", Descript = CEVEMarketAPI.baseChart.Tri.ToString() });
            lstBaseChart.Add(new Item() { Name = "类晶体胶矿", TypeID = "35", Descript = CEVEMarketAPI.baseChart.Pye.ToString() });
            lstBaseChart.Add(new Item() { Name = "类银超金属", TypeID = "36", Descript = CEVEMarketAPI.baseChart.Mex.ToString() });
            lstBaseChart.Add(new Item() { Name = "同位聚合体", TypeID = "37", Descript = CEVEMarketAPI.baseChart.Iso.ToString() });
            lstBaseChart.Add(new Item() { Name = "超新星诺克石", TypeID = "38", Descript = CEVEMarketAPI.baseChart.Noc.ToString() });
            lstBaseChart.Add(new Item() { Name = "晶状石英核岩", TypeID = "39", Descript = CEVEMarketAPI.baseChart.Zyd.ToString() });
            lstBaseChart.Add(new Item() { Name = "超噬矿", TypeID = "40", Descript = CEVEMarketAPI.baseChart.Meg.ToString() });
            string strContent = JsonConvert.SerializeObject(lstBaseChart);
            //添加换行符
            strContent = strContent.Replace("},", "},\n");
            //多余内容去除
            strContent = strContent.Replace(",\"Category1\":\"\",\"Category2\":\"\",\"Category3\":\"\",\"Category4\":\"\",\"Category5\":\"\",\"Category6\":\"\"", "");
            FilesHelper.OutputJsonFile("JitaPrice\\" + DateTime.Now.ToString("yyyyMMddHHmmss"), strContent);
        }

        public static Dictionary<string, Price> SearchPriceJson(List<string> lstItem)
        {
            Dictionary<string, Price> dicResult = new Dictionary<string, Price>();

            foreach (string Item in lstItem)
            {
                Price Cached = lstPriceCache.Find(X => X.TypeId == Item);
                if (Cached != null)
                {
                    dicResult.Add(Item, Cached);
                    continue;
                    ////每次列表前5个去更新
                    //if (lstPriceCache.IndexOf(Cached) > 5)
                    //{
                    //    dicResult.Add(Item, Cached);
                    //    continue;
                    //}
                    //else
                    //{
                    //    lstPriceCache.Remove(Cached);
                    //}
                }

                //请求
                string strReqPath = string.Format("https://www.ceve-market.org/api/market/region/10000002/type/{0}.json", Item);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strReqPath);
                request.Method = "GET";

                using (WebResponse response = request.GetResponse())
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    string strJson = sr.ReadToEnd();
                    Price result = JsonConvert.DeserializeObject<Price>(strJson);
                    dicResult.Add(Item, result);

                    Cached = result;
                    Cached.TypeId = Item;
                    lstPriceCache.Add(Cached);
                }
            }

            return dicResult;

        }

    }
}
