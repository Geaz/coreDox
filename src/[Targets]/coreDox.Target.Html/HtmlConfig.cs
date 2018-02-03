using System.IO;
using coreDox.Core.Contracts;

namespace coreDox.Target.Html
{
    public class HtmlConfig : IConfigSection
    {
        public void SetDefaultValues(FileInfo configFileInfo)
        {
            ShowCode = false;
        }

        public bool ShowCode { get; set; }
    }
}
