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
    public partial class frmIce : Form
    {
        public List<SearchingResult> SearchResult;

        public frmIce()
        {
            InitializeComponent();
            lvResult.Columns.Add("名称", 200);
            lvResult.Columns.Add("最低卖价", 200);
            lvResult.Columns.Add("最高买价", 200);
            lvResult.Columns.Add("72.4化矿直卖价+97.75%税", 200);
        }

        private void frmOre_Load(object sender, EventArgs e)
        {

            foreach (SearchingResult Result in this.SearchResult)
            {
                ListViewItem li = new ListViewItem(Result.Name);
                li.UseItemStyleForSubItems = false;

                double dSell = double.Parse(Result.Sell1);
                double dBuy = double.Parse(Result.Buy1);
                double dBase = Result.BasePrice * 0.9775;
                li.SubItems.Add(string.Format("{0:N}", dSell));
                li.SubItems.Add(string.Format("{0:N}", dBuy));
                li.SubItems.Add(string.Format("{0:N}", (dBase).ToString("0.00")));


                //1.4倍可以搞
                if (dSell != 0 && dSell < dBase)
                {
                    li.SubItems[3].BackColor = Color.Red;
                }

                lvResult.Items.Add(li);
            }

            lvResult.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void lvResult_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                ListView lvSender = (ListView)sender;
                Clipboard.Clear();
                Clipboard.SetText(lvSender.FocusedItem.Text);
            }
            catch
            {

            }
        }
    }
}
