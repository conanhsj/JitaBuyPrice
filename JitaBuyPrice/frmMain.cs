using JitaBuyPrice.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JitaBuyPrice
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += Bgw_DoWork;
            bgw.RunWorkerAsync();
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            string strExePath = Environment.CurrentDirectory;
            string[] Files = Directory.GetFiles(strExePath, "數據資料表.xlsx", SearchOption.AllDirectories);

            Classes.CEVEMarketFile.ExcelReader(Files[0]);

            MessageBox.Show("读取完毕");
        }

        private void btnMyRoom_Click(object sender, EventArgs e)
        {
            OpenFileDialog diaFile = new OpenFileDialog();
            diaFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            diaFile.CheckFileExists = true;
            diaFile.Filter = "xlsx|*.xlsx";
            diaFile.ShowDialog();

            string strFilePath = diaFile.FileName;

            if (string.IsNullOrEmpty(strFilePath))
            {
                return;
            }

            //读取蓝图数据
            Classes.CEVEMarketFile.ExcelWorkingReader(strFilePath);
            //读取矿价
            Classes.CEVEMarketAPI.SearchChart();

            //查询用对象
            List<Objects.SearchingItem> lstSeach = new List<Objects.SearchingItem>();
            foreach (Objects.T1Product Item in Classes.CEVEMarketFile.lstT1Item)
            {
                Objects.SearchingItem newSearch = new Objects.SearchingItem();
                newSearch.Name = Item.Name;
                newSearch.Volume = Item.Volume;
                newSearch.BasePrice =
                    Item.Tri * Classes.CEVEMarketAPI.baseChart.Tri +
                    Item.Pye * Classes.CEVEMarketAPI.baseChart.Pye +
                    Item.Mex * Classes.CEVEMarketAPI.baseChart.Mex +
                    Item.Iso * Classes.CEVEMarketAPI.baseChart.Iso +
                    Item.Noc * Classes.CEVEMarketAPI.baseChart.Noc +
                    Item.Zyd * Classes.CEVEMarketAPI.baseChart.Zyd +
                    Item.Meg * Classes.CEVEMarketAPI.baseChart.Meg;

                newSearch.BasePrice = newSearch.BasePrice / Item.Volume;
                lstSeach.Add(newSearch);
            }

            //查询，设置，显示
            Classes.CEVEMarketAPI.SearchPrice(lstSeach);
            if (Classes.CEVEMarketAPI.lstResult.Count == 0)
            {
                return;
            }

            frmT1 frmResult = new frmT1();
            frmResult.SearchResult = Classes.CEVEMarketAPI.lstResult;
            frmResult.Show();
        }

        private void btnBrain_Click(object sender, EventArgs e)
        {
            //44992 伊甸币
            //40520	大型技能注入器
            //45635	小型技能注入器
            //40519 技能提取器
            //查询用对象
            List<Objects.SearchingItem> lstSeach = new List<Objects.SearchingItem>();
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "40520", Name = "大型技能注入器" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "45635", Name = "小型技能注入器" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "44992", Name = "伊甸币" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "40519", Name = "技能提取器" });
            //查询，设置，显示
            Classes.CEVEMarketAPI.SearchPrice(lstSeach);

            double dSkillBasePrice = 0;
            double dBig = double.Parse(Classes.CEVEMarketAPI.lstResult[0].Sell1) / 150000;
            double dSmall = double.Parse(Classes.CEVEMarketAPI.lstResult[1].Sell1) / 30000;
            //每技能点价格
            dSkillBasePrice = Math.Min(dSmall, dBig);
            //额外15点每分钟，86400.00 s 生物学等级翻倍
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "54656", Name = "标准晨曦大脑加速器", BasePrice = 15 * 1440 * 2 * dSkillBasePrice });
            //不吃生物学
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "54812", Name = "基础型克隆飞行员之日大脑加速器", BasePrice = 6 * 1440 * dSkillBasePrice });

            Classes.CEVEMarketAPI.SearchPrice(lstSeach);
            frmBrave frmResult = new frmBrave();
            frmResult.SearchResult = Classes.CEVEMarketAPI.lstResult;
            frmResult.Show();
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            OpenFileDialog diaFile = new OpenFileDialog();
            diaFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            diaFile.CheckFileExists = true;
            diaFile.Filter = "xlsx|*.xlsx";
            diaFile.ShowDialog();

            string strFilePath = diaFile.FileName;

            if (string.IsNullOrEmpty(strFilePath))
            {
                return;
            }

            //读取蓝图数据
            Classes.CEVEMarketFile.ExcelOreRecycle(strFilePath);
            //读取矿价
            Classes.CEVEMarketAPI.SearchChart();
            //查询用对象
            List<Objects.SearchingItem> lstSeach = new List<Objects.SearchingItem>();
            foreach (Objects.Ore Item in Classes.CEVEMarketFile.lstOre)
            {
                Objects.SearchingItem newSearch = new Objects.SearchingItem();
                newSearch.Name = Item.Name;
                newSearch.Volume = Item.Volume;
                newSearch.BasePrice =
                    Item.Tri * Classes.CEVEMarketAPI.baseChart.Tri +
                    Item.Pye * Classes.CEVEMarketAPI.baseChart.Pye +
                    Item.Mex * Classes.CEVEMarketAPI.baseChart.Mex +
                    Item.Iso * Classes.CEVEMarketAPI.baseChart.Iso +
                    Item.Noc * Classes.CEVEMarketAPI.baseChart.Noc +
                    Item.Zyd * Classes.CEVEMarketAPI.baseChart.Zyd +
                    Item.Meg * Classes.CEVEMarketAPI.baseChart.Meg;

                newSearch.BasePrice = (newSearch.BasePrice * 0.724) / Item.Volume;
                newSearch.Size = Item.Size;
                lstSeach.Add(newSearch);
            }
            //查询，设置，显示
            Classes.CEVEMarketAPI.SearchPrice(lstSeach);
            frmOre frmResult = new frmOre();
            frmResult.SearchResult = Classes.CEVEMarketAPI.lstResult;
            frmResult.Show();
        }

        private void btnDrone_Click(object sender, EventArgs e)
        {
            //string strBase = "0000000100000011000000110000100000000001000000110000001100001000000000010000001100000011000010000000000100000011000000110000100000000001000000110000001100001000";

            string strBase = "01001010010100100010010100100011100100100100101001001000100111010101001";
            //strBase = txtInfo.Text.Trim();
            string strResult = "";
            int sub = strBase.Length % 4;
            if (sub != 0)
            {
                strBase = strBase.PadRight(strBase.Length + (8 - sub), '0');
            }

            for (int n = 0; n < Math.Ceiling((decimal)strBase.Length / 4); n++)
            {
                string strBin = strBase.Substring(n * 4, 4);
                int Value = Convert.ToInt32(strBin, 2);
                if (Value < 65)
                {
                    strResult += Value.ToString();
                }
                else
                {
                    char chString = (char)Value;
                    strResult += chString.ToString();
                }
            }
            MessageBox.Show(strResult);
        }

        private void btnT2High_Click(object sender, EventArgs e)
        {
            OpenFileDialog diaFile = new OpenFileDialog();
            diaFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            diaFile.CheckFileExists = true;
            diaFile.Filter = "xlsx|*.xlsx";
            diaFile.ShowDialog();

            string strFilePath = diaFile.FileName;

            if (string.IsNullOrEmpty(strFilePath))
            {
                return;
            }

            //读取蓝图数据
            Classes.CEVEMarketFile.ExcelT2High(strFilePath);

            //查询用对象
            List<Objects.SearchingItem> lstSeach = new List<Objects.SearchingItem>();

            List<string> lstSourceName = new List<string>();
            foreach (Objects.T2Base Item in Classes.CEVEMarketFile.lstT2High)
            {
                Objects.SearchingItem objSearch = new Objects.SearchingItem();
                objSearch.Name = Item.Name;

                foreach (string strSourceName in Item.Items.Keys)
                {
                    if (!lstSourceName.Contains(strSourceName))
                    {
                        lstSourceName.Add(strSourceName);
                    }
                }
                lstSeach.Add(objSearch);
            }

            foreach(string strName in lstSourceName)
            {
                lstSeach.Add(new Objects.SearchingItem() { Name = strName });
            }

            //查询，设置，显示
            Classes.CEVEMarketAPI.SearchPrice(lstSeach);

            foreach (Objects.T2Base Item in Classes.CEVEMarketFile.lstT2High)
            {
                double dBasePrice = 0;
                Objects.SearchingResult T2Item = Classes.CEVEMarketAPI.lstResult.Find(X => X.Name == Item.Name);
                foreach (string strKeys in Item.Items.Keys)
                {
                    //组件
                    Objects.SearchingResult result = Classes.CEVEMarketAPI.lstResult.Find(X => X.Name == strKeys);
                    if (result != null)
                    {
                        //组件挂单价
                        dBasePrice += double.Parse(result.Sell1) * Item.Items[strKeys];
                    }
                }
                //平均成本
                T2Item.BasePrice = dBasePrice / Item.Volume;
            }
            frmT2 frmResult = new frmT2();
            frmResult.SearchResult = Classes.CEVEMarketAPI.lstResult;
            frmResult.Show();

        }

        private void btnT2Work_Click(object sender, EventArgs e)
        {
            OpenFileDialog diaFile = new OpenFileDialog();
            diaFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            diaFile.CheckFileExists = true;
            diaFile.Filter = "xlsx|*.xlsx";
            diaFile.ShowDialog();

            string strFilePath = diaFile.FileName;

            if (string.IsNullOrEmpty(strFilePath))
            {
                return;
            }

            //读取蓝图数据
            Classes.CEVEMarketFile.ExcelT2Work(strFilePath);

            //查询用对象
            List<Objects.SearchingItem> lstSeach = new List<Objects.SearchingItem>();

            List<string> lstSourceName = new List<string>();
            foreach (Objects.T2Product Item in Classes.CEVEMarketFile.lstT2Product)
            {
                Objects.SearchingItem objSearch = new Objects.SearchingItem();
                objSearch.Name = Item.Name;

                foreach (string strSourceName in Item.Items.Keys)
                {
                    if (!lstSourceName.Contains(strSourceName))
                    {
                        lstSourceName.Add(strSourceName);
                    }
                }
                lstSeach.Add(objSearch);
            }

            foreach (string strName in lstSourceName)
            {
                lstSeach.Add(new Objects.SearchingItem() { Name = strName });
            }

            //查询，设置，显示
            Classes.CEVEMarketAPI.SearchPrice(lstSeach);

            foreach (Objects.T2Product Item in Classes.CEVEMarketFile.lstT2Product)
            {
                double dBasePrice = 0;
                Objects.SearchingResult T2Item = Classes.CEVEMarketAPI.lstResult.Find(X => X.Name == Item.Name);
                foreach (string strKeys in Item.Items.Keys)
                {
                    //组件
                    Objects.SearchingResult result = Classes.CEVEMarketAPI.lstResult.Find(X => X.Name == strKeys);
                    if (result != null)
                    {
                        //组件挂单价
                        dBasePrice += double.Parse(result.Sell1) * Item.Items[strKeys];
                    }
                }
                //平均成本
                T2Item.BasePrice = dBasePrice / Item.Volume;
            }
            frmT2 frmResult = new frmT2();
            frmResult.SearchResult = Classes.CEVEMarketAPI.lstResult;
            frmResult.Show();
        }



        private void btnAPICharaID_Click(object sender, EventArgs e)
        {
            //string strUserName = "绯舞之夜";
            //string strCharaID = Classes.ESICEVEAPI.SearchCharacter(strUserName);
            string strUserID = "90076612";
            //this.lblCharaID.Text = strCharaID;
            //Classes.ESICEVEAPI.SearchScope("1");
           
            string strToken = "https://esi.evepc.163.com/ui/oauth2-redirect.html#access_token=eyJhbGciOiJSUzI1NiIsImtpZCI6IkpXVC1TaWduYXR1cmUtS2V5IiwidHlwIjoiSldUIn0.eyJzY3AiOiJlc2ktYXNzZXRzLnJlYWRfYXNzZXRzLnYxIiwianRpIjoiNTY3ZGM1OWEtMWVkYi00OTY5LWIyMTktYWNkY2QwNzFkZjE5Iiwia2lkIjoiSldULVNpZ25hdHVyZS1LZXkiLCJzdWIiOiJDSEFSQUNURVI6RVZFOjkwMDc2NjEyIiwiYXpwIjoiYmM5MGFhNDk2YTQwNDcyNGE5M2Y0MWI0ZjRlOTc3NjEiLCJuYW1lIjoi57uv6Iie5LmL5aScIiwib3duZXIiOiJpa1V6SmFZVnFFeG5UUWFLMjBaN2l0MUlJeEU9IiwiZXhwIjoxNTkyNTkwODM4LCJpc3MiOiJsb2dpbi5ldmVwYy4xNjMuY29tIn0.DDnzDd46mjdSvUpfwXqMJ3RYKszFVuYF01atmhEiSonpQsLi3oqcN6gDihsb9xtu5ckb2tvbk7jOnkOjIL-koBhAEU1mF-aLMOAg7xMFav8WdGd4msy8JwayDvhYx5RFUTtd_58jDpiJN220lLDfUApoZ7r3iBYRZhitLUcYEm0SM-_G0AtSDIEXY3g_xHScuX4QX45JBSoJ6UzWqY322XojdHislpyGMp7tjEdNNhmxXU6rN3DAWzC6NMF9broNZluRzh6FLVui37hw2LpKP7fiupI0JPbzWkKBrzgVKAgxwrzznN09oLFiV6vKjyS9L3qm3hYErnCBEF2z1eq7Zw&expires_in=1199&state=kb_ceve_market";
            string strValue = strToken.Substring("https://esi.evepc.163.com/ui/oauth2-redirect.html#".Length);
            string[] value = strValue.Split('&');
            string strAccessToken = value[0].Split('=')[1];

            Classes.ESICEVEAPI.ReadAssets(strUserID, strAccessToken);

        }

        private void btnP4_Click(object sender, EventArgs e)
        {
            OpenFileDialog diaFile = new OpenFileDialog();
            diaFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            diaFile.CheckFileExists = true;
            diaFile.Filter = "xlsx|*.xlsx";
            diaFile.ShowDialog();

            string strFilePath = diaFile.FileName;

            if (string.IsNullOrEmpty(strFilePath))
            {
                return;
            }

            //读取蓝图数据
            Classes.CEVEMarketFile.ExcelP4Break(strFilePath);

            //查询用对象
            List<Objects.SearchingItem> lstSeach = new List<Objects.SearchingItem>();

            List<string> lstSourceName = new List<string>();
            foreach (Objects.T2Product Item in Classes.CEVEMarketFile.lstP4Break)
            {
                Objects.SearchingItem objSearch = new Objects.SearchingItem();
                objSearch.Name = Item.Name;

                foreach (string strSourceName in Item.Items.Keys)
                {
                    if (!lstSourceName.Contains(strSourceName))
                    {
                        lstSourceName.Add(strSourceName);
                    }
                }
                lstSeach.Add(objSearch);
            }

            foreach (string strName in lstSourceName)
            {
                lstSeach.Add(new Objects.SearchingItem() { Name = strName });
            }

            //查询，设置，显示
            Classes.CEVEMarketAPI.SearchPrice(lstSeach);

            foreach (Objects.T2Product Item in Classes.CEVEMarketFile.lstP4Break)
            {
                double dBasePrice = 0;
                Objects.SearchingResult T2Item = Classes.CEVEMarketAPI.lstResult.Find(X => X.Name == Item.Name);
                foreach (string strKeys in Item.Items.Keys)
                {
                    //组件
                    Objects.SearchingResult result = Classes.CEVEMarketAPI.lstResult.Find(X => X.Name == strKeys);
                    if (result != null)
                    {
                        //组件挂单价
                        dBasePrice += double.Parse(result.Buy1) * Item.Items[strKeys];
                    }
                }
                //平均成本
                T2Item.BasePrice = dBasePrice / Item.Volume;
            }
            frmOre frmResult = new frmOre();
            frmResult.SearchResult = Classes.CEVEMarketAPI.lstResult;
            frmResult.Show();
        }



        private void btnIceChart_Click(object sender, EventArgs e)
        {
            OpenFileDialog diaFile = new OpenFileDialog();
            diaFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            diaFile.CheckFileExists = true;
            diaFile.Filter = "xlsx|*.xlsx";
            diaFile.ShowDialog();

            string strFilePath = diaFile.FileName;

            if (string.IsNullOrEmpty(strFilePath))
            {
                return;
            }

            //读取蓝图数据
            Classes.CEVEMarketFile.ExcelIceChart(strFilePath);

            //查询用对象
            List<Objects.SearchingItem> lstSeach = new List<Objects.SearchingItem>();

            List<string> lstSourceName = new List<string>();
            foreach (Objects.OreCommon Item in Classes.CEVEMarketFile.lstOreCommon)
            {
                Objects.SearchingItem objSearch = new Objects.SearchingItem();
                objSearch.Name = Item.Name;

                foreach (string strSourceName in Item.Items.Keys)
                {
                    if (!lstSourceName.Contains(strSourceName))
                    {
                        lstSourceName.Add(strSourceName);
                    }
                }
                lstSeach.Add(objSearch);
            }

            foreach (string strName in lstSourceName)
            {
                lstSeach.Add(new Objects.SearchingItem() { Name = strName });
            }

            //查询，设置，显示
            Classes.CEVEMarketAPI.SearchPrice(lstSeach);

            foreach (Objects.OreCommon Item in Classes.CEVEMarketFile.lstOreCommon)
            {
                double dBasePrice = 0;
                Objects.SearchingResult IceItem = Classes.CEVEMarketAPI.lstResult.Find(X => X.Name == Item.Name);
                foreach (string strKeys in Item.Items.Keys)
                {
                    //组件
                    Objects.SearchingResult result = Classes.CEVEMarketAPI.lstResult.Find(X => X.Name == strKeys);
                    if (result != null)
                    {
                        //冰矿收单价
                        dBasePrice += double.Parse(result.Buy1) * Item.Items[strKeys];
                    }
                }
                //平均成本
                IceItem.BasePrice = (dBasePrice * 0.724) / Item.Volume;
            }

            frmIce frmResult = new frmIce();
            frmResult.SearchResult = Classes.CEVEMarketAPI.lstResult;
            frmResult.Show();

        }

        private void btnMoon_Click(object sender, EventArgs e)
        {
            OpenFileDialog diaFile = new OpenFileDialog();
            diaFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            diaFile.CheckFileExists = true;
            diaFile.Filter = "xlsx|*.xlsx";
            diaFile.ShowDialog();

            string strFilePath = diaFile.FileName;

            if (string.IsNullOrEmpty(strFilePath))
            {
                return;
            }

            //读取蓝图数据
            Classes.CEVEMarketFile.ExcelMoonChart(strFilePath);

            //查询用对象
            List<Objects.SearchingItem> lstSeach = new List<Objects.SearchingItem>();

            List<string> lstSourceName = new List<string>();
            foreach (Objects.OreCommon Item in Classes.CEVEMarketFile.lstOreCommon)
            {
                Objects.SearchingItem objSearch = new Objects.SearchingItem();
                objSearch.Name = Item.Name;

                foreach (string strSourceName in Item.Items.Keys)
                {
                    if (!lstSourceName.Contains(strSourceName))
                    {
                        lstSourceName.Add(strSourceName);
                    }
                }
                lstSeach.Add(objSearch);
            }

            foreach (string strName in lstSourceName)
            {
                lstSeach.Add(new Objects.SearchingItem() { Name = strName });
            }

            //查询，设置，显示
            Classes.CEVEMarketAPI.SearchPrice(lstSeach);

            foreach (Objects.OreCommon Item in Classes.CEVEMarketFile.lstOreCommon)
            {
                double dBasePrice = 0;
                Objects.SearchingResult IceItem = Classes.CEVEMarketAPI.lstResult.Find(X => X.Name == Item.Name);
                foreach (string strKeys in Item.Items.Keys)
                {
                    //组件
                    Objects.SearchingResult result = Classes.CEVEMarketAPI.lstResult.Find(X => X.Name == strKeys);
                    if (result != null)
                    {
                        //冰矿收单价
                        dBasePrice += double.Parse(result.Buy1) * Item.Items[strKeys];
                    }
                }
                //平均成本
                IceItem.BasePrice = (dBasePrice * 0.697) / 100;
            }

            frmIce frmResult = new frmIce();
            frmResult.SearchResult = Classes.CEVEMarketAPI.lstResult;
            frmResult.Show();
        }
    }
}
