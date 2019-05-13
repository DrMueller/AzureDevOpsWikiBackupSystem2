using System.IO.Abstractions;
using StructureMap;

namespace Mmu.AzureDevOpsWikiBackupSystem2.Infrastructure.DependencyInjection
{
    public class AppRegistry : Registry
    {
        public AppRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<AppRegistry>();
                scanner.WithDefaultConventions();
            });

            For<IFileSystem>().Use<FileSystem>().Singleton();
        }
    }
}