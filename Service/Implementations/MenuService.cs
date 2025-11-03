using Jīao.Entities;
using Jīao.Models.Dtos;
using Jīao.Repositories.Interfaces;
using Jīao.Service.Interfaces;

namespace Jīao.Service.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _repository;
        public MenuService(IMenuRepository repository) {
    _repository = repository;
        }

        public bool CheckIfMenuExists(int menuId)
        {
    return _repository.CheckIfMenuExists(menuId);
     }

    public int Create(CreateAndUpdateMenuDto newMenu)
   {
            return _repository.Create(newMenu);
      }

        public List<Menu> GetAll()
        {
     return _repository.GetAll();
        }

        public Menu? GetById(int menuId)
     {
  return _repository.GetById(menuId);
    }

        public void RemoveMenu(int menuId)
   {
         _repository.RemoveMenu(menuId);
        }

        public void Update(CreateAndUpdateMenuDto updatedMenu, int menuId)
        {
            _repository.Update(updatedMenu, menuId);
        }
    }
}
