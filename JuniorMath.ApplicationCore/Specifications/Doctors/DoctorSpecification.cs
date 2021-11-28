using JuniorMath.ApplicationCore.Entities.DoctorAggregate;
using JuniorMath.ApplicationCore.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Specifications.Doctors
{
    public class DoctorSpecification : BaseSpecification<Doctor>
    {
        public DoctorSpecification(int clinicId) : base()
        {
            AddCriteria(q => q.ClinicId == clinicId);
        }

    }
}
