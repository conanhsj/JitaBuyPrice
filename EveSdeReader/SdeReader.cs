using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;

namespace EveSdeReader
{
    public class SdeReader
    {
        public static Dictionary<string, object> ReadYmlFile(string strFileName)
        {
            Dictionary<string, object> target = new Dictionary<string, object>();
            string strBasePath = Constants.strBaseFolder;
            List<string> lstFile =  Directory.EnumerateFiles(strBasePath + @"\SDE", strFileName + ".yaml", SearchOption.AllDirectories).ToList();
            if(lstFile.Count <= 0)
            {
                return target;
            }
            string strFile = lstFile[0];
            using (var sr = new StreamReader(strFile, Encoding.UTF8))
            {

                YamlStream ys = new YamlStream();
                ys.Load(sr);

                if (ys.Documents[0].RootNode.NodeType == YamlNodeType.Mapping)
                {
                    YamlMappingNode node = (YamlMappingNode)ys.Documents[0].RootNode;
                    foreach(KeyValuePair<YamlNode ,YamlNode> item in node.Children)
                    {
                        if(item.Key.NodeType == YamlNodeType.Scalar)
                        {
                            target.Add(item.Key.ToString(), RecursionYml(item.Value));
                        }
                    }
                }

            }
            return target;
        }

        private static object RecursionYml(YamlNode yamlNode)
        {
            if (yamlNode.NodeType == YamlNodeType.Mapping)
            {
                Dictionary<string, object> target = new Dictionary<string, object>();
                YamlMappingNode node = (YamlMappingNode)yamlNode;
                foreach (KeyValuePair<YamlNode, YamlNode> item in node.Children)
                {
                    if (item.Key.NodeType == YamlNodeType.Scalar)
                    {
                        target.Add(item.Key.ToString(), RecursionYml(item.Value));
                    }
                }
                return target;
            }
            else
            {
                return yamlNode;
            }

        }
    }
}
