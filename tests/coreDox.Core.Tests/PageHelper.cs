using System.IO;
using System.Text;

namespace coreDox.Core.Tests
{
    internal static class PageHelper
    {
        public static void WritePage(string path, string title, string content, string assemblyPath = null)
        {
            var pageBuilder = new StringBuilder();
            pageBuilder.AppendLine($"---");
            pageBuilder.AppendLine($"- title: {title}");

            if (!string.IsNullOrEmpty(assemblyPath))
                pageBuilder.AppendLine($"- assembly: {assemblyPath}");

            pageBuilder.AppendLine($"---");
            pageBuilder.AppendLine(content);

            File.WriteAllText(path, pageBuilder.ToString());
        }
    }
}
