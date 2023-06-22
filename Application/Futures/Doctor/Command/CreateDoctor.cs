using Application.Interface;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Futures.Doctor.Command
{
    public class CreateDoctor:IRequest<DoctorModel>
    {
        public DoctorModel Doctor { get; set; }
    }

    public class CreateDoctorHandler : IRequestHandler<CreateDoctor, DoctorModel>
    {
        private IBaseRepository<DoctorModel> _baseRepository;
        public CreateDoctorHandler(IBaseRepository<DoctorModel> baseRepository ) { 
           
             _baseRepository= baseRepository;
        }
        public async Task<DoctorModel> Handle(CreateDoctor request, CancellationToken cancellationToken)
        {
            
              return await _baseRepository.CreateAsync(request.Doctor);
        
        }
    }
}
