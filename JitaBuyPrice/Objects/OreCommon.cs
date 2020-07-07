using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JitaBuyPrice.Objects
{
    public class OreCommon
    {
        //http://eve.grismar.net/ore/full.php
        string strName = string.Empty;
        //每次产量
        int nVolume = 0;

        Dictionary<string, int> dicItems = new Dictionary<string, int>();

        public string Name { get => strName; set => strName = value; }
        public int Volume { get => nVolume; set => nVolume = value; }
        public Dictionary<string, int> Items { get => dicItems; set => dicItems = value; }
    }
}
