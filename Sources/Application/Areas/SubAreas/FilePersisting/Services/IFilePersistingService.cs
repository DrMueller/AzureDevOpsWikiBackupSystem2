using System.Threading.Tasks;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.FilePersisting.Services
{
    public interface IFilePersistingService
    {
        Task PersistRepoZipAsync(string filePath);
    }
}