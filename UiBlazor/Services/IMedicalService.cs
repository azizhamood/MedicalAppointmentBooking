using Core.Model;
using UiBlazor.Model;

namespace UiBlazor.Services
{
    public interface IMedicalService
    {
        Task<ResponseModel<MedicalModel>> Create(MedicalModel medicalModel);
        Task<ResponseModel<IEnumerable<MedicalModel>>> GetAll();
        Task<ResponseModel<MedicalModel>> GetById(int Id);
    }
}
