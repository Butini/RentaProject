using RentaProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Infrastructure.Utils.Contracts
{
    public interface IExcelManager
    {
        public (List<ActionEntity> actionList, List<Bitcoin> bitcoinList) ReadExcel(FileManager fileManager);
        public void NewExcel(List<ActionEntity> actionList, List<Bitcoin> bitcoinList);
    }
}
