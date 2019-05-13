using System.IO;
using System.IO.Abstractions;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.GitRepo.Services.Servants.Implementation
{
    public class RepoPathServant : IRepoPathServant
    {
        private readonly IFileSystem _fileSystem;

        public RepoPathServant(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void CleanUp(string repoDirectory)
        {
            if (_fileSystem.Directory.Exists(repoDirectory))
            {
                DeleteDirectories(repoDirectory);
            }
        }

        private void DeleteDirectories(string directory)
        {
            foreach (var subdirectory in _fileSystem.Directory.EnumerateDirectories(directory))
            {
                DeleteDirectories(subdirectory);
            }

            foreach (var fileName in _fileSystem.Directory.EnumerateFiles(directory))
            {
                var fileInfo = _fileSystem.FileInfo.FromFileName(fileName);
                fileInfo.Attributes = FileAttributes.Normal;
                fileInfo.Delete();
            }

            _fileSystem.Directory.Delete(directory);
        }
    }
}