using JitaBuyPrice.ObjectsJson;
using JitaBuyPrice.ObjectsYaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.RepresentationModel;

namespace JitaBuyPrice.Helper
{
    public static class FilesHelper
    {
        public static void OutputJsonFile(string strFileName, string strContent)
        {
            string strBasePath = Application.StartupPath + @"\Json\" + strFileName + ".json";
            if (!Directory.Exists(Path.GetDirectoryName(strBasePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(strBasePath));
            }
            using (var sw = new StreamWriter(strBasePath, false, Encoding.Unicode))
            {
                sw.Write(strContent);
            }
            //Environment.

        }
        public static string ReadJsonFile(string strFileName)
        {
            string strContents;
            string strBasePath = Application.StartupPath;
            using (var sr = new StreamReader(strBasePath + @"\Json\" + strFileName + ".json", Encoding.Unicode))
            {
                strContents = sr.ReadToEnd();
            }
            //Environment.
            return strContents;
        }

        public static List<Materials> ReadMaterialsFile()
        {
            string strBasePath = Application.StartupPath;

            var deserializer = new YamlDotNet.Serialization.Deserializer();

            List<Materials> lstMaterials = new List<Materials>();

            
            using (var sr = new StreamReader(strBasePath + @"\SDE\FSD\typeMaterials.yaml", Encoding.UTF8))
            {

                //YamlStream ys = new YamlStream();
                //ys.Load(sr);

                Dictionary<string, Materials> target = deserializer.Deserialize<Dictionary<string, Materials>>(sr);
                foreach(string item in target.Keys)
                {
                    Materials matItem = target[item];
                    matItem.TypeID = item;
                    lstMaterials.Add(matItem);
                }
                //foreach(object item in target)
                //strContents = sr.ReadToEnd();
            }
            //Environment.
            return lstMaterials;
        }

        public static List<BluePrintJson> ReadBluePrintFile()
        {
            string strBasePath = Application.StartupPath;

            var deserializer = new YamlDotNet.Serialization.Deserializer();

            List<BluePrintJson> lstBluePrint = new List<BluePrintJson>();


            using (var sr = new StreamReader(strBasePath + @"\SDE\FSD\blueprints.yaml", Encoding.UTF8))
            {

                //YamlStream ys = new YamlStream();
                //ys.Load(sr);

                var target = deserializer.Deserialize<Dictionary<string, BluePrintYaml>>(sr);
                foreach (string item in target.Keys)
                {
                    BluePrintJson bpItem = new BluePrintJson();

                    if (int.Parse(item) != target[item].TypeID)
                    {
                        MessageBox.Show("Warning");
                    }
                    bpItem.TypeID = item;

                    //bpItem.Materials = target[item].Activities["manufacturing"].Manufacturing["materials"];

                    //bpItem.Materials = target[item];
                    lstBluePrint.Add(bpItem);
                }
                //foreach(object item in target)
                //strContents = sr.ReadToEnd();
            }
            //Environment.
            return lstBluePrint;
        }

    }
}
