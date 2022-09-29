using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication3.DAL.Interfaces;
using WebApplication3.Models.Entites;

namespace WebApplication3.DAL.Repositories
{
    public class FileContentRepository : IFileContentRepository, IDisposable
    {
        private GameContext context;

        public FileContentRepository(GameContext context)
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

        public IEnumerable<FileContent> GetFileContents()
        {
            return context.FileContent.ToList();
        }

        public FileContent GetFileContent(int id)
        {
            return context.FileContent.Find(id);
        }

        public void InsertFileContent(FileContent fileContent)
        {
            context.FileContent.Add(fileContent);
        }

        public void DeleteFileContent(int id)
        {
            FileContent fileContent = context.FileContent.Find(id);
            if(fileContent != null)
                context.FileContent.Remove(fileContent);
        }

        public void UpdateFileContent(FileContent fileContent)
        {
            context.Entry(fileContent).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
