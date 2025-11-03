using Jīao.Entities;
using Jīao.Models.Dtos;

namespace Jīao.Service.Interfaces
{
    public interface ICategoryService
    {
        public int Create(CreateAndUpdateCategoryDto newCategory);
        public List<Category> GetAll();
        public Category? GetById(int categoryId);
        public void RemoveCategory(int categoryId);
        public void Update(CreateAndUpdateCategoryDto updatedCategory, int categoryId);
        public bool CheckIfCategoryExists(int categoryId);

    }
}
