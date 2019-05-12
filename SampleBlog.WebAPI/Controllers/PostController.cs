using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleBlog.Application.Posts.Commands;
using SampleBlog.Application.Posts.Queries.GetAll;
using SampleBlog.Application.Posts.Queries.GetById;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleBlog.WebAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    public class PostController : BaseController
    {
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
            var getPostsListQuery = new GetPostsListQuery();
            var posts = await Mediator.Send(getPostsListQuery);
            return Ok(posts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getPostQuery = new GetPostQuery { Id = id };
            var post = await Mediator.Send(getPostQuery);

            return Ok(post);
        }
    }
}
