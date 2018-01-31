using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class PurchaseEntity
    {

        public int PurchaseId { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; } 
    }
}
