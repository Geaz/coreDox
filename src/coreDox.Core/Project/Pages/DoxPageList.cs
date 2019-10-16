using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace coreDox.Core.Project.Pages
{
    public sealed class DoxPageList : List<DoxPage>
    {
        private readonly DirectoryInfo _pagesDirectory;

        public DoxPageList(DirectoryInfo pagesDirectory)
        {
            _pagesDirectory = pagesDirectory;
            LoadPages();
        }

        private void LoadPages()
        {
            AddRange(_pagesDirectory
                .GetFiles("*.md")
                .Select(p => new DoxPage(p))
                .ToList());

            var subDirectoryInfoList = Directory.GetDirectories(_pagesDirectory.FullName).Select(p => new DirectoryInfo(p));
            foreach (var directory in subDirectoryInfoList)
            {
                var indexFile = directory.GetFiles("index.md").FirstOrDefault();
                if (indexFile != null)
                {
                    Add(new DoxPage(indexFile));
                }
                else
                {
                    Add(new DoxPage(directory));
                }
            }
        }
    }
}
