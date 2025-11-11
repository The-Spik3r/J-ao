using Jīao.Data;
using Jīao.Entities;
using Jīao.Models.Dtos;
using Jīao.Repositories.Interfaces;

namespace Jīao.Repositories.Implementations
{
    public class MenuRepository : IMenuRepository
    {
        private JīaoContext _context;

        public MenuRepository(JīaoContext context)
        {
      _context = context;
        }

        public bool CheckIfMenuExists(int menuId)
   {
     return _context.Menus.Any(m => m.Id == menuId);
     }

        public int Create(CreateAndUpdateMenuDto newMenu)
        {
            Menu menuNew = new Menu()
    {
    Name = newMenu.Name,
     Price = newMenu.Price,
   Stock = newMenu.Stock,
Description = newMenu.Description,
 ImageUrl = newMenu.ImageUrl,
        CategoryId = newMenu.CategoryId,
        IsFeatured = newMenu.IsFeatured
            };

      Menu menu = _context.Menus.Add(menuNew).Entity;
     _context.SaveChanges();
    return menu.Id;
     }

    public List<Menu> GetAll()
        {
            return _context.Menus.ToList();
      }

 public Menu? GetById(int menuId)
        {
            return _context.Menus.SingleOrDefault(m => m.Id == menuId);
 }

        public void RemoveMenu(int menuId)
        {
 _context.Menus.Remove(_context.Menus.Single(m => m.Id == menuId));
    _context.SaveChanges() ;
      }

        public void Update(CreateAndUpdateMenuDto updatedMenu, int menuId)
        {
 Menu menuToUpdate = _context.Menus.First(m => m.Id == menuId);
        menuToUpdate.Name = updatedMenu.Name;
     menuToUpdate.Price = updatedMenu.Price;
        menuToUpdate.Stock = updatedMenu.Stock;
       menuToUpdate.Description = updatedMenu.Description;
     menuToUpdate.ImageUrl = updatedMenu.ImageUrl;
menuToUpdate.CategoryId = updatedMenu.CategoryId;
            menuToUpdate.IsFeatured = updatedMenu.IsFeatured;
            _context.SaveChanges();
     }
    }
}
