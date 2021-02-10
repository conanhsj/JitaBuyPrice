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
    public partial class frmLoginESI : Form
    {
        public string AccessToken = string.Empty;
        public frmLoginESI()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strToken = txtESIKey.Text;
            if (string.IsNullOrWhiteSpace(strToken))
            {
                return;
            }
            string strValue = strToken.Substring("https://esi.evepc.163.com/ui/oauth2-redirect.html#".Length);
            string[] value = strValue.Split('&');
            this.AccessToken = value[0].Split('=')[1];
            this.Close();
        }
    }
}
