using System;
using System.IO.Abstractions;
using System.IO.Compression;
using Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.Zipping.Models;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Areas.SubAreas.Zipping.Services.Implementation
{
    public class ZippingService : IZippingService
    {
        private readonly IFileSystem _fileSystem;

        public ZippingService(
            IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public ZippingResult ZipDirectory(string directoryPath)
        {
            var parentDir = _fileSystem.DirectoryInfo.FromDirectoryName(directoryPath).Parent.FullName;
            var zipFileName = $"Repo_{DateTime.UtcNow.ToString("yyyyMMdd")}.zip";
            var zipFilePath = _fileSystem.Path.Combine(parentDir, zipFileName);

            if (_fileSystem.File.Exists(zipFilePath))
            {
                _fileSystem.File.Delete(zipFilePath);
            }

            ZipFile.CreateFromDirectory(directoryPath, zipFilePath, CompressionLevel.Optimal, false);
            return new ZippingResult(zipFilePath);
        }
    }
}