namespace Business.DTOs.Requests.Blacklist;

public class UpdateBlacklistRequest
{
    public int Id { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
}