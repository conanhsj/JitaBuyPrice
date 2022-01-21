using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace JitaBuyPrice.ObjectsYaml
{
    public class BluePrintYamlActivities
    {
        [YamlMember(Alias = "copying", ApplyNamingConventions = false)]
        public BluePrintYamlCopy Copying = new BluePrintYamlCopy();
        [YamlMember(Alias = "invention", ApplyNamingConventions = false)]
        public BluePrintYamlInvention Invention = new BluePrintYamlInvention();
        [YamlMember(Alias = "manufacturing", ApplyNamingConventions = false)]
        public BluePrintYamlManu Manufacturing = new BluePrintYamlManu();
        [YamlMember(Alias = "research_material", ApplyNamingConventions = false)]
        public BluePrintYamlRsrchMater ResearchMaterial = new BluePrintYamlRsrchMater();
        [YamlMember(Alias = "research_time", ApplyNamingConventions = false)]
        public BluePrintYamlRsrchTime ResearchTime = new BluePrintYamlRsrchTime();
        [YamlMember(Alias = "reaction", ApplyNamingConventions = false)]
        public BluePrintYamlReaction Reaction = new BluePrintYamlReaction();

    }
}
