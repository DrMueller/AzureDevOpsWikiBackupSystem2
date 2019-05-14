using System;
using System.Net.Http;
using Dropbox.Api;
using Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Settings.Services;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.FilePersisting.Services.Servants.Implementation
{
    public class DropboxClientFactory : IDropboxClientFactory
    {
        private readonly ISettingsProvider _settingsProvider;

        public DropboxClientFactory(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public DropboxClient Create()
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
            return client;
        }
    }
}