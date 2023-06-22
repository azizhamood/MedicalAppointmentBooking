using Core.Model;
using Newtonsoft.Json;
using Share.DTO;
using Share.Model;
using System.Net.Http.Json;
using UiBlazor.Model;

namespace UiBlazor.Services
{
    public class PeriodeService : IPeriodeService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public PeriodeService(HttpClient httpClient,IConfiguration configuration) 
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<ResponseModel<PeroidModel>> Create(PeroidModel peroidModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseModel<PeroidModel>>(await(await _httpClient.PostAsJsonAsync($"{_configuration["ApiUri"]}/api/Periode", peroidModel)).Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ResponseModel<IEnumerable<PeroidModel>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseModel<IEnumerable<PeroidModel>>>($"{_configuration["ApiUri"]}/api/Periode");
            if(result != null && result.Code==0) {
                return result;
            }
            else
            {
                throw new Exception();
            }

        }

        public Task<ResponseModel<PeroidModel>> GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
