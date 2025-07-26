using Business.DTOs.Requests.User;

namespace Business.DTOs.Response.User;

public class GetUserListResponse
{
    public List<GetUserResponse> Items { get; set; }
    public int Count { get; set; }


}
