using Core.Model;
using Newtonsoft.Json;
using System.Net.Http.Json;
using UiBlazor.Model;

namespace UiBlazor.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public DoctorService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<ResponseModel<DoctorModel>> Create(DoctorModel doctorModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseModel<DoctorModel>>(await (await _httpClient.PostAsJsonAsync($"{_configuration["ApiUri"]}/api/Doctor", doctorModel)).Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ResponseModel<IEnumerable<DoctorModel>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseModel<IEnumerable<DoctorModel>>>($"{_configuration["ApiUri"]}/api/Doctor");
            if (result != null && result.Code == 0)
            {
                return result;
            }
            else
            {
                throw new Exception();
            }

        }

        public Task<ResponseModel<DoctorModel>> GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
