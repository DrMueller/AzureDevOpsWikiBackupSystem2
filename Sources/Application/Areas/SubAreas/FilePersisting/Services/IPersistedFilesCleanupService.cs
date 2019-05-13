using System.Threading.Tasks;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.FilePersisting.Services
{
    public interface IPersistedFilesCleanupService
    {
        Task CleanUpOldRepoZipsAsync();
    }
}