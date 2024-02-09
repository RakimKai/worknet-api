using worknet_api.Models;
using worknet_api.Data;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace worknet_api.Helpers.Services
   {
    public class AuthService
    {
        private readonly ApiContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(ApiContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool Logiran()
        {
            return GetInfo().IsLoggedIn;
        }
        public AuthInfo GetInfo()
        {
            string authToken = _httpContextAccessor.HttpContext.Request.Headers["Value"];
            Token? token = _context.Tokens.Include(x => x.Korisnik).SingleOrDefault(x => x.Value == authToken);
            return new AuthInfo(token);
        }

    }
    public class AuthInfo
    {
        [JsonIgnore]
        public Korisnik? KorisnickiNalog => Token?.Korisnik;
        public Token? Token { get; set; }

        public bool IsLoggedIn => KorisnickiNalog != null;
        public AuthInfo(Token? token)
        {
            this.Token = token;
        }

    }
}
