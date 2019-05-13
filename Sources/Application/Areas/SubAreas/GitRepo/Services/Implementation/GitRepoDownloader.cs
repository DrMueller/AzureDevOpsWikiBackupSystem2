using System.IO.Abstractions;
using LibGit2Sharp;
using Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.GitRepo.Models;
using Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.GitRepo.Services.Servants;
using Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Services;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.GitRepo.Services.Implementation
{
    public class GitRepoDownloader : IGitRepoDownloader
    {
        private readonly IFileSystem _fileSystem;
        private readonly IRepoPathServant _repoPathServant;
        private readonly ISettingsProvider _settingsProvider;

        public GitRepoDownloader(
            ISettingsProvider settingsProvider,
            IRepoPathServant repoPathServant,
            IFileSystem fileSystem)
        {
            _settingsProvider = settingsProvider;
            _repoPathServant = repoPathServant;
            _fileSystem = fileSystem;
        }

        public void CleanUp(string repoDirectory)
        {
            _repoPathServant.CleanUp(repoDirectory);
        }

        public RepoDownloadResult DownloadRepo()
        {
            var settings = _settingsProvider.ProvideSettings();
            var repoDirectory = settings.GitDownloadTempDirectory;

            _repoPathServant.CleanUp(repoDirectory);
            var newDirectory = _fileSystem.Directory.CreateDirectory(repoDirectory);

            var options = new CloneOptions
            {
                CredentialsProvider = (url, user, cred) => new UsernamePasswordCredentials
                {
                    Username = settings.AzureDevOpsRepoAccessToken,
                    Password = string.Empty
                }
            };

            var clonedRepo = Repository.Clone(settings.AzureDevOpsRepoPath.AbsoluteUri, repoDirectory, options);
            var directoryInfo = _fileSystem.DirectoryInfo.FromDirectoryName(clonedRepo).Parent;
            return new RepoDownloadResult(directoryInfo.FullName);
        }
    }
}