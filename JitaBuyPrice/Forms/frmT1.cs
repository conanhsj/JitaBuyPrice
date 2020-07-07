using JitaBuyPrice.Controls;
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
    public partial class frmT1 : Form
    {
        public List<SearchingResult> SearchResult;

        public frmT1()
        {
            InitializeComponent();
            lvResult.Columns.Add("名称", 200);
            lvResult.Columns.Add("最低卖价", 200);
            lvResult.Columns.Add("最高买价", 200);
            lvResult.Columns.Add("矿物成本", 200);
            lvResult.Columns.Add("利润倍率", 200);
            lvResult.Columns.Add("利润额度", 200);
            lvResult.HeaderStyle = ColumnHeaderStyle.Clickable;
            lvResult.ColumnClick += LvResult_ColumnClick;
        }

        private void LvResult_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvResult.ListViewItemSorter = new ListViewSort(e.Column);
            lvResult.Sort();
        }

        private void frmOre_Load(object sender, EventArgs e)
        {

            foreach (SearchingResult Result in this.SearchResult)
            {
                ListViewItem li = new ListViewItem(Result.Name);
                li.UseItemStyleForSubItems = false;

                double dSell = double.Parse(Result.Sell1);
                double dBuy = double.Parse(Result.Buy1);
                double dBase = Result.BasePrice;
                li.SubItems.Add(string.Format("{0:N}", dSell));
                li.SubItems.Add(string.Format("{0:N}", dBuy));
                li.SubItems.Add(string.Format("{0:N}", dBase));

                double dRate = dSell / dBase;
                li.SubItems.Add(string.Format("{0:N}", dRate));


                if (dSell / dBuy >1.6)
                {
                    li.SubItems[1].BackColor = Color.Red;
                }

                if (dSell / dBuy > 2)
                {
                    li.SubItems[1].BackColor = Color.Gold;
                }

                //1.4倍可以搞
                if ((dSell / Result.BasePrice > 1.4) ||
                    (dSell / Result.BasePrice > 1.2 && dSell - Result.BasePrice > 2000000))
                {
                    li.SubItems[3].BackColor = Color.Red;
                }
                //1.4倍可以搞
                if ((dSell / Result.BasePrice > 3))
                {
                    li.SubItems[3].BackColor = Color.Gold;
                }
                li.SubItems.Add(string.Format("{0:N}", dSell - dBase));
                if ((dSell / Result.BasePrice < 0.5))
                {
                    li.SubItems[3].BackColor = Color.Green;
                }
                lvResult.Items.Add(li);
            }

            lvResult.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void lvResult_ItemActivate(object sender, EventArgs e)
        {
            ListView lvSender = (ListView)sender;
            Clipboard.Clear();
            Clipboard.SetText(lvSender.FocusedItem.Text);
        }
    }
}
