using Application.Interface;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Futures.Doctor.Queries
{
    public  class GetAllDoctors:IRequest<IEnumerable<DoctorModel>>
    {

    }
    public class GetAllDoctorsHandler : IRequestHandler<GetAllDoctors, IEnumerable<DoctorModel>>
    {
        private IBaseRepository<DoctorModel> _baseRepository;
        public GetAllDoctorsHandler(IBaseRepository<DoctorModel> baseRepository)
        {

            _baseRepository = baseRepository;
        }
        public async Task<IEnumerable<DoctorModel>> Handle(GetAllDoctors request, CancellationToken cancellationToken)
        {
            return  await _baseRepository.GetAll(new[] { "Category" } );
        }
    }
}
