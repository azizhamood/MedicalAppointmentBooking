using Application.Interface;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Futures.Periode.Queries
{
    public class GetAllPeriod:IRequest<IEnumerable<PeroidModel>>
    {
    }

    public class GetAllPeriodHandler : IRequestHandler<GetAllPeriod, IEnumerable<PeroidModel>>
    {
        private IBaseRepository<PeroidModel> _baseRepository;
        public GetAllPeriodHandler(IBaseRepository<PeroidModel> baseRepository)
        {

            _baseRepository = baseRepository;
        }
        public async Task<IEnumerable<PeroidModel>> Handle(GetAllPeriod request, CancellationToken cancellationToken)
        {
            return await _baseRepository.GetAll();

        }
    }
}
