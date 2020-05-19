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

        private static void ReadT1Item(Excel.IXLWorksheet shSheet)
        {
            int nRow = 1;
            lstT1Item.Clear();
            //第一行是表头，行号从1开始
            for (nRow = 2; shSheet.Cell(nRow, 1).GetString() != String.Empty; nRow++)
            {
                Objects.T1Product item = new Objects.T1Product();
                item.Name =shSheet.Cell(nRow, 1).GetString();
                item.Tri = ReadNumber(shSheet.Cell(nRow, 2).GetString());
                item.Pye = ReadNumber(shSheet.Cell(nRow, 3).GetString());
                item.Mex = ReadNumber(shSheet.Cell(nRow, 4).GetString());
                item.Iso = ReadNumber(shSheet.Cell(nRow, 5).GetString());
                item.Noc = ReadNumber(shSheet.Cell(nRow, 6).GetString());
                item.Zyd = ReadNumber(shSheet.Cell(nRow, 7).GetString());
                item.Meg = ReadNumber(shSheet.Cell(nRow, 8).GetString());
                item.Volume = int.Parse(shSheet.Cell(nRow, 9).GetString());
                lstT1Item.Add(item);
            }
        }

        private static double ReadNumber(string strCell)
        {
            double dRnt = 0;
            double.TryParse(strCell, out dRnt);
            return dRnt;
        }


    }
}
