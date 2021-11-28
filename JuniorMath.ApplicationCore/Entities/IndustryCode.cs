using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Entities
{
    public class IndustryCode : BaseEntity
    {
        public IndustryCode()
        {
            Items = new HashSet<Item>();
        }

        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
