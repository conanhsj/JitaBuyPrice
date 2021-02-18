using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace JitaBuyPrice.ObjectsYaml
{
    public class BluePrintYamlOther
    {
        public string Name = string.Empty;
        [YamlMember(Alias = "typeID", ApplyNamingConventions = false)]
        public string TypeID = string.Empty;
        [YamlMember(Alias = "quantity", ApplyNamingConventions = false)]
        public int Quantity = 0;
        [YamlMember(Alias = "level", ApplyNamingConventions = false)]
        public int Level = 0;
        [YamlMember(Alias = "probability", ApplyNamingConventions = false)]
        public double Probability = 0;
    }
}
