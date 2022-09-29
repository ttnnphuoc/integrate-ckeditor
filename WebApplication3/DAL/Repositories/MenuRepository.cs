using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication3.DAL.Interfaces;
using WebApplication3.Models.Entites;

namespace WebApplication3.DAL.Repositories
{
    public class MenuRepository : IMenuRepository, IDisposable
    {
        private GameContext context;

        public MenuRepository(GameContext context)
        {
            this.context = context;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Menu> GetMenus()
        {
            return context.Menu.ToList();
        }

        public Menu GetMenu(int id)
        {
            return context.Menu.Find(id);
        }

        public void InsertMenu(Menu Menu)
        {
            context.Menu.Add(Menu);
        }

        public void DeleteMenu(int id)
        {
            Menu student = context.Menu.Find(id);
            if (student != null) 
                context.Menu.Remove(student);
        }

        public void UpdateMenu(Menu Menu)
        {
            context.Entry(Menu).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
