using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubService
{
    public interface IGitHubService
    {
        public Task<IEnumerable<RepositoryInfo>> GetPortfolio();
        public Task<IEnumerable<RepositoryInfo>> SearchRepositories(string? repositoryName, Language? language, string? userName);
        public Task<bool> HadActive(DateTime lastUpdate);
    }
}
