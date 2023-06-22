using Application.Interface;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Futures.Category.Queries
{
    public class GetAllCategorys:IRequest<IEnumerable<CategoryModel>>
    {
    }
    public class GetAllCategorysHandler : IRequestHandler<GetAllCategorys, IEnumerable<CategoryModel>>
    {
        private IBaseRepository<CategoryModel> _baseRepository;
        public GetAllCategorysHandler(IBaseRepository<CategoryModel> baseRepository)
        {

            _baseRepository = baseRepository;
        }
        public  async Task<IEnumerable<CategoryModel>> Handle(GetAllCategorys request, CancellationToken cancellationToken)
        {
            return await _baseRepository.GetAll();
        }
    }
}
