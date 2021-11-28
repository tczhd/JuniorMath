using JuniorMath.Web.Models;
using JuniorMath.Web.Models.Patients;
using JuniorMath.Web.ViewModels.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorMath.Web.Interfaces.Api
{
    public interface IPatientApiService
    {
        PatientResultViewModel CreateNewPatient(List<PatientRequestModel> Patients);
        SearchPatientResultViewModel SearchPatients(WebSearchRequestModel searchequestModel);
        PatientViewModel SearchPatient(int id);
    }
}
