using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Domain.Entities
{
    public class ActionEntity
    {
        public string Name { get; set; }
        public decimal Profit { get; set; }
        public decimal Fees { get; set; }

        public ActionEntity(string name, decimal profit, decimal fees)
        {
            Name = name;
            Profit = Rounding(profit);
            Fees = Rounding(fees);
        }

        public void AddActionProfitFees(ActionEntity action)
        {
            Profit = Rounding(Profit + Rounding(action.Profit));
            Fees = Rounding(Fees + Rounding(action.Fees));
        }

        protected decimal Rounding(decimal number)
        {
            return decimal.Round(number, 2, MidpointRounding.ToEven);
        }

        public override bool Equals(object obj)
        {
            return obj is ActionEntity action &&
                   Name == action.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Profit, Fees);
        }
    }
}
