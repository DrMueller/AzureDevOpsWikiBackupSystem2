namespace Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Dtos
{
    public class AppSettingsDto
    {
        public const string SectionKey = "AppSettings";

        public string AzureDevOpsRepoAccessToken { get; set; }

        public string AzureDevOpsRepoPath { get; set; }

        public string DropboxApiKey { get; set; }

        public string GitDownloadTempDirectory { get; set; }
    }
}