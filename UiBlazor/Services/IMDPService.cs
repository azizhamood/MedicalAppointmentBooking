using Core.Model;
using UiBlazor.Model;

namespace UiBlazor.Services
{
    public interface IMDPService
    {
        Task<ResponseModel<DoctorMedicalPeriodModel>> Create(DoctorMedicalPeriodModel dmp);
        Task<ResponseModel<IEnumerable<DoctorMedicalPeriodModel>>> GetAll();
        Task<ResponseModel<DoctorMedicalPeriodModel>> GetById(int Id);
    }
}
