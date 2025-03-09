using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Category;
using Application.GeneralResponses;
using Application.Interfaces.UnitOfWork;
using Application.Queries.Category;
using MediatR;

namespace Application.Handlers.Category
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, GeneralResponse<CategoryToGet>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<GeneralResponse<CategoryToGet>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            GeneralResponse<CategoryToGet> response = unitOfWork.CategoryMapper.GetCategoryById2(request.id);
            return Task.FromResult(response);
        }
    }
}
