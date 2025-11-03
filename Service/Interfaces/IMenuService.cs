using Jīao.Entities;
using Jīao.Models.Dtos;

namespace Jīao.Service.Interfaces
{
    public interface IMenuService
    {
        public int Create(CreateAndUpdateMenuDto newMenu);
        public List<Menu> GetAll();
        public Menu? GetById(int menuId);
        public void RemoveMenu(int menuId);
        public void Update(CreateAndUpdateMenuDto updatedMenu, int menuId);
        public bool CheckIfMenuExists(int menuId);

    }
}
