namespace Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Dto
{
    public class AppSettingsDto
    {
        public const string SectionKey = "AppSettings";

        public string AzureDevOpsRepoAccessToken { get; set; }

        public string AzureDevOpsRepoPath { get; set; }

        public string StorageConnectionString { get; set; }
    }
}