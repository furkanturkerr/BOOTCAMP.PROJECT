using AutoMapper;
using Business.DTOs.Requests.Instructor;
using Business.DTOs.Response.Instructor;
using Entities;

namespace Business.Profiles;

public class InstructorProfile:Profile
{
    public InstructorProfile()
    {
        CreateMap<Instructor, GetInstructorResponse>();
        CreateMap<CreateInstructorRequest, Instructor>();
        CreateMap<UpdateInstructorRequest, Instructor>();
    }
}