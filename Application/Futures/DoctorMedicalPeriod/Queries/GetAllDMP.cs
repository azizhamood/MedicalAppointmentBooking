using Application.Futures.DoctorMedicalPeriod.Command;
using Application.Interface;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Futures.DoctorMedicalPeriod.Queries
{
    public class GetAllDMP:IRequest<IEnumerable<DoctorMedicalPeriodModel>>
    {
    }

    public class GetAllDMPHandler : IRequestHandler<GetAllDMP, IEnumerable<DoctorMedicalPeriodModel>>
    {
        private IBaseRepository<DoctorMedicalPeriodModel> _baseRepository;
        public GetAllDMPHandler(IBaseRepository<DoctorMedicalPeriodModel> baseRepository)
        {

            _baseRepository = baseRepository;
        }
        public async Task<IEnumerable<DoctorMedicalPeriodModel>> Handle(GetAllDMP request, CancellationToken cancellationToken)
        {
            return await _baseRepository.GetAll();
        }
    }
}
