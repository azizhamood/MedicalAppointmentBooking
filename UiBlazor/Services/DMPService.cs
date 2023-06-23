using Core.Model;
using Newtonsoft.Json;
using System.Net.Http.Json;
using UiBlazor.Model;

namespace UiBlazor.Services
{
    public class DMPService : IMDPService
    {

        private HttpClient _httpClient;
        private IConfiguration _configuration;
        public DMPService(HttpClient httpClient,IConfiguration configuration) 
        { 
          _httpClient= httpClient;
          _configuration= configuration;
        }
        public async Task<ResponseModel<DoctorMedicalPeriodModel>> Create(DoctorMedicalPeriodModel dmp)
        {
            try
            {
                var result= JsonConvert.DeserializeObject<ResponseModel<DoctorMedicalPeriodModel>>(await(await _httpClient.PostAsJsonAsync($"{_configuration["ApiUri"]}/api/MedicalDoctorPriode", dmp)).Content.ReadAsStringAsync());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseModel<IEnumerable<DoctorMedicalPeriodModel>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseModel<IEnumerable<DoctorMedicalPeriodModel>>>($"{_configuration["ApiUri"]}/api/MedicalDoctorPriode");
            if (result != null && result.Code == 0)
            {
                return result;
            }
            else
            {
                throw new Exception();
            }
        }

        public Task<ResponseModel<DoctorMedicalPeriodModel>> GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
