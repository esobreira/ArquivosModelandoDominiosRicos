using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string transactionCode,
            DateTime paidDate, 
            DateTime expireDate, 
            decimal total, 
            decimal totalPaid,
            Address address, 
            string payer, 
            Document document,
            EMail email) : base(paidDate, 
                expireDate, 
                total, 
                totalPaid, 
                address, 
                payer, 
                document, 
                email)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; set; }
    }
}
