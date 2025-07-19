using AutoMapper;
using Business.Concretes;
using Business.DTOs.Requests.Applicant;
using Entities;

namespace Business.Profiles;

public class ApplicantProfile : Profile
{
    public ApplicantProfile()
    {
        CreateMap<Applicant, ApplicantManager.GetApplicantResponse>();
        CreateMap<CreateApplicantRequests, Applicant>();
        CreateMap<UpdateApplicantRequests, Applicant>();
    }
}