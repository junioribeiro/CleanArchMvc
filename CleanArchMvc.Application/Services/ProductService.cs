using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductDTO productDto) 
        {
            var entity = _mapper.Map<Product>(productDto);
            await _productRepository.CreateAsync(entity);
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<ProductDTO> GetProductCategoryAsync(int id)
        {
            var entity = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var entities = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(entities);
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            await _productRepository.RemoveAsync(entity);
        }

        public async Task UpdateAsync(ProductDTO productDto)
        {
            var entity = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(entity);
        }
    }
}
