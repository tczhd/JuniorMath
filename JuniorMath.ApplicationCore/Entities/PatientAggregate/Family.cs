

using System.Collections.Generic;

namespace JuniorMath.ApplicationCore.Entities.PatientAggregate
{
    public partial class Family : BaseEntity
    {
        public Family()
        {
            Patient = new HashSet<Patient>();
        }

        public string Name { get; set; }

        public virtual ICollection<Patient> Patient { get; set; }
    }
}
