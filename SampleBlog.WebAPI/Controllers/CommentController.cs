using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleBlog.Application.Comments.Commands.Create;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleBlog.WebAPI.Controllers
{
    public class CommentController : BaseController
    {
        // GET: api/<controller>
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Post(CreateCommentCommand createCommentCommand)
        {
            var response = await Mediator.Send(createCommentCommand);
            return Ok(response);
        }
    }
}
