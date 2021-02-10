using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace JitaBuyPrice.ObjectsYaml
{
    public class MaterialsInfo
    {
        public string Name = string.Empty;
        [YamlMember(Alias = "materialTypeID", ApplyNamingConventions = false)]
        public string TypeID = string.Empty;
        [YamlMember(Alias = "quantity", ApplyNamingConventions = false)]
        public int Quantity = 0;
    }
}
