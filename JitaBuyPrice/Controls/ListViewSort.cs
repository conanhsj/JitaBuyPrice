using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JitaBuyPrice.Controls
{
    public class ListViewSort : IComparer
    {
        private int nColIndex;
        public ListViewSort(int Col)
        {
            nColIndex = Col;
        }

        public int Compare(object x, object y)
        {
            string strValueX = ((ListViewItem)x).SubItems[nColIndex].Text;
            string strValueY = ((ListViewItem)y).SubItems[nColIndex].Text;

            double dValueX = ReadDouble(strValueX);
            double dValueY = ReadDouble(strValueY);
            if (dValueX != 0)
            {
                bool tempInt = dValueX > dValueY;
                return tempInt ? -1 : 1;
            }
            else
            {
                int tempInt = String.Compare(strValueX, strValueY);
                return -tempInt;
            }
        }

        private double ReadDouble(string strCell)
        {
            double dRnt = 0;
            strCell = strCell.Replace(",", "");
            double.TryParse(strCell, out dRnt);
            return dRnt;
        }
    }
}
