using Core.Model;
using Newtonsoft.Json;
using System.Net.Http.Json;
using UiBlazor.Model;

namespace UiBlazor.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public SpecializationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<ResponseModel<CategoryModel>> Create(CategoryModel categoryModel )
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseModel<CategoryModel>>(await (await _httpClient.PostAsJsonAsync($"{_configuration["ApiUri"]}/api/Category", categoryModel)).Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ResponseModel<IEnumerable<CategoryModel>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseModel<IEnumerable<CategoryModel>>>($"{_configuration["ApiUri"]}/api/Category");
            if (result != null && result.Code == 0)
            {
                return result;
            }
            else
            {
                throw new Exception();
            }

        }

        public Task<ResponseModel<CategoryModel>> GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
