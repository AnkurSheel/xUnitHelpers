using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace xUnitHelpers
{
    public static class EmbeddedResourceHelper
    {
        public static async Task<string> GetContentFromEmbeddedResource<TCallerType>(
            string subdirectory,
            string fileName,
            string fileExtension,
            [CallerFilePath] string callerFilePath = "")
        {
            var directory = Directory.GetParent(callerFilePath);

            if (directory == null)
            {
                throw new DirectoryNotFoundException($"Unable to extract directory from path: {callerFilePath}");
            }

            var callerType = typeof(TCallerType);
            var assembly = Assembly.GetAssembly(callerType).AssertNotNull();

            if (assembly == null)
            {
                throw new InvalidOperationException($"Assembly({callerType.FullName}) is not available");
            }

            var embeddedResourcePath = GetEmbeddedResourcePath(subdirectory,
                fileName,
                fileExtension,
                assembly.GetName().Name,
                directory.FullName);

            await using var stream = assembly.GetManifestResourceStream(embeddedResourcePath);

            if (stream == null)
            {
                throw new InvalidOperationException($"Embedded Resource ({embeddedResourcePath}) is not available");
            }

            using var reader = new StreamReader(stream);

            return await reader.ReadToEndAsync();
        }

        private static string GetEmbeddedResourcePath(
            string subdirectory,
            string fileName,
            string fileExtension,
            string assemblyName,
            string directoryName)
        {
            var index = directoryName.LastIndexOf(assemblyName, StringComparison.Ordinal);

            var fullResourcePath = Path.Combine(directoryName[index..], subdirectory, fileName , fileExtension);

            fullResourcePath = fullResourcePath.Replace(Path.DirectorySeparatorChar, '.').Replace(Path.AltDirectorySeparatorChar, '.');

            return fullResourcePath;
        }
    }
}
