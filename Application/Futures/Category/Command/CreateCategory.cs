using Application.Interface;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Futures.Category.Command
{
    public class CreateCategory:IRequest<CategoryModel>
    {
        public CategoryModel Category { get; set; }    
    }

    public class CreateCategoryHandler : IRequestHandler<CreateCategory, CategoryModel>
    {
        private IBaseRepository<CategoryModel> _baseRepository;
        public CreateCategoryHandler(IBaseRepository<CategoryModel> baseRepository)
        {

            _baseRepository = baseRepository;
        }
        public async Task<CategoryModel> Handle(CreateCategory request, CancellationToken cancellationToken)
        {
            return await _baseRepository.CreateAsync(request.Category);
        }
    }
}
