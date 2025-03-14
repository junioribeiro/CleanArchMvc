using CleanArchMvc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Mediator.Products.Queries
{
    public class GetProductCategoryQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductCategoryQuery(int id)
        {
            Id = id;
        }    
    }
}
