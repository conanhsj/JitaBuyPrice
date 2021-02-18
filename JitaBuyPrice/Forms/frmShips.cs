using JitaBuyPrice.Classes;
using JitaBuyPrice.Helper;
using JitaBuyPrice.Objects;
using JitaBuyPrice.ObjectsJson;
using JitaBuyPrice.ObjectsYaml;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JitaBuyPrice.Forms
{
    public partial class frmShips : Form
    {
        public frmShips()
        {
            InitializeComponent();
        }

        private static void OutputListItem(string strName, List<Item> lstItemFix)
        {
            string strContent = JsonConvert.SerializeObject(lstItemFix);
            //添加换行符
            strContent = strContent.Replace("},", "},\n");
            //多余内容去除
            strContent = strContent.Replace(",\"Descript\":\"\",\"Category1\":\"\",\"Category2\":\"\",\"Category3\":\"\",\"Category4\":\"\",\"Category5\":\"\",\"Category6\":\"\"", "");

            FilesHelper.OutputJsonFile(strName, strContent);
        }


        private void btnGetID_Click(object sender, EventArgs e)
        {
            //读取蓝图种类
            string strBPs = FilesHelper.ReadJsonFile("MyProducts - Fix");
            List<Item> lstItemFix = JsonConvert.DeserializeObject<List<Item>>(strBPs);

            foreach (Item Product in lstItemFix)
            {
                if (Product.TypeID != "")
                {
                    continue;
                }
                Item item = CEVEMarketFile.lstItem.Find(obj => obj.Name == Product.Name);
                if (item != null)
                {
                    Product.TypeID = item.TypeID;
                }

            }
            OutputListItem("MyProducts", lstItemFix);
        }

        private void btnGetBP_Click(object sender, EventArgs e)
        {
            //string strSample = "https://login.evepc.163.com/account/logoff?returnUrl=/v2/oauth/authorize?response_type=code&redirect_uri=https%3A%2F%2Fesi.evepc.163.com%2Fui%2Foauth2-redirect.html&client_id=bc90aa496a404724a93f41b4f4e97761&scope=esi-killmails.read_killmails.v1%20esi-ui.open_window.v1%20esi-ui.write_waypoint.v1%20esi-fittings.write_fittings.v1&state=syJGfN6X&code_challenge=O6Z_1ydtFGh6Naat3cXA62fyBx-BC806ZYxtzcM2BFU&code_challenge_method=S256&device_id=kb_ceve_market";
            //string strLogOff = WebUtility.UrlDecode(strSample);

            frmLoginESI frmESI = new frmLoginESI();
            frmESI.ShowDialog();

            string strAccessToken = frmESI.AccessToken;
            if (string.IsNullOrEmpty(strAccessToken))
            {
                return;
            }
            string strUserID = "90076612";
            ESICEVEAPI.ReadAssets(strUserID, strAccessToken);

            List<Item> lstBPItem = new List<Item>();
            foreach (ESIAssets item in ESICEVEAPI.lstAssets)
            {
                //去除重复
                if (lstBPItem.Find(obj => obj.Name == item.item_Name) != null)
                {
                    continue;
                }

                Item newItem = new Item();
                newItem.Name = item.item_Name;
                newItem.TypeID = item.type_id;
                lstBPItem.Add(newItem);
            }

            //string strContent = JsonConvert.SerializeObject(ESICEVEAPI.lstAssets);
            ////添加换行符
            //strContent = strContent.Replace("},", "},\n");
            //FilesHelper.OutputFile("BluePrints", strContent);

            OutputListItem("BluePrintsItem", lstBPItem);
        }

        private void btnBPtoCode_Click(object sender, EventArgs e)
        {
            //读取蓝图种类
            string strBPs = FilesHelper.ReadJsonFile("BluePrintsItem");
            List<Item> lstBluePrint = JsonConvert.DeserializeObject<List<Item>>(strBPs);

            List<Item> lstProduct = new List<Item>();
            foreach (Item bp in lstBluePrint)
            {
                string strDummyName = bp.Name.Replace("蓝图", "");

                //去除重复
                if (lstProduct.Find(obj => obj.Name == strDummyName) != null)
                {
                    continue;
                }

                //取得ID
                Item item = CEVEMarketFile.lstItem.Find(obj => obj.Name == strDummyName);
                if (item != null)
                {
                    Item newItem = new Item();
                    newItem.Name = item.Name;
                    newItem.TypeID = item.TypeID;
                    lstProduct.Add(newItem);
                }
                else
                {
                    Item newItem = new Item();
                    newItem.Name = strDummyName;
                    lstProduct.Add(newItem);
                }
            }

            OutputListItem("MyProducts", lstProduct);
        }

        private void btnRegionProduct_Click(object sender, EventArgs e)
        {
            List<Regions> lstRegion = new List<Regions>()
            {
               new Regions(){ Region_ID = "10000002", Region_Name ="伏尔戈" },
               new Regions(){ Region_ID = "10000042", Region_Name ="美特伯里斯" },
               new Regions(){ Region_ID = "10000043", Region_Name ="多美" },
               new Regions(){ Region_ID = "10000030", Region_Name ="西玛特尔" },
               new Regions(){ Region_ID = "10000064", Region_Name ="精华之域" },
               new Regions(){ Region_ID = "10000050", Region_Name ="逑瑞斯" },
            };

            foreach (Regions regionID in lstRegion)
            {
                List<string> lstTypeID = ESICEVEAPI.ReadMarketTypeID(regionID.Region_ID);

                string strProductList = FilesHelper.ReadJsonFile("MyProducts - Fix");
                List<Item> lstProduct = JsonConvert.DeserializeObject<List<Item>>(strProductList);

                List<Item> lstNeetFix = new List<Item>();
                foreach (Item product in lstProduct)
                {
                    if (!lstTypeID.Contains(product.TypeID))
                    {
                        lstNeetFix.Add(product);
                    }

                }

                OutputListItem("NeedProductTo\\" + regionID.Region_Name, lstNeetFix);
            }
            MessageBox.Show("计算完成");
        }

        List<Item> lstLostTypeId = new List<Item>();
        private void btnBuyBP_Click(object sender, EventArgs e)
        {
            //读取蓝图种类
            string strBPs = FilesHelper.ReadJsonFile("BluePrintsItem");
            List<Item> lstBluePrint = JsonConvert.DeserializeObject<List<Item>>(strBPs);

            string strBPBlackList = FilesHelper.ReadJsonFile("BluePrintsBlackList");
            List<Item> lstBPBL = JsonConvert.DeserializeObject<List<Item>>(strBPBlackList);
            lstBluePrint.AddRange(lstBPBL);

            List<Regions> lstRegion = new List<Regions>()
            {
               new Regions(){ Region_ID = "10000001", Region_Name ="德里克" },
               new Regions(){ Region_ID = "10000002", Region_Name ="伏尔戈" },
               //new Regions(){ Region_ID = "10000003", Region_Name ="静寂谷" },
               //new Regions(){ Region_ID = "10000004", Region_Name ="UUA-F4" },
               //new Regions(){ Region_ID = "10000005", Region_Name ="底特里德" },
               //new Regions(){ Region_ID = "10000006", Region_Name ="邪恶湾流" },
               //new Regions(){ Region_ID = "10000007", Region_Name ="地窖" },
               //new Regions(){ Region_ID = "10000008", Region_Name ="灼热之径" },
               //new Regions(){ Region_ID = "10000009", Region_Name ="因斯姆尔" },
               //new Regions(){ Region_ID = "10000010", Region_Name ="特布特" },
               new Regions(){ Region_ID = "10000011", Region_Name ="大荒野" },
               new Regions(){ Region_ID = "10000012", Region_Name ="柯尔斯" },
               //new Regions(){ Region_ID = "10000013", Region_Name ="糟粕之域" },
               //new Regions(){ Region_ID = "10000014", Region_Name ="卡彻" },
               new Regions(){ Region_ID = "10000015", Region_Name ="维纳尔" },
               new Regions(){ Region_ID = "10000016", Region_Name ="长征" },
               //new Regions(){ Region_ID = "10000017", Region_Name ="J7HZ-F" },
               //new Regions(){ Region_ID = "10000018", Region_Name ="螺旋之域" },
               //new Regions(){ Region_ID = "10000019", Region_Name ="A821-A" },
               new Regions(){ Region_ID = "10000020", Region_Name ="塔什蒙贡" },
               //new Regions(){ Region_ID = "10000021", Region_Name ="域外走廊" },
               new Regions(){ Region_ID = "10000022", Region_Name ="混浊" },
               new Regions(){ Region_ID = "10000023", Region_Name ="黑渊" },
               //new Regions(){ Region_ID = "10000025", Region_Name ="伊梅瑟亚" },
               //new Regions(){ Region_ID = "10000027", Region_Name ="琉蓝之穹" },
               new Regions(){ Region_ID = "10000028", Region_Name ="摩登赫斯" },
               new Regions(){ Region_ID = "10000029", Region_Name ="对舞之域" },
               new Regions(){ Region_ID = "10000030", Region_Name ="西玛特尔" },
               //new Regions(){ Region_ID = "10000031", Region_Name ="绝径" },
               new Regions(){ Region_ID = "10000032", Region_Name ="金纳泽" },
               new Regions(){ Region_ID = "10000033", Region_Name ="赛塔德洱" },
               //new Regions(){ Region_ID = "10000034", Region_Name ="卡勒瓦拉阔地" },
               //new Regions(){ Region_ID = "10000035", Region_Name ="德克廉" },
               new Regions(){ Region_ID = "10000036", Region_Name ="破碎" },
               new Regions(){ Region_ID = "10000037", Region_Name ="埃维希尔" },
               new Regions(){ Region_ID = "10000038", Region_Name ="幽暗之域" },
               //new Regions(){ Region_ID = "10000039", Region_Name ="埃索特亚" },
               //new Regions(){ Region_ID = "10000040", Region_Name ="欧莎" },
               new Regions(){ Region_ID = "10000041", Region_Name ="辛迪加" },
               new Regions(){ Region_ID = "10000042", Region_Name ="美特伯里斯" },
               new Regions(){ Region_ID = "10000043", Region_Name ="多美" },
               new Regions(){ Region_ID = "10000044", Region_Name ="孤独之域" },
               //new Regions(){ Region_ID = "10000045", Region_Name ="特纳" },
               //new Regions(){ Region_ID = "10000046", Region_Name ="斐德" },
               //new Regions(){ Region_ID = "10000047", Region_Name ="普罗维登斯" },
               new Regions(){ Region_ID = "10000048", Region_Name ="宁静之域" },
               new Regions(){ Region_ID = "10000049", Region_Name ="卡尼迪" },
               //new Regions(){ Region_ID = "10000050", Region_Name ="逑瑞斯" },
               //new Regions(){ Region_ID = "10000051", Region_Name ="云环" },
               new Regions(){ Region_ID = "10000052", Region_Name ="卡多尔" },
               //new Regions(){ Region_ID = "10000053", Region_Name ="钴蓝边域" },
               new Regions(){ Region_ID = "10000054", Region_Name ="艾里迪亚" },
               //new Regions(){ Region_ID = "10000055", Region_Name ="血脉" },
               //new Regions(){ Region_ID = "10000056", Region_Name ="非塔波利斯" },
               new Regions(){ Region_ID = "10000057", Region_Name ="外环" },
               new Regions(){ Region_ID = "10000058", Region_Name ="源泉之域" },
               //new Regions(){ Region_ID = "10000059", Region_Name ="摄魂之域" },
               //new Regions(){ Region_ID = "10000060", Region_Name ="绝地之域" },
               //new Regions(){ Region_ID = "10000061", Region_Name ="特里菲斯" },
               //new Regions(){ Region_ID = "10000062", Region_Name ="欧米斯特" },
               //new Regions(){ Region_ID = "10000063", Region_Name ="贝斯" },
               new Regions(){ Region_ID = "10000064", Region_Name ="精华之域" },
               new Regions(){ Region_ID = "10000065", Region_Name ="柯埃佐" },
               new Regions(){ Region_ID = "10000066", Region_Name ="佩利根弗" },
               new Regions(){ Region_ID = "10000067", Region_Name ="吉勒西斯" },
               new Regions(){ Region_ID = "10000068", Region_Name ="维格温铎" },
               new Regions(){ Region_ID = "10000069", Region_Name ="暗涌之域" },
               //new Regions(){ Region_ID = "10000070", Region_Name ="波赫文" },
            };

            foreach (Regions regionID in lstRegion)
            {
                //读取市场商品
                List<string> lstTypeID = ESICEVEAPI.ReadMarketTypeID(regionID.Region_ID);

                List<Item> lstBuyBP = new List<Item>();

                foreach (string TypeID in lstTypeID)
                {
                    Item item = CEVEMarketFile.lstItem.Find(obj => obj.TypeID == TypeID);

                    if (item == null)
                    {
                        Item newItem = new Item();
                        newItem.TypeID = TypeID;
                        lstLostTypeId.Add(newItem);
                        continue;
                    }

                    if (item.Name.Contains("蓝图"))
                    {
                        var result = lstBluePrint.Find(X => X.TypeID == item.TypeID);
                        if (result == null)
                        {
                            Item newItem = new Item();
                            newItem.Name = item.Name;
                            newItem.TypeID = item.TypeID;
                            lstBuyBP.Add(newItem);
                        }
                    }
                }
                OutputListItem("BuyBP\\" + regionID.Region_Name, lstBuyBP);
            }
            OutputListItem("UnknownItem", lstLostTypeId);
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            //List<string> lstFile = Directory.EnumerateFiles(Application.StartupPath + @"\Json\JitaPrice\", DateTime.Now.ToString("yyyyMMddHH*"), SearchOption.AllDirectories).ToList();
            //if (lstFile.Count < 1)
            //{
            //    CEVEMarketAPI.SearchChart();
            //    lstFile = Directory.EnumerateFiles(Application.StartupPath + @"\Json\JitaPrice\", DateTime.Now.ToString("yyyyMMddHH*"), SearchOption.AllDirectories).ToList();
            //}
            //string file = Path.GetFileNameWithoutExtension(lstFile[0]);
            //string strMinerPrice = FilesHelper.ReadJsonFile(@"JitaPrice\" + file);
            //List<Item> lstMinerPrice = JsonConvert.DeserializeObject<List<Item>>(strMinerPrice);

            //查找T1原料
            //GetT1OnlyMaterials();

            FilesHelper.ReadBluePrintFile();

            //List<Materials> lstT1 = JsonConvert.DeserializeObject<List<Materials>>(FilesHelper.ReadJsonFile("Materials\\T1Only"));

            //List<string> lstTarget = lstT1.Select(X => X.TypeID).ToList();

            //Dictionary<string, Price> dicResult = CEVEMarketAPI.SearchPriceJson(lstTarget);

            //foreach(string strKey in dicResult.Keys)
            //{
            //    FilesHelper.OutputJsonFile("JitaSellPrice\\" + strKey, JsonConvert.SerializeObject(dicResult[strKey]));
            //}
            Process.Start(Path.GetDirectoryName(Application.StartupPath + @"\Json\"));
        }

        private void GetT1OnlyMaterials()
        {
            List<string> lstTypeID = ESICEVEAPI.ReadMarketTypeID("10000002");
            List<Materials> lstMaterials = FilesHelper.ReadMaterialsFile();
            List<Materials> lstT1 = new List<Materials>();
            foreach (Materials mat in lstMaterials)
            {
                //吉他不卖
                if (!lstTypeID.Contains(mat.TypeID))
                {
                    continue;
                }
                //不能回收 或 包含T1以外
                if (mat.lstItem.Count == 0 || mat.lstItem.Exists(X => int.Parse(X.TypeID) > 40))
                {
                    continue;
                }
                //取得名字
                Item item = CEVEMarketFile.lstItem.Find(obj => obj.TypeID == mat.TypeID);
                if (item == null)
                {
                    Item newItem = new Item();
                    newItem.TypeID = mat.TypeID;
                    lstLostTypeId.Add(newItem);
                    continue;
                }
                mat.Name = item.Name;
                lstT1.Add(mat);
            }
            OutputListItem("UnknownItem", lstLostTypeId);

            string strContent = JsonConvert.SerializeObject(lstT1);
            //添加换行符
            strContent = strContent.Replace("},", "},\n");
            FilesHelper.OutputJsonFile("Materials\\T1Only", strContent);
        }
    }
}
