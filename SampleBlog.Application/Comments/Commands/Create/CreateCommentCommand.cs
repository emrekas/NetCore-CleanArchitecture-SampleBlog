using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBlog.Application.Comments.Commands.Create
{
    public class CreateCommentCommand : IRequest<int>
    {
        public string ContentText { get; set; }
        public int Status { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public int PostId { get; set; }
    }
}
