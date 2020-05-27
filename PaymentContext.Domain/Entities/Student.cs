using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, EMail eMail)
        {
            Name = name;
            Document = document;
            EMail = eMail;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, eMail);
        }

        public Name Name { get; set; }
        public Document Document { get; private set; }
        public EMail EMail { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubActive = false;

            foreach (var sub in _subscriptions)
            {
                if (sub.Active)
                {
                    hasSubActive = true;
                }
            }

            AddNotifications(
                new Contract()
                .Requires()
                .IsFalse(hasSubActive, "Student.Subscriptions", "Você já tem uma assinatura ativa.")
                .IsLowerOrEqualsThan(0, subscription.Payments.Count, "Student.Subscriptions.Payments", "Esta assinatura ainda não possui pagamentos.")
            );

            // Alternativa
            //if (hasSubActive)
            //{
            //    AddNotification("Student.Subscriptions", "Você já tem uma assinatura ativa.");
            //}
            
            //// Se já tiver uma ativa, cancela.

            //// Cancela todas as assinaturas, e coloca este como principal.
            //foreach (var sub in Subscriptions)
            //{
            //    sub.Deactivate();
            //}

            _subscriptions.Add(subscription);
        }
    }
}
