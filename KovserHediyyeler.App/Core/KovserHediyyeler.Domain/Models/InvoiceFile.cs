namespace KovserHediyyeler.Domain.Models
{
    public class InvoiceFile:File
    {
        public string InvoiceTrackingNumber { get; set; }
        
        public DateTime IssueDate { get; set; } //Qebzin verildiyi tarix
        

        //Relationships
        public Order Order { get; set; }
        public string CustomerID
        {
            get
            {
                return Order.CustomerID;
            }
        }

        public string CustomerName
        {
            get
            {
                return Order.Customer.MiddleName == null ? $"{Order.Customer.FirstName} {Order.Customer.LastName}" : $"{Order.Customer.FirstName} {Order.Customer.MiddleName} {Order.Customer.LastName}";
            }
        }

        public string BillingAddress
        {
            get
            {
                return Order.Customer.Email;
            }
        }

        public string ShippingAddress
        {
            get
            {
                return Order.Customer.AddressWebUsers.FirstOrDefault(x => x.WebUser.Id == Order.Customer.Id).Address.FullAddress;
            }
        }

        public double TotalAmount
        {
            get
            {
                return Order.TotalPrice;
            }
        }

        public string PaymentStatus
        {
            get
            {
                return Order.OrderPayment.PaymentStatus.ToString();
            }
        }
    }
}
