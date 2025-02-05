using GitHubService;
using Microsoft.Extensions.Caching.Memory;
using Octokit;

namespace Portfolio.CacheService
{
    public class CacheGitHubService : IGitHubService
    {
        private readonly IGitHubService _gitHubService;
        private readonly IMemoryCache _memoryCache;

        private const string PortfolioKey = "PortfolioKey";

        public CacheGitHubService(IGitHubService gitHubService, IMemoryCache memoryCache)
        {
            _gitHubService = gitHubService;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<RepositoryInfo>> GetPortfolio()
        {
            if (_memoryCache.TryGetValue(PortfolioKey, out IEnumerable<RepositoryInfo> cacheRepos))
                return cacheRepos;

            var cachOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(30))
                .SetSlidingExpiration(TimeSpan.FromSeconds(10));

            var portfolio = await _gitHubService.GetPortfolio();

            _memoryCache.Set(PortfolioKey, portfolio, cachOptions);
            return portfolio;
        }

        public async Task<IEnumerable<RepositoryInfo>> SearchRepositories(string? repositoryName, Language? language, string? userName)
        {
            return await _gitHubService.SearchRepositories(repositoryName, language, userName);
        }

        public async Task<bool> HadActive(DateTime lastUpdate)
        {
            return await _gitHubService.HadActive(lastUpdate);
        }
    }
}
