using System;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Logging.Services
{
    public interface ILoggingService
    {
        void LogInformation(string message);

        void LogException(Exception ex);
    }
}