using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace JitaBuyPrice.ObjectsYaml
{
    public class BluePrintYamlActivities : Dictionary<string, object>
    {
        [YamlMember(Alias = "copying", ApplyNamingConventions = false)]
        public Dictionary<string, object> Copying = new Dictionary<string, object>();
        [YamlMember(Alias = "invention", ApplyNamingConventions = false)]
        public BluePrintYamlInvention Invention = new BluePrintYamlInvention();
        [YamlMember(Alias = "manufacturing", ApplyNamingConventions = false)]
        public BluePrintYamlMaterials Manufacturing = new BluePrintYamlMaterials();
        [YamlMember(Alias = "research_material", ApplyNamingConventions = false)]
        public Dictionary<string, object> ResearchMaterial = new Dictionary<string, object>();
        [YamlMember(Alias = "research_time", ApplyNamingConventions = false)]
        public Dictionary<string, object> ResearchTime = new Dictionary<string, object>();

        [YamlMember(Alias = "time", ApplyNamingConventions = false)]
        public int Time = 0;

    }
}
