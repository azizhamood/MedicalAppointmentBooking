using Core.Model;
using Newtonsoft.Json;
using System.Net.Http.Json;
using UiBlazor.Model;

namespace UiBlazor.Services
{
    public class MedicalService : IMedicalService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public MedicalService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<ResponseModel<MedicalModel>> Create(MedicalModel medicalModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseModel<MedicalModel>>(await(await _httpClient.PostAsJsonAsync($"{_configuration["ApiUri"]}/api/Medical", medicalModel)).Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  async Task<ResponseModel<IEnumerable<MedicalModel>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseModel<IEnumerable<MedicalModel>>>($"{_configuration["ApiUri"]}/api/Medical");
            if (result != null && result.Code == 0)
            {
                return result;
            }
            else
            {
                throw new Exception();
            }
        }

        public Task<ResponseModel<MedicalModel>> GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
