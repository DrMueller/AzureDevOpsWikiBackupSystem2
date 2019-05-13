using System.Threading.Tasks;
using Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Services;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.FilePersisting.Services.Implementation
{
    public class PersistedFilesCleanupService : IPersistedFilesCleanupService
    {
        private readonly ISettingsProvider _settingsProvider;

        public PersistedFilesCleanupService(
            ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public Task CleanUpOldRepoZipsAsync()
        {
            return Task.CompletedTask;
        }
    }
}