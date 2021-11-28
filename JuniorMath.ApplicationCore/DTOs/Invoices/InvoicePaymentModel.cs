using JuniorMath.ApplicationCore.Entities.InvoiceAggregate;
using JuniorMath.ApplicationCore.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.Invoices
{
    public class InvoicePaymentModel : IResultable<InvoicePayment, InvoicePaymentModel>
    {
        public int InvoicePaymentId { get; set; }
        public int InvoiceId { get; set; }
        public int PaymentId { get; set; }
        public decimal AmountPaid { get; set; }
        public string AuthorizationCode { get; set; }
        public string TransactionId { get; set; }
        public string CardL4 { get; set; }
        public string Note { get; set; }
        public Expression<Func<InvoicePayment, InvoicePaymentModel>> CreateResult()
        {
            return m => new InvoicePaymentModel
            {
                InvoicePaymentId = m.Id,
                AmountPaid = m.AmountPaid,
                InvoiceId = m.InvoiceId,
                PaymentId = m.PaymentId,

                Note = m.Note
            };
        }

        public static implicit operator InvoicePaymentModel(InvoicePayment source)
        {
            return new InvoicePaymentModel
            {
                InvoicePaymentId = source.Id,
                AmountPaid = source.AmountPaid,
                InvoiceId = source.InvoiceId,
                PaymentId = source.PaymentId,
                TransactionId = source.Payment.TransactionId,
                AuthorizationCode = source.Payment.AuthorizationCode,
                CardL4 = source.Payment.CardF4L4 != null && source.Payment.CardF4L4.Length > 4 ? source.Payment.CardF4L4.Substring(source.Payment.CardF4L4.Length - 4, 4) : source.Payment.CardF4L4,
                Note = source.Note
            };
        }

        public static implicit operator InvoicePayment(InvoicePaymentModel source)
        {
            return new InvoicePayment
            {
                Id = source.InvoicePaymentId,
                AmountPaid = source.AmountPaid,
                InvoiceId = source.InvoiceId,
                PaymentId = source.PaymentId,
                Note = source.Note
            };
        }

    }
}
