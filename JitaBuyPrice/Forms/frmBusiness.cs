using JitaBuyPrice.Objects;
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

namespace JitaBuyPrice.Forms
{
    public partial class frmBusiness : Form
    {
        public frmBusiness()
        {
            InitializeComponent();
            lvBase.Columns.Add("材料", 85);
            lvBase.Columns.Add("卖单", 60);
            lvBase.Columns.Add("收单", 60);

            lvLower.Columns.Add("材料", 85);
            lvLower.Columns.Add("卖单", 60);
            lvLower.Columns.Add("收单", 60);
            lvLower.Columns.Add("材料", 115);
            lvLower.Columns.Add("卖单", 60);
            lvLower.Columns.Add("收单", 60);
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            string strExePath = Environment.CurrentDirectory;
            string[] Files = Directory.GetFiles(strExePath, "化矿文档.xlsx", SearchOption.AllDirectories);

            if (Files.Length > 0)
            {
                //读取蓝图数据
                Classes.CEVEMarketFile.ExcelOreRecycle(Files[0]);
                MessageBox.Show("化矿文件读取完毕");
            }
        }

        private void frmBusiness_Load(object sender, EventArgs e)
        {
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += Bgw_DoWork;
            bgw.RunWorkerAsync();

            ReadMineral();

            //查询用对象
            List<SearchingItem> lstSeach = ReadOrc();

            //查询，设置，显示
            Classes.CEVEMarketAPI.SearchPrice(lstSeach);

            SetListView(lvLower, "凡晶石");
            SetListView(lvLower, "富凡晶石");
            SetListView(lvLower, "厚质凡晶石");
            SetListView(lvLower, "灼烧岩");
            SetListView(lvLower, "浓缩灼烧岩");
            SetListView(lvLower, "厚灼烧岩");
            SetListView(lvLower, "干焦岩");
            SetListView(lvLower, "固体干焦岩");
            SetListView(lvLower, "流体干焦岩");
            SetListView(lvLower, "斜长岩");
            SetListView(lvLower, "蓝色斜长岩");
            SetListView(lvLower, "富斜长岩");
            SetListView(lvLower, "水硼砂");
            SetListView(lvLower, "发光水硼砂");
            SetListView(lvLower, "灼热水硼砂");

        }

        private static List<SearchingItem> ReadOrc()
        {
            List<Objects.SearchingItem> lstSeach = new List<Objects.SearchingItem>();
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "1230", Name = "凡晶石" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "17470", Name = "富凡晶石" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "17471", Name = "厚质凡晶石" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "28432", Name = "高密度凡晶石" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "28430", Name = "高密度富凡晶石" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "28431", Name = "高密度厚质凡晶石" });

            lstSeach.Add(new Objects.SearchingItem() { ItemID = "1228", Name = "灼烧岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "17463", Name = "浓缩灼烧岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "17464", Name = "厚灼烧岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "28429", Name = "高密度灼烧岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "28427", Name = "高密度浓缩灼烧岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "28428", Name = "高密度厚灼烧岩" });

            lstSeach.Add(new Objects.SearchingItem() { ItemID = "1224", Name = "干焦岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "17459", Name = "固体干焦岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "17460", Name = "流体干焦岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "28424", Name = "高密度干焦岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "28425", Name = "高密度固体干焦岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "28426", Name = "高密度流体干焦岩" });

            lstSeach.Add(new Objects.SearchingItem() { ItemID = "18", Name = "斜长岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "17455", Name = "蓝色斜长岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "17456", Name = "富斜长岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "28421", Name = "高密度蓝色斜长岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "28422", Name = "高密度斜长岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "28423", Name = "高密度富斜长岩" });

            lstSeach.Add(new Objects.SearchingItem() { ItemID = "20", Name = "水硼砂" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "17452", Name = "发光水硼砂" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "17453", Name = "灼热水硼砂" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "28409", Name = "高密度灼热水硼砂" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "28410", Name = "高密度水硼砂" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "28411", Name = "高密度发光水硼砂" });

            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "1227", Name = "奥贝尔石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17867", Name = "银色奥贝尔石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17868", Name = "金色奥贝尔石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28415", Name = "高密度金色奥贝尔石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28416", Name = "高密度奥贝尔石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28417", Name = "高密度银色奥贝尔石" });

            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "1226", Name = "杰斯贝矿" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17448", Name = "纯杰斯贝矿" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17449", Name = "朴质杰斯贝矿" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28406", Name = "高密度杰斯贝矿" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28408", Name = "高密度纯杰斯贝矿" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28407", Name = "高密度朴质杰斯贝矿" });

            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "1231", Name = "希莫非特" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17444", Name = "多色希莫非特" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17445", Name = "辐射希莫非特" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28403", Name = "高密度希莫非特" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28404", Name = "高密度辐射希莫非特" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28405", Name = "高密度多色希莫非特" });

            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "21", Name = "同位原矿" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17440", Name = "玻璃状同位原矿" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17441", Name = "光面同位原矿" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28400", Name = "高密度光面同位原矿" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28401", Name = "高密度同位原矿" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28402", Name = "高密度玻璃状同位原矿" });

            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "1229", Name = "片麻岩" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17865", Name = "彩色片麻岩" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17866", Name = "棱柱片麻岩" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28397", Name = "高密度片麻岩" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28398", Name = "高密度彩色片麻岩" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28399", Name = "高密度棱柱片麻岩" });

            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "1230", Name = "凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17470", Name = "富凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17471", Name = "厚质凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28432", Name = "高密度凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28430", Name = "高密度富凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28431", Name = "高密度厚质凡晶石" });

            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "1230", Name = "凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17470", Name = "富凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17471", Name = "厚质凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28432", Name = "高密度凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28430", Name = "高密度富凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28431", Name = "高密度厚质凡晶石" });

            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "1230", Name = "凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17470", Name = "富凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17471", Name = "厚质凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28432", Name = "高密度凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28430", Name = "高密度富凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28431", Name = "高密度厚质凡晶石" });

            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "1230", Name = "凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17470", Name = "富凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17471", Name = "厚质凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28432", Name = "高密度凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28430", Name = "高密度富凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28431", Name = "高密度厚质凡晶石" });

            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "1230", Name = "凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17470", Name = "富凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "17471", Name = "厚质凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28432", Name = "高密度凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28430", Name = "高密度富凡晶石" });
            //lstSeach.Add(new Objects.SearchingItem() { ItemID = "28431", Name = "高密度厚质凡晶石" });
            return lstSeach;
        }

        private void SetListView(ListView view, string strOrc)
        {
            SearchingResult Result = Classes.CEVEMarketAPI.lstResult.Find(X => { return X.Name == strOrc; });
            ListViewItem li = new ListViewItem(Result.Name);
            li.UseItemStyleForSubItems = false;

            li.SubItems.Add(string.Format("{0:N}", double.Parse(Result.Sell1)));
            li.SubItems.Add(string.Format("{0:N}", double.Parse(Result.Buy1)));
            Result = Classes.CEVEMarketAPI.lstResult.Find(X => { return X.Name == "高密度" + strOrc; });
            li.SubItems.Add(Result.Name);
            li.SubItems.Add(string.Format("{0:N}", double.Parse(Result.Sell1)));
            li.SubItems.Add(string.Format("{0:N}", double.Parse(Result.Buy1)));
            view.Items.Add(li);
        }

        private void ReadMineral()
        {
            //查询用对象
            List<Objects.SearchingItem> lstSeach = new List<Objects.SearchingItem>();
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "34", Name = "三钛合金" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "35", Name = "类晶体胶矿" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "36", Name = "类银超金属" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "37", Name = "同位聚合体" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "38", Name = "超新星诺克石" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "39", Name = "晶状石英核岩" });
            lstSeach.Add(new Objects.SearchingItem() { ItemID = "40", Name = "超噬矿" });
            //查询，设置，显示
            Classes.CEVEMarketAPI.SearchPrice(lstSeach);


            foreach (SearchingResult Result in Classes.CEVEMarketAPI.lstResult)
            {
                double dSell = double.Parse(Result.Sell1);
                double dBuy = double.Parse(Result.Buy1);

                ListViewItem li = new ListViewItem(Result.Name);
                li.UseItemStyleForSubItems = false;

                //材料效率减免
                li.SubItems.Add(string.Format("{0:N}", dSell));
                li.SubItems.Add(string.Format("{0:N}", dBuy));
                lvBase.Items.Add(li);
            }
        }

        private void lvLower_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            string strRate = txtRate.Text;
            string strOreName = e.Item.Text;
            double dRate = Commons.ReadDouble(string.Format("{0:N2}", strRate));

            if (!string.IsNullOrEmpty(strOreName))
            {
                Objects.Ore ore = Classes.CEVEMarketFile.lstOre.Find(X => { return X.Name == strOreName; });

            }


        }
    }
}
