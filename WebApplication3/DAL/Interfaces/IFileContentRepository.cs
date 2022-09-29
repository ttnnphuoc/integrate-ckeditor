using WebApplication3.Models.Entites;

namespace WebApplication3.DAL.Interfaces
{
    public interface IFileContentRepository : IDisposable
    {
        IEnumerable<FileContent> GetFileContents();
        FileContent GetFileContent(int id);
        void InsertFileContent(FileContent Menu);
        void DeleteFileContent(int id);
        void UpdateFileContent(FileContent Menu);
        void Save();
    }
}
