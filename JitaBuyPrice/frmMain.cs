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

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string strInfos = txtInfo.Text;

            if (string.IsNullOrWhiteSpace(strInfos))
            {
                return;
            }
            strInfos = strInfos.Replace("\r\n", "\n");

            //string strInfos = "X5持久型停滞缠绕光束\t2\t能量滞停光束网\n双联调制型轻型能量光束 I\t1\t能量武器\n外围设备紧凑型目标标记装置\t1\t目标标记装置\n小型传染视野型能量中和器\t1\t能量中和器\n抑制型强化舱隔壁 D型\t1\t加强型舱隔壁\n骤停紧凑型停滞缠绕光束\t5\t能量滞停光束网";
            string[] arrItems = strInfos.Split('\n');
            List<Objects.SearchingItem> lstSeach = new List<Objects.SearchingItem>();

            foreach (string Item in arrItems)
            {
                string[] arrProps = Item.Split('\t');
                Objects.SearchingItem newSearch = new Objects.SearchingItem();
                if (arrProps.Length > 0 && !string.IsNullOrEmpty(arrProps[0]))
                {
                    newSearch.Name = arrProps[0];
                }
                else
                {
                    continue;
                }
                if (arrProps.Length > 1)
                {
                    newSearch.Volume = int.Parse(arrProps[1].Replace(",", ""));
                }
                if (arrProps.Length > 2)
                {
                    newSearch.Category = arrProps[2];
                }
                lstSeach.Add(newSearch);
            }
            Classes.CEVEMarketAPI.SearchPrice(lstSeach);

            if (Classes.CEVEMarketAPI.lstResult.Count == 0)
            {
                return;
            }

            frmResultDialog frmResult = new frmResultDialog();
            frmResult.SearchResult = Classes.CEVEMarketAPI.lstResult;
            frmResult.Show();
        }

        private void btnImport_Click(object sender, EventArgs e)
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

            Classes.CEVEMarketFile.ExcelReader(strFilePath);
            lblResult.Text = "读入商品数：" + Classes.CEVEMarketFile.lstItem.Count;
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

            frmResultDialog frmResult = new frmResultDialog();
            frmResult.SearchResult = Classes.CEVEMarketAPI.lstResult;
            frmResult.Show();
        }

        private void btnBrain_Click(object sender, EventArgs e)
        {
            //40520	大型技能注入器
            //45635	小型技能注入器
            //查询用对象
            List<Objects.SearchingItem> lstSeach = new List<Objects.SearchingItem>();
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "40520", Name = "大型技能注入器" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "45635", Name = "小型技能注入器" });
            //查询，设置，显示
            Classes.CEVEMarketAPI.SearchPrice(lstSeach);
            double dSkillBasePrice = 0;
            double dBig = double.Parse(Classes.CEVEMarketAPI.lstResult[0].Sell1) / 150000;
            double dSmall = double.Parse(Classes.CEVEMarketAPI.lstResult[1].Sell1) / 30000;
            //每技能点价格
            dSkillBasePrice = Math.Min(dSmall, dBig);
            //额外15点每分钟，86400.00 s 生物学等级翻倍
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "54656", Name = "标准晨曦大脑加速器", BasePrice = 15 * 1440 * 2 * dSkillBasePrice });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "54976", Name = "六月限时大脑加速器", BasePrice = 7.5 * 720 * 2 * dSkillBasePrice });
            //不吃生物学
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "54812", Name = "基础型克隆飞行员之日大脑加速器", BasePrice = 6 * 1440 * dSkillBasePrice });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "54813", Name = "强效克隆飞行员之日大脑加速器", BasePrice = 12 * 1440 * dSkillBasePrice });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "54814", Name = "延展型克隆飞行员之日大脑加速器", BasePrice = 9 * 4320 * dSkillBasePrice });

            Classes.CEVEMarketAPI.SearchPrice(lstSeach);
            frmResultDialog frmResult = new frmResultDialog();
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
    }
}
