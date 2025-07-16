using Entities;

namespace Business.DTOs.Requests.Application;

public class UpdateApplicationRequest
{
    public int Id { get; set; }
    public ApplicationState State { get; set; }

}