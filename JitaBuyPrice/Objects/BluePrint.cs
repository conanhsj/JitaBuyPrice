using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JitaBuyPrice.Objects
{
    public class BluePrint
    {
        public string BPName;
        public int TypeID;
        public int ProductID;
        public string ProductName;
        public int ProductQty;
        public List<BluePrintMtls> Materials = new List<BluePrintMtls>();


    }
}
