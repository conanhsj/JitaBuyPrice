using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace JitaBuyPrice.ObjectsYaml
{
    public class BluePrintYamlInvention : Dictionary<string, BluePrintYamlInvention>
    {
        [YamlMember(Alias = "time", ApplyNamingConventions = false)]
        public int Time = 0;
        //public  manufacturing
        [YamlMember(Alias = "materials", ApplyNamingConventions = false)]
        public List<BluePrintYamlOther> lstMaterials = new List<BluePrintYamlOther>();

        [YamlMember(Alias = "products", ApplyNamingConventions = false)]
        public List<BluePrintYamlOther> lstProducts = new List<BluePrintYamlOther>();
    }
}
