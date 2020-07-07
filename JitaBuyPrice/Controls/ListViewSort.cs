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

            if(ReadDouble(strValueX) > 0)
            {
                double tempInt = ReadDouble(strValueX) - ReadDouble(strValueY);
                return -(int)tempInt;
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
