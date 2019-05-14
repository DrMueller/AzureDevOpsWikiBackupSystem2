using System.IO.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Dropbox.Api.Files;
using Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.FilePersisting.Services.Servants;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.FilePersisting.Services.Implementation
{
    public class FilePersistingService : IFilePersistingService
    {
        private readonly IDropboxClientFactory _dropboxClientFactory;
        private readonly IFileSystem _fileSystem;

        public FilePersistingService(
            IDropboxClientFactory dropboxClientFactory,
            IFileSystem fileSystem)
        {
            _dropboxClientFactory = dropboxClientFactory;
            _fileSystem = fileSystem;
        }

        public async Task PersistRepoZipAsync(string filePath)
        {
            var cancelSource = new CancellationTokenSource();

            var task = Task.Factory.StartNew(
                function: () => UploadToDropBoxAsync(filePath),
                cancellationToken: cancelSource.Token,
                creationOptions: TaskCreationOptions.LongRunning,
                scheduler: TaskScheduler.Default);

            var unwrappedTask = task.Unwrap();
            await unwrappedTask;
        }

        private Task UploadToDropBoxAsync(string filePath)
        {
            var fileName = _fileSystem.Path.GetFileName(filePath);
            var streamData = _fileSystem.File.OpenRead(filePath);
            streamData.Seek(0, System.IO.SeekOrigin.Begin);

            var client = _dropboxClientFactory.Create();
            return client.Files.UploadAsync($"/{fileName}", WriteMode.Overwrite.Instance, body: streamData);
        }
    }
}