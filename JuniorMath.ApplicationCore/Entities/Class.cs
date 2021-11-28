using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Entities
{
    public partial class Class : BaseEntity
    {
        public Class()
        {
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
