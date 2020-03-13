
namespace Payment.Domain.Jwttoken
{
    public class TokenJWT_Configuration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }

    }


    public class Usuario
    { 
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string role { get; set; }
    }
}
