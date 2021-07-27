using ClosedXML.Excel;
using RentaProject.Domain.Entities;
using RentaProject.Infrastructure.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Infrastructure.Utils.Implementation
{
    public class ExcelManager : IExcelManager
    {
        public void NewExcel(List<ActionEntity> actionList, List<Bitcoin> bitcoinList)
        {
            throw new NotImplementedException();
        }

        public (List<ActionEntity> actionList, List<Bitcoin> bitcoinList) ReadExcel(FileManager fileManager)
        {
            List<ActionEntity> actionList = new List<ActionEntity>();
            List<Bitcoin> bitcoinList = new List<Bitcoin>();

            using (var wBook = new XLWorkbook(fileManager.MyFile))
            {
                var wSheet = wBook.Worksheet(1);
                int row = 2;

                while (wSheet.Cell(row, 2).GetString().Length == 0)
                {
                    string name = wSheet.Cell(row, 2).GetString();

                    switch (name[0])
                    {
                        case 'B':
                            name = name.Remove(0, 4);
                            break;
                        case 'S':
                            name = name.Remove(0, 5);
                            break;
                    }

                    if (HaveBitcoinName(name))
                    {
                        Bitcoin bitcoin = new Bitcoin(name, 
                            decimal.Parse(wSheet.Cell(row, 9).GetString()),
                            decimal.Parse(wSheet.Cell(row, 14).GetString()),
                            decimal.Parse(wSheet.Cell(row, 7).GetString()),
                            decimal.Parse(wSheet.Cell(row, 8).GetString()),
                            DateTime.Parse(wSheet.Cell(row, 10).GetString()),
                            DateTime.Parse(wSheet.Cell(row, 11).GetString())
                            );

                        bitcoinList.Add(bitcoin);
                    }
                    else
                    {
                        ActionEntity actionEntity = new ActionEntity(name, 
                            decimal.Parse(wSheet.Cell(row, 9).GetString()),
                            decimal.Parse(wSheet.Cell(row, 14).GetString()));

                        if (actionList.Count == 0) actionList.Add(actionEntity);
                        else
                        {

                        }
                    }

                    row++;
                }
            }

            return (actionList, bitcoinList);
        }

        private bool HaveBitcoinName(string name)
        {
            bool have = false;
            string[] bitcoinList = { "Bitcoin" };
            int row = 0;

            while (row < bitcoinList.Length && !have)
            {
                if (name.Contains(bitcoinList[0])) have = true;
                else row++;
            }

            return have;
        }
    }
}
