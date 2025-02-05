using Octokit;

namespace Portfolio
{
    public class SearchParams
    {
        public string RepositoryName { get; set; } = "";
        public Language Language { get; set; } = Language.Verilog;
        public string UserName { get; set; } = "rivki-beker";
    }
}
