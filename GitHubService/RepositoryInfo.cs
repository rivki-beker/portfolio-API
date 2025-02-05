using Octokit;

namespace GitHubService
{
    public class RepositoryInfo
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Url { get; set; } = string.Empty;
        public int Stars { get; set; }
        public IEnumerable<RepositoryLanguage>? Languages { get; set; }
        public DateTimeOffset? LastCommit { get; set; }
        public int PullRequests { get; set; }
    }
}