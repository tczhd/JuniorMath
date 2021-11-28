using System;
using System.Collections.Generic;
using JuniorMath.ApplicationCore.Entities.InvoiceAggregate;
using JuniorMath.ApplicationCore.Entities.PatientAggregate;
using JuniorMath.ApplicationCore.Entities.UserAggregate;


namespace JuniorMath.ApplicationCore.Entities.DoctorAggregate
{
    public partial class Doctor : BaseEntity
    {
        public Doctor()
        {
            DoctorSpecality = new HashSet<DoctorSpecality>();
            Invoice = new HashSet<Invoice>();
            Patient = new HashSet<Patient>();
            SiteUser = new HashSet<SiteUser>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime? UpdatedDateUtc { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string Note { get; set; }
        public int ClinicId { get; set; }

        public virtual Clinic Clinic { get; set; }
        public virtual SiteUser CreatedByNavigation { get; set; }
        public virtual SiteUser UpdatedByNavigation { get; set; }
        public virtual ICollection<DoctorSpecality> DoctorSpecality { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
        public virtual ICollection<SiteUser> SiteUser { get; set; }
    }
}
