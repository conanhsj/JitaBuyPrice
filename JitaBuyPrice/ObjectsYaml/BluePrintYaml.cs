using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace JitaBuyPrice.ObjectsYaml
{
    public class BluePrintYaml
    {
        public string Name = string.Empty;
        [YamlMember(Alias = "blueprintTypeID", ApplyNamingConventions = false)]
        public int TypeID = 0;
        [YamlMember(Alias = "activities", ApplyNamingConventions = false)]
        public BluePrintYamlActivities Activities = new BluePrintYamlActivities();
        [YamlMember(Alias = "maxProductionLimit", ApplyNamingConventions = false)]
        public int Limit = 0;


    }
}
