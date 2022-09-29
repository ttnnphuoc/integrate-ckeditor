using WebApplication3.Models.Entites;

namespace WebApplication1.DAL
{
    public class UnitOfWork : IDisposable
    {

        private GameContext _gameContext = new GameContext();
        private GenericRepository<Menu> menuRepository;
        private GenericRepository<FileContent> fileRepository;

        public GenericRepository<Menu> MenuRepository
        {
            get
            {
                if (this.menuRepository == null)
                {
                    return this.menuRepository = new GenericRepository<Menu>(_gameContext);
                }
                return this.menuRepository;
            }
        }
        public GenericRepository<FileContent> FileRepository
        {
            get
            {
                if (this.fileRepository == null)
                {
                    return this.fileRepository = new GenericRepository<FileContent>(_gameContext);
                }
                return this.fileRepository;
            }
        }

        public void Save()
        {
            _gameContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _gameContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
