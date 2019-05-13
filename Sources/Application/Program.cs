using System;
using System.Threading.Tasks;
using Mmu.AzureDevOpsWikiBackupSystem2.Areas.Orchestration.Services;
using Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Logging.Services;
using Mmu.Mlh.ConsoleExtensions.Areas.ExecutionContext.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;

namespace Mmu.AzureDevOpsWikiBackupSystem2
{
    public static class Program
    {
        public static void Main()
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(typeof(Program).Assembly);
            var container = ContainerInitializationService.CreateInitializedContainer(containerConfig);
            var actionHandler = container.GetInstance<IConsoleActionHandler>();

            actionHandler.HandleAction(() =>
            {
                try
                {
                    var backupService = container.GetInstance<IBackupOrchestrationService>();
                    Task.WaitAll(backupService.CreateBackupAsync());
                }
                catch (Exception ex)
                {
                    container.GetInstance<ILoggingService>().LogException(ex);
                    throw;
                }
            });
        }
    }
}