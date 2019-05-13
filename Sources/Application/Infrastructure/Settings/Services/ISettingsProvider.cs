using Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Models;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Services
{
    public interface ISettingsProvider
    {
        AppSettings ProvideSettings();
    }
}