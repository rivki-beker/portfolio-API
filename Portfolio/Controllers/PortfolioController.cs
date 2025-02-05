using GitHubService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;

        public PortfolioController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        // GET api/<PortfolioController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepositoryInfo>>> GetPortfolio()
        {
            var res = await _gitHubService.GetPortfolio();
            return Ok(res);
        }

        // POST api/<PortfolioController>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<RepositoryInfo>>> SearchRepositories([FromBody] SearchParams searchParams)
        {
            var res = await _gitHubService.SearchRepositories(searchParams.RepositoryName, searchParams.Language, searchParams.UserName);
            return Ok(res);
        }
    }
}
