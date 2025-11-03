using Jīao.Entities;
using Jīao.Models.Dtos;
using Jīao.Repositories.Interfaces;
using Jīao.Service.Interfaces;

namespace Jīao.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository) {
            _repository = repository;
        }

        public bool CheckIfCategoryExists(int categoryId)
        {
            return _repository.CheckIfCategoryExists(categoryId);
        }

        public int Create(CreateAndUpdateCategoryDto newCategory)
        {
            return _repository.Create(newCategory);
        }

        public List<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category? GetById(int categoryId)
        {
            return _repository.GetById(categoryId);
        }

        public void RemoveCategory(int categoryId)
        {
            _repository.RemoveCategory(categoryId);
        }

        public void Update(CreateAndUpdateCategoryDto updatedCategory, int categoryId)
        {
            _repository.Update(updatedCategory, categoryId);
        }
    }
}
