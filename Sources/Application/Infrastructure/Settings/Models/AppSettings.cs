using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Models
{
    public class AppSettings
    {
        public string AzureDevOpsRepoAccessToken { get; }
        public Uri AzureDevOpsRepoPath { get; }
        public string DropboxApiKey { get; }
        public string GitDownloadTempDirectory { get; }

        public AppSettings(
            string azureDevOpsRepoAccessToken,
            Uri azureDevOpsRepoPath,
            string dropboxApiKey,
            string gitDownloadTempPath)
        {
            Guard.StringNotNullOrEmpty(() => azureDevOpsRepoAccessToken);
            Guard.ObjectNotNull(() => azureDevOpsRepoPath);
            Guard.StringNotNullOrEmpty(() => dropboxApiKey);

            AzureDevOpsRepoAccessToken = azureDevOpsRepoAccessToken;
            AzureDevOpsRepoPath = azureDevOpsRepoPath;
            DropboxApiKey = dropboxApiKey;
            GitDownloadTempDirectory = gitDownloadTempPath;
        }
    }
}