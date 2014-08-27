using HKEx.Clear.CDWGUI.Param.CollateralHaircutsTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWDTest
{
    class DisplayBondHaircutsTable
    {


     
        public  string ViewBondsTable()
        {

            BondHaircutsTableAdapter bondsHairCut = new BondHaircutsTableAdapter();

            var allData = bondsHairCut.GetData();

            foreach (DataColumn cols in allData.Columns)
            {
                Console.Write(cols.ColumnName + "\t");
            }


            foreach (var cols in allData)
            {

                Console.WriteLine("\n{0}\t{1}\t{2}\t{3}\t{4}\t{5}", cols.BondID, cols.ISIN, cols.ShortName, cols.CollateralID, cols.HaircutPercent, cols.IsPending);

                return string.Format("\n{0}\t{1}\t{2}\t{3}\t{4}\t{5}", cols.BondID, cols.ISIN, cols.ShortName, cols.CollateralID, cols.HaircutPercent, cols.IsPending);
            }
            return null;
        }
    }
}
