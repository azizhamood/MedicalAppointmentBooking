using Application.Futures.Doctor.Command;
using Application.Interface;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Futures.Medical.Command
{
    public class CreateMedical:IRequest<MedicalModel>
    {
        public MedicalModel MedicalModel { get; set; }
    }
    public class CreateMedicalHandler :IRequestHandler<CreateMedical, MedicalModel>
    {
        private IBaseRepository<MedicalModel> _baseRepository;
        public CreateMedicalHandler(IBaseRepository<MedicalModel> baseRepository)
        {

            _baseRepository = baseRepository;
        }
        public async Task<MedicalModel> Handle(CreateMedical request, CancellationToken cancellationToken)
        {

            return await _baseRepository.CreateAsync(request.MedicalModel);

        }
    }
}
