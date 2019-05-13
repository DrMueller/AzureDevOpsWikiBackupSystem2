using System;
using NLog;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.Logging.Services.Implementation
{
    public class LoggingService : ILoggingService
    {
        private static readonly ILogger Logger = LogManager.GetLogger(nameof(LoggingService));

        public void LogInformation(string message)
        {
            Logger.Info(message);
        }

        public void LogException(Exception ex)
        {
            Logger.Error(ex);
        }
    }
}