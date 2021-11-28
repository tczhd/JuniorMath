using System;
using System.Collections.Generic;

using JuniorMath.ApplicationCore.Entities.PatientAggregate;
using JuniorMath.ApplicationCore.Entities.SettingsAggregate;
using JuniorMath.ApplicationCore.Entities.UserAggregate;


namespace JuniorMath.ApplicationCore.Entities.CommonAggregate
{
    public partial class Address : BaseEntity
    {
        public Address()
        {
            Patient = new HashSet<Patient>();
            Clinic = new HashSet<Clinic>();
        }

        public int AddressTypeId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int? RegionId { get; set; }
        public string Region { get; set; }
        public int CountryId { get; set; }
        public string AttentionTo { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime? UpdatedDateUtc { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual AddressType AddressType { get; set; }
        public virtual Country Country { get; set; }
        public virtual SiteUser CreatedByNavigation { get; set; }
        public virtual Region RegionNavigation { get; set; }
        public virtual SiteUser UpdatedByNavigation { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
        public virtual ICollection<Clinic> Clinic { get; set; }
    }
}
