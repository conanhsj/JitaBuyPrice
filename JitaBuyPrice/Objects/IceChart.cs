using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JitaBuyPrice.Objects
{
    public class IceChart
    {
        //http://eve.grismar.net/ore/full.php
        //Isotopes	Liquid Ozone	Heavy Water	
        double dA_Helium_Isotopesogen = 0;
        //类胶
        double dG_Oxy_Isotopesogen = 0;
        //类银
        double dM_Hydro_Isotopesogen = 0;
        //加达里,氮
        double dC_Nitro_Isotopesogen = 0;
        //超新星诺克石
        double dLqOzone = 0;
        //重水
        double dHvWater = 0;
        //锶包合物
        double dStrontium = 0;

        public double A_Helium_Isotopesogen { get => dA_Helium_Isotopesogen; set => dA_Helium_Isotopesogen = value; }
        public double G_Oxy_Isotopesogen { get => dG_Oxy_Isotopesogen; set => dG_Oxy_Isotopesogen = value; }
        public double M_Hydro_Isotopesogen { get => dM_Hydro_Isotopesogen; set => dM_Hydro_Isotopesogen = value; }
        public double C_Nitro_Isotopesogen { get => dC_Nitro_Isotopesogen; set => dC_Nitro_Isotopesogen = value; }
        public double LqOzone { get => dLqOzone; set => dLqOzone = value; }
        public double HvWater { get => dHvWater; set => dHvWater = value; }
        public double Strontium { get => dStrontium; set => dStrontium = value; }
    }
}
