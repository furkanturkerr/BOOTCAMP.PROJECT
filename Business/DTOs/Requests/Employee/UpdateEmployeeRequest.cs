namespace Business.DTOs.Requests.Employee;

public class UpdateEmployeeRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Position { get; set; }

}