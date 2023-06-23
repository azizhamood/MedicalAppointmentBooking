using Core.Model;
using UiBlazor.Model;

namespace UiBlazor.Services
{
    public interface ISpecializationService
    {
        Task<ResponseModel<CategoryModel>> Create(CategoryModel categoryModel);
        Task<ResponseModel<IEnumerable<CategoryModel>>> GetAll();
        Task<ResponseModel<CategoryModel>> GetById(int Id);
    }
}
