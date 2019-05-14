using System;
using System.Linq;
using System.Threading.Tasks;
using Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.FilePersisting.Services.Servants;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.FilePersisting.Services.Implementation
{
    public class PersistedFilesCleanupService : IPersistedFilesCleanupService
    {
        private readonly IDropboxClientFactory _dropboxClientFactory;

        public PersistedFilesCleanupService(
            IDropboxClientFactory dropboxClientFactory)
        {
            _dropboxClientFactory = dropboxClientFactory;
        }

        public async Task CleanUpOldRepoZipsAsync()
        {
            var client = _dropboxClientFactory.Create();
            var folderEntries = await client.Files.ListFolderAsync(string.Empty);
            var oldFileEntries = folderEntries
                .Entries
                .Where(f => f.IsFile)
                .Select(f => f.AsFile)
                .Where(f => (DateTime.UtcNow - f.ServerModified).TotalDays >= 40);

            var deleteTasks = oldFileEntries.Select(f => client.Files.DeleteV2Async(f.PathLower));
            await Task.WhenAll(deleteTasks);
        }
    }
}