using JitaBuyPrice.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JitaBuyPrice.Forms
{
    public partial class frmBrave : Form
    {
        public List<SearchingResult> SearchResult;

        public frmBrave()
        {
            InitializeComponent();
            lvResult.Columns.Add("名称", 200);
            lvResult.Columns.Add("最低卖价", 200);
            lvResult.Columns.Add("最高买价", 200);
        }

        private void frmBrave_Load(object sender, EventArgs e)
        {
            double dMoneyPlex = 0;
            double dMoneySubPlex = 0;
            double dMoneyInjector = 0;
            double dMoneyExtractor = 0;

            foreach (SearchingResult Result in this.SearchResult)
            {
                double dSell = double.Parse(Result.Sell1);
                double dBuy = double.Parse(Result.Buy1);

                if (Result.Name == "伊甸币")
                {
                    ListViewItem li = new ListViewItem("月卡(500)");
                    li.UseItemStyleForSubItems = false;

                    li.SubItems.Add(string.Format("{0:N}", dSell * 500));
                    li.SubItems.Add(string.Format("{0:N}", dBuy * 500));
                    dMoneyPlex = dSell * 500;
                    lvResult.Items.Add(li);


                    ListViewItem subChara = new ListViewItem("多任务训练(485)");
                    subChara.UseItemStyleForSubItems = false;

                    subChara.SubItems.Add(string.Format("{0:N}", dSell * 485));
                    subChara.SubItems.Add(string.Format("{0:N}", dBuy * 485));
                    dMoneySubPlex = dSell * 485;
                    lvResult.Items.Add(subChara);
                }
                else if (Result.Name == "技能提取器")
                {
                    ListViewItem li = new ListViewItem("针头(4)");
                    li.UseItemStyleForSubItems = false;

                    li.SubItems.Add(string.Format("{0:N}", dSell * 4));
                    li.SubItems.Add(string.Format("{0:N}", dBuy * 4));
                    dMoneyExtractor = dSell * 4;
                    lvResult.Items.Add(li);
                }
                else if (Result.Name == "大型技能注入器")
                {
                    ListViewItem li = new ListViewItem("脑浆(4)");
                    li.UseItemStyleForSubItems = false;

                    li.SubItems.Add(string.Format("{0:N}", dSell * 4));
                    li.SubItems.Add(string.Format("{0:N}", dBuy * 4));

                    lvResult.Items.Add(li);

                    ListViewItem liBase = new ListViewItem(Result.Name);
                    liBase.UseItemStyleForSubItems = false;

                    liBase.SubItems.Add(string.Format("{0:N}", dSell));
                    liBase.SubItems.Add(string.Format("{0:N}", dBuy));
                    lvResult.Items.Add(liBase);
                }
                else if (Result.Name == "小型技能注入器")
                {
                    ListViewItem li = new ListViewItem("合成小脑浆(5)");
                    li.UseItemStyleForSubItems = false;

                    li.SubItems.Add(string.Format("{0:N}", dSell * 5));
                    li.SubItems.Add(string.Format("{0:N}", dBuy * 5));

                    lvResult.Items.Add(li);

                    ListViewItem liBase = new ListViewItem(Result.Name);
                    liBase.UseItemStyleForSubItems = false;

                    liBase.SubItems.Add(string.Format("{0:N}", dSell));
                    liBase.SubItems.Add(string.Format("{0:N}", dBuy));
                    lvResult.Items.Add(liBase);
                }
                else
                {
                    ListViewItem li = new ListViewItem(Result.Name);
                    li.UseItemStyleForSubItems = false;

                    li.SubItems.Add(string.Format("{0:N}", dSell));
                    li.SubItems.Add(string.Format("{0:N}", dBuy));
                    lvResult.Items.Add(li);
                }
            }
            lvResult.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            double dMonth = ((dMoneyPlex + dMoneyExtractor) / (100000000));
            double dMonthSub = ((dMoneySubPlex + dMoneyExtractor) / (100000000));
            this.lblResult.Text = "月卡+4针头：" + dMonth.ToString() + "亿\n" +
                              "多人物训练+4针头：" + dMonthSub.ToString() + "亿\n";
        }

    }
}
