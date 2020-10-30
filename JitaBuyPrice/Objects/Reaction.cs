using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JitaBuyPrice.Objects
{
    public class Reaction
    {
        //产物名字
        string name = string.Empty;
        double output = 0;

        //投入材料
        Dictionary<string, double> input = new Dictionary<string, double>();

        public string Name { get => name; set => name = value; }
        public double Output { get => output; set => output = value; }
        public Dictionary<string, double> Input { get => input; set => input = value; }

    }
}
