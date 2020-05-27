using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        // Red // Green // Refactor

        [TestMethod]
        public void ShouldReturnErrorDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEMailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Eberton";
            command.LastName = "Sobreira";
            command.Document = "99999";
            command.EMail = "eberton@outlook.com";
            command.Address = "";
            command.BarCode = "12345667788976";
            command.BoletoNumber = "13434234234";
            command.PaymentNumber = "563456345";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddDays(5);
            command.Total = 100;
            command.TotalPaid = 100;
            command.Payer = "";
            command.PayerDocument = "";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "";
            command.Street = "";
            command.Number = "";
            command.Neighborhood = "";
            command.City = "";
            command.State = "";
            command.Country = "";
            command.Zip = "";

            handler.Handle(command);
            Assert.AreEqual(false, command.Valid);
        }
    }
}
