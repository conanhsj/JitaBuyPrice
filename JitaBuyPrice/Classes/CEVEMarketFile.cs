using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = ClosedXML.Excel;

namespace JitaBuyPrice.Classes
{
    public static class CEVEMarketFile
    {
        public static List<Objects.Item> lstItem = new List<Objects.Item>();
        //public static List<Objects.Item> lstSegmentums = new List<Objects.Item>();
        //public static List<Objects.Item> lstConstellation = new List<Objects.Item>();
        //public static List<Objects.Item> lstGalaxy = new List<Objects.Item>();
        //public static List<Objects.Item> lstStation = new List<Objects.Item>();

        public static List<Objects.T1Product> lstT1Item = new List<Objects.T1Product>();
        public static List<Objects.Ore> lstOre = new List<Objects.Ore>();
        public static List<Objects.T2Base> lstT2High = new List<Objects.T2Base>();

        public static List<Objects.T2Product> lstT2Product = new List<Objects.T2Product>();
        public static void ExcelReader(string strPath)
        {
            Excel.XLWorkbook xFile = new Excel.XLWorkbook(strPath);

            foreach (Excel.IXLWorksheet Isheet in xFile.Worksheets)
            {
                if (Isheet.Name == "物品列表")
                {
                    ReadItem(Isheet);
                }
            }
        }
        private static void ReadItem(Excel.IXLWorksheet shSheet)
        {
            int nRow = 1;
            lstItem.Clear();
            //第一行是表头，行号从1开始
            for (nRow = 2; shSheet.Cell(nRow, 1).GetString() != String.Empty; nRow++)
            {
                Objects.Item item = new Objects.Item();
                item.TypeID = shSheet.Cell(nRow, 1).GetString();
                item.Name = shSheet.Cell(nRow, 2).GetString();
                item.Descript = shSheet.Cell(nRow, 3).GetString();
                item.Category1 = shSheet.Cell(nRow, 4).GetString();
                item.Category2 = shSheet.Cell(nRow, 5).GetString();
                item.Category3 = shSheet.Cell(nRow, 6).GetString();
                item.Category4 = shSheet.Cell(nRow, 7).GetString();
                item.Category5 = shSheet.Cell(nRow, 8).GetString();
                item.Category6 = shSheet.Cell(nRow, 9).GetString();
                lstItem.Add(item);
            }
        }


        public static void ExcelWorkingReader(string strPath)
        {
            Excel.XLWorkbook xFile = new Excel.XLWorkbook(strPath);

            foreach (Excel.IXLWorksheet Isheet in xFile.Worksheets)
            {
                if (Isheet.Name == "T1科技")
                {
                    ReadT1Item(Isheet);
                }
            }
        }
        private static void ReadT1Item(Excel.IXLWorksheet shSheet)
        {
            int nRow = 1;
            lstT1Item.Clear();
            //第一行是表头，行号从1开始
            for (nRow = 2; shSheet.Cell(nRow, 1).GetString() != String.Empty; nRow++)
            {
                Objects.T1Product item = new Objects.T1Product();
                item.Name = shSheet.Cell(nRow, 1).GetString();
                item.Tri = ReadDouble(shSheet.Cell(nRow, 2).GetString());
                item.Pye = ReadDouble(shSheet.Cell(nRow, 3).GetString());
                item.Mex = ReadDouble(shSheet.Cell(nRow, 4).GetString());
                item.Iso = ReadDouble(shSheet.Cell(nRow, 5).GetString());
                item.Noc = ReadDouble(shSheet.Cell(nRow, 6).GetString());
                item.Zyd = ReadDouble(shSheet.Cell(nRow, 7).GetString());
                item.Meg = ReadDouble(shSheet.Cell(nRow, 8).GetString());
                item.Volume = int.Parse(shSheet.Cell(nRow, 9).GetString());
                lstT1Item.Add(item);
            }
        }

        public static void ExcelOreRecycle(string strPath)
        {
            Excel.XLWorkbook xFile = new Excel.XLWorkbook(strPath);

            foreach (Excel.IXLWorksheet Isheet in xFile.Worksheets)
            {
                if (Isheet.Name == "基础矿石")
                {
                    ReadOreRecycle(Isheet);
                }
            }
        }
        private static void ReadOreRecycle(Excel.IXLWorksheet shSheet)
        {
            int nRow = 1;
            lstOre.Clear();
            //第一行是表头，行号从1开始
            for (nRow = 2; shSheet.Cell(nRow, 1).GetString() != String.Empty; nRow++)
            {
                Objects.Ore item = new Objects.Ore();
                item.Name = shSheet.Cell(nRow, 1).GetString();
                item.Volume = int.Parse(shSheet.Cell(nRow, 2).GetString());
                item.Tri = ReadDouble(shSheet.Cell(nRow, 3).GetString());
                item.Pye = ReadDouble(shSheet.Cell(nRow, 4).GetString());
                item.Mex = ReadDouble(shSheet.Cell(nRow, 5).GetString());
                item.Iso = ReadDouble(shSheet.Cell(nRow, 6).GetString());
                item.Noc = ReadDouble(shSheet.Cell(nRow, 7).GetString());
                item.Zyd = ReadDouble(shSheet.Cell(nRow, 8).GetString());
                item.Meg = ReadDouble(shSheet.Cell(nRow, 9).GetString());
                lstOre.Add(item);
            }
        }

        public static void ExcelT2High(string strPath)
        {
            Excel.XLWorkbook xFile = new Excel.XLWorkbook(strPath);

            foreach (Excel.IXLWorksheet Isheet in xFile.Worksheets)
            {
                if (Isheet.Name == "T2高级反应")
                {
                    ReadT2High(Isheet);
                }
            }
        }
        private static void ReadT2High(Excel.IXLWorksheet shSheet)
        {
            int nRow = 1;
            lstT2High.Clear();
            //第一行是表头，行号从1开始
            for (nRow = 2; shSheet.Cell(nRow, 1).GetString() != String.Empty; nRow++)
            {
                Objects.T2Base item = new Objects.T2Base();
                item.Name = shSheet.Cell(nRow, 1).GetString();
                item.Volume = int.Parse(shSheet.Cell(nRow, 2).GetString());
                if (!string.IsNullOrEmpty(shSheet.Cell(nRow, 3).GetString()))
                {
                    item.Items.Add(shSheet.Cell(nRow, 3).GetString(), int.Parse(shSheet.Cell(nRow, 4).GetString()));
                }
                if (!string.IsNullOrEmpty(shSheet.Cell(nRow, 5).GetString()))
                {
                    item.Items.Add(shSheet.Cell(nRow, 5).GetString(), int.Parse(shSheet.Cell(nRow, 6).GetString()));
                }
                if (!string.IsNullOrEmpty(shSheet.Cell(nRow, 7).GetString()))
                {
                    item.Items.Add(shSheet.Cell(nRow, 7).GetString(), int.Parse(shSheet.Cell(nRow, 8).GetString()));
                }
                if (!string.IsNullOrEmpty(shSheet.Cell(nRow, 9).GetString()))
                {
                    item.Items.Add(shSheet.Cell(nRow, 9).GetString(), int.Parse(shSheet.Cell(nRow, 10).GetString()));
                }
                if (!string.IsNullOrEmpty(shSheet.Cell(nRow, 11).GetString()))
                {
                    item.Items.Add(shSheet.Cell(nRow, 11).GetString(), int.Parse(shSheet.Cell(nRow, 12).GetString()));
                }
                lstT2High.Add(item);
            }
        }

        public static void ExcelT2Work(string strPath)
        {
            Excel.XLWorkbook xFile = new Excel.XLWorkbook(strPath);

            foreach (Excel.IXLWorksheet Isheet in xFile.Worksheets)
            {
                if (Isheet.Name == "T2制造")
                {
                    ReadT2Work(Isheet);
                }
            }
        }
        private static void ReadT2Work(Excel.IXLWorksheet shSheet)
        {
            int nRow = 1;
            int nCol = 1;
            lstT2Product.Clear();
            //第一行是产物，行号从1开始
            for (nCol = 1; shSheet.Cell(1, nCol).GetString() != String.Empty; nCol++)
            {
                nRow = 1;
                Objects.T2Product item = new Objects.T2Product();
                string[] strValue = shSheet.Cell(nRow, nCol).GetString().Split(new string[] { " x " }, StringSplitOptions.RemoveEmptyEntries);
                item.Name = strValue[1];
                item.Volume = int.Parse(strValue[0]);
                nRow++;
                //材料需求
                while (!string.IsNullOrEmpty(shSheet.Cell(nRow, nCol).GetString()))
                {
                    strValue = shSheet.Cell(nRow, nCol).GetString().Split(new string[] { " x " }, StringSplitOptions.RemoveEmptyEntries);
                    item.Items.Add(strValue[1], ReadInt(strValue[0]));
                    nRow++;
                }
                lstT2Product.Add(item);
            }
        }

        private static double ReadDouble(string strCell)
        {
            double dRnt = 0;
            double.TryParse(strCell, out dRnt);
            return dRnt;
        }
        private static int ReadInt(string strCell)
        {
            int dRnt = 0;
            string strInt = strCell.Replace(',', '\0');
            int.TryParse(strInt, out dRnt);
            return dRnt;
        }

    }
}
