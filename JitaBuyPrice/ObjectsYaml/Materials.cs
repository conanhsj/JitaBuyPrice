using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace JitaBuyPrice.ObjectsYaml
{
    public class Materials
    {
        public string Name = string.Empty;

        public string TypeID = string.Empty;

        [YamlMember(Alias = "materials", ApplyNamingConventions = false)]
        public List<MaterialsInfo> lstItem = new List<MaterialsInfo>();
    }
}
