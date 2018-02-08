namespace coreDox.Core.Project.Common
{
    public sealed class DoxProjectValidationResult
    {
        private readonly string _path;
        private readonly string _errorMessage;

        public DoxProjectValidationResult(string path, bool valid, string errorMessage)
        {
            _path = path;
            _errorMessage = errorMessage;
            Valid = valid;
        }

        public override string ToString()
        {
            var appendix = !Valid ? $" [{_errorMessage}]" : string.Empty;
            return $"'{_path}' is {(Valid ? "VALID" : "NOT valid")}{appendix}!";
        }

        public bool Valid { get; }
    }
}
