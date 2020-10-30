using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JitaBuyPrice.Objects
{
    public class SearchingItem
    {
        string strName;
        int nVolume = 0;
        string strCategory;
        string strItemID;
        double dBasePrice;
        double dSize;

        public string Name { get => strName; set => strName = value; }
        public int Volume { get => nVolume; set => nVolume = value; }
        public string Category { get => strCategory; set => strCategory = value; }
        public string ItemID { get => strItemID; set => strItemID = value; }
        public double BasePrice { get => dBasePrice; set => dBasePrice = value; }
        public double Size { get => dSize; set => dSize = value; }
    }
}
