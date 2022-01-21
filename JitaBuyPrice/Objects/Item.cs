using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JitaBuyPrice.Objects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Item
    {
        string strTypeID = string.Empty;
        string strName = string.Empty;
        string strDescript = string.Empty;
        string strCategory1 = string.Empty;
        string strCategory2 = string.Empty;
        string strCategory3 = string.Empty;
        string strCategory4 = string.Empty;
        string strCategory5 = string.Empty;
        string strCategory6 = string.Empty;

        [JsonProperty]
        public string TypeID { get => strTypeID; set => strTypeID = value; }
        [JsonProperty]
        public string Name { get => strName; set => strName = value; }
        [JsonIgnore]
        public string Descript { get => strDescript; set => strDescript = value; }
        [JsonIgnore]
        public string Category1 { get => strCategory1; set => strCategory1 = value; }
        public string Category2 { get => strCategory2; set => strCategory2 = value; }
        public string Category3 { get => strCategory3; set => strCategory3 = value; }
        public string Category4 { get => strCategory4; set => strCategory4 = value; }
        public string Category5 { get => strCategory5; set => strCategory5 = value; }
        public string Category6 { get => strCategory6; set => strCategory6 = value; }
    }
}
