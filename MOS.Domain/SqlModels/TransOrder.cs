using System;
using System.Collections.Generic;
using System.Text;

namespace MOS.Domain.SqlModels
{
    public partial class TransOrder
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public long OrderedQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMode { get; set; }
        public string DeliveryAddress { get; set; }
        public bool? IsCancelled { get; set; }
        public DateTime? CancelledDate { get; set; }
        public bool? IsShipped { get; set; }
        public DateTime? ShippedDate { get; set; }
        public bool? IsDelivered { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public bool? IsReturned { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public long OrderedBy { get; set; }
        public DateTime OrderedDate { get; set; }
    }
}
