namespace Business.DTOs.Requests.Blacklist;

public class CreateBlacklistRequest
{
    public int ApplicantId { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
}