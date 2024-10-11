using KovserHediyyeler.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class InvoiceFile:File
    {
        public string InvoiceTrackingNumber { get; set; }
        
        public DateTime IssueDate { get; set; } //Qebzin verildiyi tarix
        

        //Relationships
        public Guid OrderID { get; set; }
        public Order Order { get; set; }
        //CustomerID = Order.Customer.ID
        //BillingAddress = Order.Webuser.Email
        //shippingAddress = Order.Webuser.Concat(Address)
        //TotalAmount = Order.TotalAmount
        //PaymentStatus = Order.PaymentStatus
    }
}
