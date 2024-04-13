namespace Unicam.Paradigmi.Progetto.Application.Models.Responses
{
    public class CreateTokenResponse
    {
        public string Token { get; set; } = string.Empty;

        public CreateTokenResponse(string token)
        {
            this.Token = token;
        }
    }
}
