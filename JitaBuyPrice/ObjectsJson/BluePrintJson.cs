using JitaBuyPrice.ObjectsYaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JitaBuyPrice.ObjectsJson
{
    public class BluePrintJson
    {
        public string Name = string.Empty;
        public string TypeID = string.Empty;
        public List<BluePrintYamlMaterials> Materials = new List<BluePrintYamlMaterials>();
        public List<BluePrintYamlMaterials> Products = new List<BluePrintYamlMaterials>();
    }
}
