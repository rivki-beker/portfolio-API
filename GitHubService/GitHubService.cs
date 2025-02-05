using Microsoft.Extensions.Options;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubService
{
    public class GitHubService : IGitHubService
    {
        private readonly GitHubClient _client;
        private readonly GitHubCredentials _credentials;

        public GitHubService(IOptions<GitHubCredentials> options)
        {
            _client = new GitHubClient(new ProductHeaderValue("my-app"));
            _credentials = options.Value;
            var cradToken = new Credentials(_credentials.Token);
            _client.Credentials = cradToken;
        }

        public async Task<IEnumerable<RepositoryInfo>> GetPortfolio()
        {
            var repositories = await _client.Repository.GetAllForCurrent();
            return await Task.WhenAll(repositories.Select(async repo => new RepositoryInfo
            {
                Name = repo.Name,
                Description = repo.Description,
                Url = repo.HtmlUrl,
                Stars = repo.StargazersCount,
                Languages = (await _client.Repository.GetAllLanguages(repo.Id)).ToList(),
                LastCommit = (await _client.Repository.Commit.GetAll(repo.Owner.Login, repo.Name))
                    .FirstOrDefault()?.Commit?.Committer?.Date,
                PullRequests = (await _client.PullRequest.GetAllForRepository(repo.Owner.Login, repo.Name)).Count
            }));
        }

        public async Task<IEnumerable<RepositoryInfo>> SearchRepositories(string? repositoryName, Language? language, string? userName)
        {
            var request = new SearchRepositoriesRequest(repositoryName)
            {
                Language = language,
                User = userName
            };

            var result = await _client.Search.SearchRepo(request);
            return await Task.WhenAll(result.Items.Select(async repo => new RepositoryInfo
            {
                Name = repo.Name,
                Description = repo.Description,
                Url = repo.HtmlUrl,
                Stars = repo.StargazersCount,
                Languages = (await _client.Repository.GetAllLanguages(repo.Id)).ToList(),
                LastCommit = repo.PushedAt
            }));
        }
        public async Task<bool> HadActive(DateTime lastUpdate)
        {
            var res = await _client.Activity.Events.GetAllUserPerformed(_credentials.UserName);
            return true;
        }

    }
}
