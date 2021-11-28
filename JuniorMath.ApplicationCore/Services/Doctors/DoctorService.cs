//using JuniorMath.ApplicationCore.DTOs.Doctors;
//using JuniorMath.ApplicationCore.Entities.DoctorAggregate;
//using JuniorMath.ApplicationCore.Interfaces.Repository;
//using JuniorMath.ApplicationCore.Interfaces.Services.Doctor;
//using JuniorMath.ApplicationCore.Specifications.Doctors;
//using System.Collections.Generic;
//using System.Linq;

//namespace JuniorMath.ApplicationCore.Services.Doctors
//{
//    public class DoctorService : IDoctorService
//    {
//        private readonly IRepository<Doctor> _doctorRepository;

//        public DoctorService(IRepository<Doctor> doctorRepository)
//        {
//            _doctorRepository = doctorRepository;
//        }

//        public List<DoctorModel> SearchDoctorsAsync(int clinicId)
//        {
//            var doctorSpecification = new DoctorSpecification(clinicId);

//            var data = _doctorRepository.List(doctorSpecification);

//            var result = data.Select(p => (DoctorModel)p).ToList();

//            return result;
//        }
//    }
//}
