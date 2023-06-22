using Core.Model;
using UiBlazor.Model;

namespace UiBlazor.Services
{
    public interface IPeriodeService
    {
        Task<ResponseModel<PeroidModel>> Create(PeroidModel peroidModel);
        Task<ResponseModel<IEnumerable<PeroidModel>>> GetAll();
        Task<ResponseModel<PeroidModel>> GetById(int Id);


    }
}
