namespace Unicam.Paradigmi.Progetto.Application.Models.Request
{
    public class CreateTokenRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
