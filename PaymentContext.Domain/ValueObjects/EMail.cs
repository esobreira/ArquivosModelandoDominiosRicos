using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.ValueObjects
{
    public class EMail : ValueObject
    {
        public EMail(string address)
        {
            Address = address;

            AddNotifications(
                new Contract()
                .Requires()
                .IsEmail(Address, "EMail.Address", "E-mail inválido.")
            );
        }

        public string Address { get; private set; }
    }
}
