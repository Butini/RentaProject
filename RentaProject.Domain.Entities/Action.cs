using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Domain.Entities
{
    public abstract class Action
    {
        public string Name { get; set; }
        public decimal Profit { get; set; }
        public decimal Fees { get; set; }

        protected Action(string name, decimal profit, decimal fees)
        {
            Name = name;
            Profit = Rounding(profit);
            Fees = Rounding(fees);
        }

        protected void AddActionProfitFees(Action action)
        {
            Profit = Rounding(Profit + action.Profit);
            Fees = Rounding(Fees + action.Fees);
        }

        protected decimal Rounding(decimal number)
        {
            return decimal.Round(number, 2, MidpointRounding.ToEven);
        }

        public override bool Equals(object obj)
        {
            return obj is Action action &&
                   Name == action.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Profit, Fees);
        }
    }
}
