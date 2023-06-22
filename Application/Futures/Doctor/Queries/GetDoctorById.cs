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
    public class GetDoctorById:IRequest<DoctorModel>
    {
        public int Id { get; set; }
    }


    public class GetDoctorByIdHandler:IRequestHandler<GetDoctorById, DoctorModel>
    {
        private IBaseRepository<DoctorModel> _baseRepository;
        public GetDoctorByIdHandler(IBaseRepository<DoctorModel> baseRepository)
        {

            _baseRepository = baseRepository;
        }

        public async Task<DoctorModel> Handle(GetDoctorById request, CancellationToken cancellationToken)
        {
            return  _baseRepository.Get(x => x.Id == request.Id).Result.FirstOrDefault();
        }
    }
}
