using System.IO.Abstractions;
using System.Net.Http;
using System.Threading.Tasks;
using Dropbox.Api;
using Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Services;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.FilePersisting.Services.Implementation
{
    public class FilePersistingService : IFilePersistingService
    {
        private readonly IFileSystem _fileSystem;
        private readonly ISettingsProvider _settingsProvider;

        public FilePersistingService(
            IFileSystem fileSystem,
            ISettingsProvider settingsProvider)
        {
            _fileSystem = fileSystem;
            _settingsProvider = settingsProvider;
        }

        public async Task PersistRepoZipAsync(string filePath)
        {
            var config = new DropboxClientConfig();
            var client = new DropboxClient("Tra", config);

            var folders = await client.Files.ListFolderAsync(new Dropbox.Api.Files.ListFolderArg(""));
        }
    }
}