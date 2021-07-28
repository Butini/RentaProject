using ClosedXML.Excel;
using RentaProject.Domain.Entities;
using RentaProject.Infrastructure.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Infrastructure.Utils.Implementation
{
    public class ExcelManager : IExcelManager
    {
        public string NewExcel(List<ActionEntity> actionList, List<BitcoinEntity> bitcoinList, string name)
        {
            var pathBuild = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\file");

            if (!Directory.Exists(pathBuild))
            {
                Directory.CreateDirectory(pathBuild);
            }

            var path = Path.Combine(pathBuild, "Renta_" + name);

            using (var wBook = new XLWorkbook())
            {
                var worksheetAction = wBook.Worksheets.Add("Renta");
                var worksheetBitcoin = wBook.Worksheets.Add("CriptoMonedas");

                int row = 1;

                worksheetAction.Cell(row, 1).Value = "Nombre";
                worksheetAction.Cell(row, 2).Value = "Profit";
                worksheetAction.Cell(row, 3).Value = "Fees";

                worksheetBitcoin.Cell(row, 1).Value = "Nombre";
                worksheetBitcoin.Cell(row, 2).Value = "Profit";
                worksheetBitcoin.Cell(row, 3).Value = "Fees";
                worksheetBitcoin.Cell(row, 4).Value = "Data compra";
                worksheetBitcoin.Cell(row, 5).Value = "Data venta";
                worksheetBitcoin.Cell(row, 6).Value = "Import Compra";
                worksheetBitcoin.Cell(row, 7).Value = "Import Venta";

                row = 2;

                foreach (var actionValue in actionList)
                {
                    worksheetAction.Cell(row, 1).Value = actionValue.Name;
                    worksheetAction.Cell(row, 2).Value = actionValue.Profit;
                    worksheetAction.Cell(row, 3).Value = actionValue.Fees;

                    row++;
                }

                row = 2;

                foreach (var bitcoinValue in bitcoinList)
                {
                    worksheetBitcoin.Cell(row, 1).Value = bitcoinValue.Name;
                    worksheetBitcoin.Cell(row, 2).Value = bitcoinValue.Profit;
                    worksheetBitcoin.Cell(row, 3).Value = bitcoinValue.Fees;
                    worksheetBitcoin.Cell(row, 4).Value = bitcoinValue.OpenDate;
                    worksheetBitcoin.Cell(row, 5).Value = bitcoinValue.CloseDate;
                    worksheetBitcoin.Cell(row, 6).Value = bitcoinValue.OpenRate;
                    worksheetBitcoin.Cell(row, 7).Value = bitcoinValue.CloseRate;

                    row++;
                }

                wBook.SaveAs(path);

            }

            return path;
        }

        public (List<ActionEntity> actionList, List<BitcoinEntity> bitcoinList) ReadExcel(FilePathEntity fileManager)
        {
            List<ActionEntity> actionList = new List<ActionEntity>();
            List<BitcoinEntity> bitcoinList = new List<BitcoinEntity>();

            using (var wBook = new XLWorkbook(fileManager.Path))
            {
                var wSheet = wBook.Worksheet(1);
                int row = 2;
                string nameTEST = wSheet.Cell(row, 2).GetString();

                while (wSheet.Cell(row, 2).GetString().Length != 0)
                {
                    string name = wSheet.Cell(row, 2).GetString();
                    name = ReplaceBuySell(name);

                    if (HaveBitcoinName(name))
                    {
                        BitcoinEntity bitcoin = new BitcoinEntity(name, 
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

                        actionList.Add(actionEntity);
                    }

                    row++;
                }
            }

            return (actionList, bitcoinList);
        }

        private string ReplaceBuySell(string name)
        {
            return name.Replace("Buy ", "").Replace("Sell ", "");
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
