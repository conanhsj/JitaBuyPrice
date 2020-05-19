using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JitaBuyPrice.Objects
{
    public class SearchingResult
    {
        string strName;
        string strVolume;
        string strBuy1;
        string strBuy1Volume;
        string strSell1;
        string strSell1Volume;
        double strBasePrice = 0;

        public string Name { get => strName; set => strName = value; }
        public string Buy1 { get => strBuy1; set => strBuy1 = value; }
        public string Buy1Volume { get => strBuy1Volume; set => strBuy1Volume = value; }
        public string Sell1 { get => strSell1; set => strSell1 = value; }
        public string Sell1Volume { get => strSell1Volume; set => strSell1Volume = value; }
        public string Volume { get => strVolume; set => strVolume = value; }
        public double BasePrice { get => strBasePrice; set => strBasePrice = value; }
    }
}
