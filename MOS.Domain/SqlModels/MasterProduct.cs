using System;
using System.Collections.Generic;
using System.Text;

namespace MOS.Domain.SqlModels
{
    public partial class MasterProduct
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }
        public bool Availablity { get; set; }
        public bool Status { get; set; }
        public long EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
