using System.Threading.Tasks;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.Orchestration.Services
{
    public interface IBackupOrchestrationService
    {
        Task CreateBackupAsync();
    }
}