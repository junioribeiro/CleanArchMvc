using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _categoryContext;

        public CategoryRepository(ApplicationDbContext categoryContext)
        {
            _categoryContext = categoryContext;
        }

        public async Task<Category> CreateAsync(Category entity)
        {
            _categoryContext.Add(entity);
            await _categoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<Category> RemoveAsync(Category entity)
        {
            _categoryContext.Remove(entity);
            await _categoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task RunMigrate()
        {
           await _categoryContext.Database.MigrateAsync();
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            _categoryContext.Update(entity);
            await _categoryContext.SaveChangesAsync();
            return entity;
        }
    }
}
