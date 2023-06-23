using Core.Model;
using UiBlazor.Model;

namespace UiBlazor.Services
{
    public interface IDoctorService
    {
        Task<ResponseModel<DoctorModel>> Create(DoctorModel doctorModel);
        Task<ResponseModel<IEnumerable<DoctorModel>>> GetAll();
        Task<ResponseModel<DoctorModel>> GetById(int Id);
    }
}
