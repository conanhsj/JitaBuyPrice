using JitaBuyPrice.Classes;
using JitaBuyPrice.ObjectsJson;
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
    public partial class frmPriceCache : Form
    {
        public frmPriceCache()
        {
            InitializeComponent();

            lvPriceCache.Columns.Add("名称", 130);
            lvPriceCache.Columns.Add("编号", 60);
            lvPriceCache.Columns.Add("最低卖价", 130);
            lvPriceCache.Columns.Add("最高买价", 130);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPriceCached();
        }

        private void frmPriceCache_Load(object sender, EventArgs e)
        {
            RefreshPriceCached();
        }

        private void RefreshPriceCached()
        {
            lvPriceCache.Items.Clear();
            foreach (Price price in CEVEMarketAPI.lstPriceCache)
            {
                if (string.IsNullOrEmpty(price.Name))
                {
                    Objects.Item target = CEVEMarketFile.lstItem.Find(obj => obj.TypeID == price.TypeId);
                    if (target != null)
                    {
                        price.Name = target.Name;
                    }
                }
                ListViewItem li = new ListViewItem(price.Name);
                li.UseItemStyleForSubItems = false;

                li.SubItems.Add(string.Format("{0:N}", price.TypeId));
                li.SubItems.Add(string.Format("{0:N2}", price.sell.min));
                li.SubItems.Add(string.Format("{0:N2}", price.buy.max));
                lvPriceCache.Items.Add(li);
            }
        }
    }
}
