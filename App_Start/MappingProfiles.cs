using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ProlinkApplications.Models.ActionModels;
using ProlinkApplications.Models.DTO; 

namespace ProlinkApplications.App_Start
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            Mapper.CreateMap<Student, StudentDTO>();
            Mapper.CreateMap<StudentDTO, Student>();

            Mapper.CreateMap<School, SchoolDTO>();
            Mapper.CreateMap<SchoolDTO, School>();

            Mapper.CreateMap<SchoolAdmin, SchoolAdminDTO>();
            Mapper.CreateMap<SchoolAdminDTO, SchoolAdmin>();

            Mapper.CreateMap<ProlinkAdmin, ProlinkAdminDTO>();
            Mapper.CreateMap<ProlinkAdminDTO, ProlinkAdmin>();

            Mapper.CreateMap<Gardian, GardianDTO>();
            Mapper.CreateMap<GardianDTO, Gardian>();

            Mapper.CreateMap<DeclinedApplications, DeclinedApplicationsDTO>();
            Mapper.CreateMap<DeclinedApplicationsDTO, DeclinedApplications>();

            Mapper.CreateMap<AwaitingApplications, AwaitingApplicationsDTO>();
            Mapper.CreateMap<AwaitingApplicationsDTO, AwaitingApplications>();

            Mapper.CreateMap<ApprovedApplications, ApprovedApplicationsDTO>();
            Mapper.CreateMap<ApprovedApplicationsDTO, ApprovedApplications>();

            Mapper.CreateMap<Applicant, ApplicantDTO>();
            Mapper.CreateMap<ApplicantDTO, Applicant>();

            Mapper.CreateMap<BannedApplications, BannedApplicationsDTO>();
            Mapper.CreateMap<BannedApplicationsDTO, BannedApplications>();
        }
    }
}