using Application.Interface;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Futures.Periode.Command
{
    public class CreatePeriod:IRequest<PeroidModel>
    {
        public PeroidModel PeroidModel { get; set; }    
    }

    public class CreatePeriodhandler : IRequestHandler<CreatePeriod, PeroidModel>
    {
        private IBaseRepository<PeroidModel> _baseRepository;
        public CreatePeriodhandler(IBaseRepository<PeroidModel> baseRepository)
        {

            _baseRepository = baseRepository;
        }
        public  async Task<PeroidModel> Handle(CreatePeriod request, CancellationToken cancellationToken)
        {
            return await _baseRepository.CreateAsync(request.PeroidModel);
        }
    }
}
