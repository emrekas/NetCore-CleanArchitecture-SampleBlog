using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using SampleBlog.Application.Posts.Commands.Create;
using SampleBlog.Application.Posts.Queries.GetAll;
using SampleBlog.Application.Posts.Queries.GetById;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleBlog.WebAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    public class PostController : BaseController
    {
        private readonly IDistributedCache _distributedCache;
        public PostController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        // GET: /<controller>/
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreatePostCommand createPostCommand)
        {
            await Mediator.Send(createPostCommand);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cacheKey = "TheTime";
            var existingTime = _distributedCache.GetString(cacheKey);
            string cacheData;

            if (!string.IsNullOrEmpty(existingTime))
            {
                cacheData = "Fetched from cache : " + existingTime;
            }
            else
            {
                existingTime = DateTime.UtcNow.ToString();
                _distributedCache.SetString(cacheKey, existingTime);
                cacheData = "Added to cache : " + existingTime;
            }

            var getPostsListQuery = new GetPostsListQuery();
            var posts = await Mediator.Send(getPostsListQuery);

            var anyModel = new
            {
                cacheData = cacheData,
                posts = posts
            };

            return Ok(anyModel);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery]int id)
        {
            var getPostQuery = new GetPostQuery { Id = id };
            var post = await Mediator.Send(getPostQuery);

            return Ok(post);
        }
    }
}
