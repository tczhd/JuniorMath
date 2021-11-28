using JuniorMath.ApplicationCore.DTOs.Doctors;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Interfaces.Services.Doctor
{
    public interface IDoctorService
    {
        List<DoctorModel> SearchDoctorsAsync(int clinicId);
    }
}
