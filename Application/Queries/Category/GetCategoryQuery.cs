using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Category;
using Application.GeneralResponses;
using MediatR;

namespace Application.Queries.Category
{
    public class GetCategoryQuery:IRequest<GeneralResponse<CategoryToGet>>
    {
        public int id { get; set; }
        public GetCategoryQuery(int Id)
        {
            this.id = Id;
        }
    }
}
