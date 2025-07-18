namespace Business.DTOs.Response.Employee;

public class GetEmployeeResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Position { get; set; }
    public DateTime CreatedDate { get; set; }
}