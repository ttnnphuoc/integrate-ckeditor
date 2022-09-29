using WebApplication3.Models.Entites;

namespace WebApplication3.DAL.Interfaces
{
    public interface IMenuRepository : IDisposable
    {
        IEnumerable<Menu> GetMenus();
        Menu GetMenu(int id);
        void InsertMenu(Menu Menu);
        void DeleteMenu(int id);
        void UpdateMenu(Menu Menu);
        void Save();
    }
}
