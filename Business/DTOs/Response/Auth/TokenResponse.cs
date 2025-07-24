namespace Business.DTOs.Response.Auth;

public class TokenResponse
{
    public string AccessToken { get; set; }
    public DateTime ExpirationTime { get; set; }
}