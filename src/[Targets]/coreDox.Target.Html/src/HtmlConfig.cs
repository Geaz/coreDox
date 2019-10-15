using coreDox.Core.Contracts;
using coreDox.Core.Project.Common;

namespace coreDox.Target.Html
{
    public class HtmlConfig : IConfigSection
    {
        public void SetDefaultValues(DoxFileInfo configFileInfo)
        {
            ShowCode = false;
        }

        public bool ShowCode { get; set; }
    }
}
