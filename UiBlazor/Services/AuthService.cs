
using Core.Model;
using Newtonsoft.Json;
using Share.DTO;
using Share.Model;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using UiBlazor.Model;

namespace UiBlazor.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public AuthService(HttpClient httpClient,IConfiguration configuration )
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<ResponseModel<JwtTokenModel>> Login(UserLoginDto userLoginDto)
        {
            return JsonConvert.DeserializeObject<ResponseModel<JwtTokenModel>>(await (await _httpClient.PostAsJsonAsync($"{_configuration["ApiUri"]}/api/Auth/login", userLoginDto)).Content.ReadAsStringAsync());
        }

        public  async Task<ResponseModel<JwtTokenModel>> Register(UserRegisterDto userRegister)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_configuration["ApiUri"]}/api/Auth/register", userRegister);

            ResponseModel<JwtTokenModel> result = JsonConvert.DeserializeObject<ResponseModel<JwtTokenModel>>(await response.Content.ReadAsStringAsync());
            return result;

        }
    }
}
