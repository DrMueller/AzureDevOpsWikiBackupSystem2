using Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.Zipping.Models;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.Zipping.Services
{
    public interface IZippingService
    {
        ZippingResult ZipDirectory(string directoryPath);
    }
}