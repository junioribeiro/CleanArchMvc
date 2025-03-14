using CleanArchMvc.Application.Mediator.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Mediator.Products.Handlers
{
    public class GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQuery, Product?>
    {
        private readonly IProductRepository _productRepository;

        public GetProductCategoryQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product?> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductCategoryAsync(request.Id);
        }
    }
}
