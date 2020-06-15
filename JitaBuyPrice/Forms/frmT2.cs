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
    public partial class frmT2 : Form
    {
        public List<SearchingResult> SearchResult;

        public frmT2()
        {
            InitializeComponent();
            lvResult.Columns.Add("名称", 200);
            lvResult.Columns.Add("最低卖价", 200);
            lvResult.Columns.Add("最高买价", 200);
            lvResult.Columns.Add("采买成本", 200);
            lvResult.Columns.Add("利润倍率", 200);
            lvResult.Columns.Add("利润额度", 200);
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
                //1.4倍可以搞
                if (dRate > 1.4)
                {
                    li.SubItems[3].BackColor = Color.Red;
                }

                li.SubItems.Add(string.Format("{0:N}", dSell - dBase));
                ////1.4倍可以搞
                //if ((dSell / Result.BasePrice > 3))
                //{
                //    li.SubItems[3].BackColor = Color.Gold;
                //}

                //if ((dSell / Result.BasePrice < 0.5))
                //{
                //    li.SubItems[3].BackColor = Color.Green;
                //}
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
