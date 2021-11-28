using JuniorMath.ApplicationCore.Entities;
using JuniorMath.ApplicationCore.Entities.CommonAggregate;
using JuniorMath.ApplicationCore.Entities.InvoiceAggregate;
using JuniorMath.ApplicationCore.Entities.PatientAggregate;
using JuniorMath.ApplicationCore.Specifications.Base;
using System;

namespace JuniorMath.ApplicationCore.Specifications.Invoices
{
    public class InvoiceSpecification : BaseSpecification<Invoice>
    {
        public InvoiceSpecification(int clinicId) : base()
        {
            AddCriteria(q => q.ClinicId == clinicId);
            AddInclude(b => b.Doctor);
            AddInclude(b => b.Clinic);
            AddInclude($"{nameof(Invoice.Clinic)}.{nameof(Clinic.Address)}");
            AddInclude(b => b.Patient);
            AddInclude($"{nameof(Invoice.Patient)}.{nameof(Patient.Address)}");
            AddInclude($"{nameof(Invoice.Patient)}.{nameof(Patient.PatientCardOnFile)}");
            AddInclude($"{nameof(Invoice.Patient)}.{nameof(Patient.Address)}.{nameof(Address.Country)}");
           // AddInclude($"{nameof(Invoice.Patient)}.{nameof(Patient.Address)}.{nameof(Address.Region)}");
            AddInclude(b => b.InvoiceItem);
            AddInclude($"{nameof(Invoice.InvoiceItem)}.{nameof(InvoiceItem.Item)}");
            AddInclude(b => b.InvoicePayment);
            AddInclude($"{nameof(Invoice.InvoicePayment)}.{nameof(InvoicePayment.Payment)}");
        }

        public void AddDisplayId(int displayId)
        {
            AddCriteria(q => q.DisplayId == displayId);
        }
        public void AddInvoiceId(int invoiceId)
        {
            AddCriteria(q => q.Id == invoiceId);
        }

        public void AddPatientId(int patientId)
        {
            AddCriteria(q => q.Id == patientId);
        }

        public void AddFirstName(string firstName)
        {
            AddCriteria(q => q.Patient.FirstName.Contains( firstName));
        }

        public void AddLastName(string lastName)
        {
            AddCriteria(q => q.Patient.LastName.Contains(lastName));
        }
        public void AddFromDate(DateTime fromDate)
        {
            AddCriteria(q => q.InvoiceDate >= fromDate);
        }

        public void AddToDate(DateTime toDate)
        {
            AddCriteria(q => q.InvoiceDate < toDate.Date.AddDays(1));
        }
    }
}
