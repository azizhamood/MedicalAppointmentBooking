

using Share.Model;
using Application.DTO;
using Core.Model;
using Share.DTO;

namespace Api.Services
{
    public interface IIdentityService
    {
        public bool IsAuthenticated(string token);
        public Task<JwtTokenModel> Login(UserLoginDto user);
        public Task<JwtTokenModel> RegisterAsync(UserRegisterDto registerModelDto, string Role);
        public JwtTokenModel GenerateToken(UserModel user);
        public Task<string> GetSalt(int UserId);
        public Task<string> GetHash(int UserId);
      

    }
}
