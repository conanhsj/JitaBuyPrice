using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JitaBuyPrice
{
    public static class Commons
    {
        public static double ReadDouble(string strCell)
        {
            double dRnt = 0;
            strCell = strCell.Replace(",", "");
            if (!double.TryParse(strCell, out dRnt))
            {
                MessageBox.Show("数值转换错误:"+ strCell);
            }
            return dRnt;
        }

    }
}
