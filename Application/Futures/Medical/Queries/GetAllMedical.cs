using Application.Interface;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Futures.Medical.Queries
{
    public class GetAllMedical:IRequest<IEnumerable<MedicalModel>>
    {
    }

    public class GetAllMedicalhandler : IRequestHandler<GetAllMedical, IEnumerable<MedicalModel>>
    {
        private IBaseRepository<MedicalModel> _baseRepository;
        public GetAllMedicalhandler(IBaseRepository<MedicalModel> baseRepository)
        {

            _baseRepository = baseRepository;
        }
        public async Task<IEnumerable<MedicalModel>> Handle(GetAllMedical request, CancellationToken cancellationToken)
        {
            return await _baseRepository.GetAll();
        }
    }
}
