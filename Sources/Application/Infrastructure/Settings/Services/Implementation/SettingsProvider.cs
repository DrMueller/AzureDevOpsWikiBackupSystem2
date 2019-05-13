using System;
using Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Dtos;
using Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Models;
using Mmu.Mlh.SettingsProvisioning.Areas.Factories;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Services.Implementation
{
    public class SettingsProvider : ISettingsProvider
    {
        private readonly ISettingsFactory _settingsFactory;

        public SettingsProvider(ISettingsFactory settingsFactory)
        {
            _settingsFactory = settingsFactory;
        }

        public AppSettings ProvideSettings()
        {
            var settingsDto = _settingsFactory.CreateSettings<AppSettingsDto>(
                AppSettingsDto.SectionKey,
                string.Empty,
                @"C:\Users\Matthias\Desktop\Work\AzureDevOpsWikibackupSystem\appsettings.json");

            return new AppSettings(
                settingsDto.AzureDevOpsRepoAccessToken,
                new Uri(settingsDto.AzureDevOpsRepoPath),
                settingsDto.DropboxApiKey,
                settingsDto.GitDownloadTempDirectory);
        }
    }
}