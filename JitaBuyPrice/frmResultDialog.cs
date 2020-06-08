using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JitaBuyPrice.Objects;

namespace JitaBuyPrice
{
    public partial class frmResultDialog : Form
    {

        public List<SearchingResult> SearchResult;

        public frmResultDialog()
        {
            InitializeComponent();
            lvResult.Columns.Add("名称", 200);
            lvResult.Columns.Add("最低卖价", 200);
            lvResult.Columns.Add("最高买价", 200);
            lvResult.Columns.Add("卖单总量", 200);


            lvResult.Columns.Add("估算总卖价", 200);
            lvResult.Columns.Add("估算总卖价 * 95%", 200);
            lvResult.Columns.Add("估算总买价 * 97.5", 200);
            lvResult.Columns.Add("估算总买价 * 120%", 200);
            lvResult.Columns.Add("成本价", 200);
        }

        private void frmResultDialog_Load(object sender, EventArgs e)
        {
            double dSumAllSell = 0;
            double dSumAllBuy = 0;

            foreach (SearchingResult Result in this.SearchResult)
            {
                ListViewItem li = new ListViewItem(Result.Name);
                li.UseItemStyleForSubItems = false;

                double dSell = double.Parse(Result.Sell1);
                double dBuy = double.Parse(Result.Buy1);
                li.SubItems.Add(string.Format("{0:N}", dSell));
                li.SubItems.Add(string.Format("{0:N}", dBuy));
                //利润空间不足可能有人卡货
                if (dSell / dBuy < 1.1)
                {
                    li.SubItems[1].BackColor = Color.Green;
                }
                //利润空间充足考虑补货
                else if (dSell / dBuy > 1.7)
                {
                    li.SubItems[1].BackColor = Color.Red;
                }

                //当总量不足1000时可以考虑扫货
                li.SubItems.Add(Result.Sell1Volume);
                if (double.Parse(Result.Sell1Volume) < 1000)
                {
                    li.SubItems[3].BackColor = Color.Red;
                }
                if (string.IsNullOrEmpty(Result.Volume))
                {
                    continue;
                }

                double AllSell = dSell * int.Parse(Result.Volume);
                double AllBuy = dBuy * int.Parse(Result.Volume);

                dSumAllSell += AllSell;
                dSumAllBuy += AllBuy;
                li.SubItems.Add(string.Format("{0:N}", AllSell));
                li.SubItems.Add(string.Format("{0:N}", AllSell * 0.90));
                li.SubItems.Add(string.Format("{0:N}", AllBuy * 0.975));
                li.SubItems.Add(string.Format("{0:N}", AllBuy * 1.2));

                li.SubItems.Add(string.Format("{0:N}", Result.BasePrice));

                //1.4倍可以搞
                if ((dSell / Result.BasePrice > 1.4) ||
                    (dSell / Result.BasePrice > 1.2 && dSell - Result.BasePrice > 2000000))
                {
                    li.SubItems[8].BackColor = Color.Red;
                }
                //1.4倍可以搞
                if ((dSell / Result.BasePrice > 3) )
                {
                    li.SubItems[8].BackColor = Color.Gold;
                }

                if ((dSell / Result.BasePrice < 0.5))
                {
                    li.SubItems[8].BackColor = Color.Green;
                }
                lvResult.Items.Add(li);
            }

            ListViewItem liSum = new ListViewItem("合算");
            liSum.SubItems.Add("");
            liSum.SubItems.Add("");
            liSum.SubItems.Add("");
            liSum.SubItems.Add(string.Format("{0:N}", dSumAllSell));
            liSum.SubItems.Add(string.Format("{0:N}", dSumAllSell * 0.90));
            liSum.SubItems.Add(string.Format("{0:N}", dSumAllBuy * 0.975));
            liSum.SubItems.Add(string.Format("{0:N}", dSumAllBuy * 1.2));
            liSum.SubItems.Add("");
            lvResult.Items.Add(liSum);


            lvResult.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void lvResult_ItemActivate(object sender, EventArgs e)
        {
            ListView lvSender = (ListView)sender;
            Clipboard.SetText(lvSender.FocusedItem.Text);
        }
    }
}
