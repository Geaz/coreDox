using coreDox.Core.Contracts;
using System.IO;

namespace coreDox.Target.Html
{
    public class HtmlConfigSection : IConfigSection
    {
        public void SetDefaultValues(FileInfo configFileInfo)
        {
            ShowCode = false;
        }

        public bool ShowCode { get; set; }
    }
}
