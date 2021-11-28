using JuniorMath.ApplicationCore.Entities.CommonAggregate;

using System.Collections.Generic;

namespace JuniorMath.ApplicationCore.Entities.SettingsAggregate
{
    public partial class Region : BaseEntity
    {
        public Region()
        {
            Address = new HashSet<Address>();
        }

        public string Name { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}
