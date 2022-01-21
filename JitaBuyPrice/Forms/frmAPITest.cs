using JitaBuyPrice.Classes;
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
    public partial class frmAPITest : Form
    {
        public frmAPITest()
        {
            InitializeComponent();
        }

        private void btnZGJM_Click(object sender, EventArgs e)
        {
           string strResult = OtherNetApis.ReadZGJMWorm("ABCD");
        }

        private void btnSetu_Click(object sender, EventArgs e)
        {
            string strResult = OtherNetApis.getSetu();
        }
    }
}
