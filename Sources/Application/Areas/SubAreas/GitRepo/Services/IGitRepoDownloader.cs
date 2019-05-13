using Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.GitRepo.Models;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.GitRepo.Services
{
    public interface IGitRepoDownloader
    {
        RepoDownloadResult DownloadRepo(string baseDirectory);

        void CleanUp(string repoDirectory);
    }
}