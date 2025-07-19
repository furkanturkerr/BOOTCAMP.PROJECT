using AutoMapper;
using Business.DTOs.Requests.Employee;
using Business.DTOs.Response.Employee;
using Entities;

namespace Business.Profiles;

public class EmployeeProfile:Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, GetEmployeeResponse>();
        CreateMap<CreateEmployeeRequest, Employee>();
        CreateMap<UpdateEmployeeRequest, Employee>();
    }
}