using Application.Interface;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Futures.DoctorMedicalPeriod.Command
{
    public class CreateDMP : IRequest<DoctorMedicalPeriodModel>
    {
        public DoctorMedicalPeriodModel DoctorMedicalPeriod { get; set; }
    }

    public class CreateDMPHandler : IRequestHandler<CreateDMP, DoctorMedicalPeriodModel>
    {

        private IBaseRepository<DoctorMedicalPeriodModel> _baseRepository;
        public CreateDMPHandler(IBaseRepository<DoctorMedicalPeriodModel> baseRepository)
        {

            _baseRepository = baseRepository;
        }
        public async Task<DoctorMedicalPeriodModel> Handle(CreateDMP request, CancellationToken cancellationToken)
        {
            return await _baseRepository.CreateAsync(request.DoctorMedicalPeriod);
        }
    }
}
