using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category entity);
        Task<Category> UpdateAsync(Category entity);
        Task<Category> RemoveAsync(Category entity);
        Task RunMigrate();
    }
}
