using Dropbox.Api;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.FilePersisting.Services.Servants
{
    public interface IDropboxClientFactory
    {
        DropboxClient Create();
    }
}