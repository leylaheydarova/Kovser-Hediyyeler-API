//using Microsoft.AspNetCore.Http;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace KovserHediyyeler.Domain.Models
//{
//    public class InvoiceFile : File
//    {
//        public required string InvoiceTrackingNumber { get; set; }

//        public DateTime IssueDate { get; set; } //Qebzin verildiyi tarix


//        //Relationships
//        [ForeignKey(nameof(Order))]
//        public required Guid OrderID { get; set; }
//        public Order Order { get; set; }
//        [NotMapped]
//        public IFormFile file { get; set; }
//        public string CustomerID
//        {
//            get
//            {
//                return Order.CustomerID;
//            }
//        }

//        public string CustomerName
//        {
//            get
//            {
//                return Order.Customer.MiddleName == null ? $"{Order.Customer.FirstName} {Order.Customer.LastName}" : $"{Order.Customer.FirstName} {Order.Customer.MiddleName} {Order.Customer.LastName}";
//            }
//        }

//        public string BillingAddress
//        {
//            get
//            {
//                return Order.Customer.Email;
//            }
//        }

//        public string ShippingAddress
//        {
//            get
//            {
//                var shippingAddress = Order.Customer.Addresses
//            .FirstOrDefault(ad => ad.WebUsers.Any(w => w.Id == Order.Customer.Id));
//                return shippingAddress.FullAddress is null ? "Ünvan qeyd edilməmişdir" : shippingAddress.FullAddress;
//            }
//        }

//        public double TotalAmount
//        {
//            get
//            {
//                return Order.TotalPrice;
//            }
//        }

//        public string PaymentStatus
//        {
//            get
//            {
//                return Order.OrderPayment.PaymentStatus.ToString();
//            }
//        }
//    }
//}
