using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Domain.Entities
{
    public class Bitcoin : ActionEntity
    {
        public decimal OpenRate { get; set; }
        public decimal CloseRate { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }

        public Bitcoin(string name, decimal profit, decimal fees, 
            decimal openRate, decimal closeRate, DateTime openDate, DateTime closeDate) : base(name, profit, fees)
        {
            OpenRate = openRate;
            CloseRate = closeRate;
            OpenDate = openDate;
            CloseDate = closeDate;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Name, Profit, Fees, OpenRate, CloseRate, OpenDate, CloseDate);
        }
    }
}
