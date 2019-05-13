using System;
using System.Threading.Tasks;
using Mmu.AzureDevOpsWikiBackupSystem2.Areas.Orchestration.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using Mmu.Mlh.SettingsProvisioning.Areas.Factories;

namespace Mmu.AzureDevOpsWikiBackupSystem2
{
    public static class Program
    {
        public static void Main()
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(typeof(Program).Assembly);
            var container = ContainerInitializationService.CreateInitializedContainer(containerConfig);
            var backupService = container.GetInstance<IBackupOrchestrationService>();

            Task.WaitAll(backupService.CreateBackupAsync());
        }
    }
}