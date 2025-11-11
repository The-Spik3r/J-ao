using Jīao.Data;
using Jīao.Entities;
using Jīao.Models.Dtos;
using Jīao.Repositories.Interfaces;

namespace Jīao.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private JīaoContext _context;

        public CategoryRepository(JīaoContext context)
        {
            _context = context;
        }

        public bool CheckIfCategoryExists(int categoryId)
        {
            return _context.Categories.Any(c => c.Id == categoryId);
        }

        public int Create(CreateAndUpdateCategoryDto newCategory)
        {
            Category categoryNew = new Category()
            {
                MarketStallId = newCategory.MarketStallId,
                Name = newCategory.Name,
                Description = newCategory.Description,
                FotoUrl = newCategory.FotoUrl
            };

            Category category = _context.Categories.Add(categoryNew).Entity;
            _context.SaveChanges();
            return category.Id;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category? GetById(int categoryId)
        {
            return _context.Categories.SingleOrDefault(c => c.Id == categoryId);
        }

        public void RemoveCategory(int categoryId)
        {
            _context.Categories.Remove(_context.Categories.Single(c => c.Id == categoryId));
            _context.SaveChanges() ;
        }

        public void Update(CreateAndUpdateCategoryDto updatedCategory, int categoryId)
        {
            Category categoryToUpdate = _context.Categories.First(s => s.Id == categoryId);
            categoryToUpdate.Name = updatedCategory.Name;
            categoryToUpdate.MarketStallId = updatedCategory.MarketStallId;
            categoryToUpdate.Description = updatedCategory.Description;
            categoryToUpdate.FotoUrl = updatedCategory.FotoUrl;
            _context.SaveChanges();
        }
    }
}
