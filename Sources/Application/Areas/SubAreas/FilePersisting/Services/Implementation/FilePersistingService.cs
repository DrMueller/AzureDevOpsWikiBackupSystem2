using System;
using System.IO.Abstractions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Services;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.FilePersisting.Services.Implementation
{
    public class FilePersistingService : IFilePersistingService
    {
        private readonly ISettingsProvider _settingsProvider;
        private readonly IFileSystem _fileSystem;

        public FilePersistingService(
            ISettingsProvider settingsProvider,
            IFileSystem fileSystem)
        {
            _settingsProvider = settingsProvider;
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
            var apiKey = _settingsProvider.ProvideSettings().DropboxApiKey;
            var config = new DropboxClientConfig
            {
                HttpClient = new HttpClient
                {
                    Timeout = new TimeSpan(1, 0, 0)
                }
            };

            var client = new DropboxClient(apiKey, config);
            var fileName = _fileSystem.Path.GetFileName(filePath);

            var streamData = _fileSystem.File.OpenRead(filePath);
            streamData.Seek(0, System.IO.SeekOrigin.Begin);
            return client.Files.UploadAsync($"/{fileName}", WriteMode.Overwrite.Instance, body: streamData);
        }
    }
}