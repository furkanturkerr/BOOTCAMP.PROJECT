namespace Business.DTOs.Response.Blacklist;

public class GetBlacklistResponse
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public string ApplicantName { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedDate { get; set; }
}