using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace JitaBuyPrice.ObjectsYaml
{
    public class BluePrintYamlManu : Dictionary<string, object>
    {
        [YamlMember(Alias = "time", ApplyNamingConventions = false)]
        public int Time = 0;
        //public  manufacturing
        [YamlMember(Alias = "materials", ApplyNamingConventions = false)]
        public List<BluePrintYamlMaterials> lstMaterials = new List<BluePrintYamlMaterials>();

        [YamlMember(Alias = "products", ApplyNamingConventions = false)]
        public List<BluePrintYamlMaterials> lstProducts = new List<BluePrintYamlMaterials>();

        [YamlMember(Alias = "skills", ApplyNamingConventions = false)]
        public List<BluePrintYamlOther> lstSkills = new List<BluePrintYamlOther>();
    }
}
