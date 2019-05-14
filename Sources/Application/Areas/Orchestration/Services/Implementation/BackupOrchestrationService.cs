using System.IO.Abstractions;
using System.Threading.Tasks;
using Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.FilePersisting.Services;
using Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.GitRepo.Services;
using Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.Zipping.Services;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.Orchestration.Services.Implementation
{
    public class BackupOrchestrationService : IBackupOrchestrationService
    {
        private readonly IFilePersistingService _filePersistingService;
        private readonly IFileSystem _fileSystem;
        private readonly IGitRepoDownloader _gitRepoDownloader;
        private readonly IPersistedFilesCleanupService _persistFilesCleanUpService;
        private readonly IZippingService _zippingService;

        public BackupOrchestrationService(
            IFileSystem fileSystem,
            IGitRepoDownloader gitRepoDownloader,
            IZippingService zippingService,
            IFilePersistingService filePersistingService,
            IPersistedFilesCleanupService persistFilesCleanUpService)
        {
            _fileSystem = fileSystem;
            _gitRepoDownloader = gitRepoDownloader;
            _zippingService = zippingService;
            _filePersistingService = filePersistingService;
            _persistFilesCleanUpService = persistFilesCleanUpService;
        }

        public async Task CreateBackupAsync()
        {
            var downloadDirectory = string.Empty;
            var zipFilePath = string.Empty;
            try
            {
                var downloadRepoResult = _gitRepoDownloader.DownloadRepo();
                downloadDirectory = downloadRepoResult.DirectoryPath;
                zipFilePath = _zippingService.ZipDirectory(downloadDirectory).ZipFilePath;
                await _filePersistingService.PersistRepoZipAsync(zipFilePath);
                await _persistFilesCleanUpService.CleanUpOldRepoZipsAsync();
            }
            finally
            {
                if (_fileSystem.File.Exists(zipFilePath))
                {
                    _fileSystem.File.Delete(zipFilePath);
                }

                _gitRepoDownloader.CleanUp(downloadDirectory);
            }
        }
    }
}