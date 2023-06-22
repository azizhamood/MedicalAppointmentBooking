
using Share.DTO;
using Share.Model;
using UiBlazor.Model;

namespace UiBlazor.Services
{
    public interface IAuthService
    {
        public Task<ResponseModel<JwtTokenModel>> Login(UserLoginDto userLoginDto);
        public Task<ResponseModel<JwtTokenModel>> Register(UserRegisterDto userRegister);
    }
}
