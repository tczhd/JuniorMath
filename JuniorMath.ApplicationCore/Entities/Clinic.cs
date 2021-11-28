using System;
using System.Collections.Generic;
using JuniorMath.ApplicationCore.Entities.CommonAggregate;
using JuniorMath.ApplicationCore.Entities.DoctorAggregate;
using JuniorMath.ApplicationCore.Entities.InvoiceAggregate;
using JuniorMath.ApplicationCore.Entities.PatientAggregate;
using JuniorMath.ApplicationCore.Entities.UserAggregate;


namespace JuniorMath.ApplicationCore.Entities
{
    public partial class Clinic : BaseEntity
    {
        public Clinic()
        {
            Doctor = new HashSet<Doctor>();
            Invoice = new HashSet<Invoice>();
            Item = new HashSet<Item>();
            Patient = new HashSet<Patient>();
            SiteUser = new HashSet<SiteUser>();
            Payment = new HashSet<Payment>();
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime? UpdatedDateUtc { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string Note { get; set; }
        
        public int AddressId { get; set; }

        public virtual SiteUser CreatedByNavigation { get; set; }
        public virtual SiteUser UpdatedByNavigation { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
        public virtual ICollection<SiteUser> SiteUser { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual Address Address { get; set; }
    }
}
