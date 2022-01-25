using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EveSdeReader
{
    public static class Constants
    {
        public static string strExecutePath = Assembly.GetEntryAssembly().Location;
        public static string strBaseFolder = Path.GetDirectoryName(strExecutePath);
    }
}
