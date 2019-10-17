using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace coreDox.Core.Project.Pages
{
    public sealed class DoxPageFolder
    {
        public DoxPageFolder(DirectoryInfo directoryInfo)
        {
            Title = directoryInfo.Name;
            // If the folder has a index.md file,
            // take this file for the folder information
            var indexFile = directoryInfo.GetFiles("index.md").FirstOrDefault();
            if (indexFile != null)
            {
                var doxPage = new DoxPage(indexFile);
                Title = !string.IsNullOrEmpty(doxPage.Title) ? doxPage.Title : Title;
                Description = doxPage.Content;

                throw new Exception(Title + " " + doxPage.Title);
            }

            LoadFolders(directoryInfo);
            LoadPages(directoryInfo);
        }

        public List<DoxPage> GetAllAssemblyPages()
        {
            var assemblyPages = PageList.Where(p => p.AssemblyFileInfo != null).ToList();
            FolderList.ForEach(f => assemblyPages.AddRange(f.GetAllAssemblyPages()));

            return assemblyPages;
        }

        private void LoadFolders(DirectoryInfo directoryInfo)
        {
            var subDirectoryInfoList = Directory.GetDirectories(directoryInfo.FullName).Select(p => new DirectoryInfo(p));
            foreach (var directory in subDirectoryInfoList)
            {
                FolderList.Add(new DoxPageFolder(directory));
            }
        }

        private void LoadPages(DirectoryInfo directoryInfo)
        {
            PageList.AddRange(directoryInfo
                .GetFiles("*.md")
                .Where(f => f.Name != "index.md")
                .Select(p => new DoxPage(p))
                .ToList());
        }

        public string Title { get; }
        public string Description { get; }
        public List<DoxPageFolder> FolderList { get; } = new List<DoxPageFolder>();
        public List<DoxPage> PageList { get; } = new List<DoxPage>();
    }
}
