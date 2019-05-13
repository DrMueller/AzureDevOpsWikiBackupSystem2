using System;
using System.IO.Abstractions;
using System.Reflection;
using Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Dto;
using Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Models;
using Mmu.Mlh.SettingsProvisioning.Areas.Factories;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Services.Implementation
{
    public class SettingsProvider : ISettingsProvider
    {
        private readonly IFileSystem _fileSystem;
        private readonly ISettingsFactory _settingsFactory;

        public SettingsProvider(
            IFileSystem fileSystem,
            ISettingsFactory settingsFactory)
        {
            _fileSystem = fileSystem;
            _settingsFactory = settingsFactory;
        }

        public AppSettings ProvideSettings()
        {
            var settingsDto = _settingsFactory.CreateSettings<AppSettingsDto>(
                AppSettingsDto.SectionKey,
                string.Empty,
                GetCodeBasePath());

            return new AppSettings(
                settingsDto.AzureDevOpsRepoAccessToken,
                new Uri(settingsDto.AzureDevOpsRepoPath),
                settingsDto.StorageConnectionString);
        }

        private string GetCodeBasePath()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var result = Uri.UnescapeDataString(uri.Path);
            result = _fileSystem.Path.GetDirectoryName(result);

            return result;
        }
    }
}