using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.GitRepo.Models
{
    public class RepoDownloadResult
    {
        public string DirectoryPath { get; }

        public RepoDownloadResult(string directoryPath)
        {
            Guard.StringNotNullOrEmpty(() => directoryPath);
            DirectoryPath = directoryPath;
        }
    }
}