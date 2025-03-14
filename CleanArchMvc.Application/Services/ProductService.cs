using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mediator.Products.Commands;
using CleanArchMvc.Application.Mediator.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var query = new GetProductByIdQuery(id);
            if (query is null)
                throw new ApplicationException("Entity could not be loaded.");

            var entity = await _mediator.Send(query);
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<ProductDTO> GetProductCategoryAsync(int id)
        {
            var query = new GetProductCategoryQuery(id);
            if (query is null)
                throw new ApplicationException("Entity could not be loaded.");

            var entity = await _mediator.Send(query);

            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var query = new GetProductsQuery();
            if (query is null)
                throw new ApplicationException("Entity could not be loaded.");

            var entities = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<ProductDTO>>(entities);
        }

        public async Task AddAsync(ProductDTO productDto)
        {
            var command = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(command);
        }

        public async Task RemoveAsync(int id)
        {
            var command = new ProductRemoveCommand(id);           
            await _mediator.Send(command);
        }

        public async Task UpdateAsync(ProductDTO productDto)
        {
            var command = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(command);
        }
    }
}
