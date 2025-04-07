using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CategoryDTO categoryDto)
        {
            var entity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.CreateAsync(entity);
        }

        public async Task<CategoryDTO?> GetByIdAsync(int id)
        {
            var entity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(entity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var entities = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(entities);
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.RemoveAsync(entity);
        }

        /// <summary>
        /// Roda as migrations pendentes caso necessario
        /// </summary>
        /// <returns></returns>
        public async Task RunMigrate()
        {
            await _categoryRepository.RunMigrate();
        }

        public async Task UpdateAsync(CategoryDTO categoryDto)
        {
            var entity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.UpdateAsync(entity);
        }
    }
}
