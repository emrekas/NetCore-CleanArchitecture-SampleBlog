using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBlog.Application.Posts.Queries.GetById
{
    public class GetPostQuery:IRequest<GetPostQueryModel>
    {
        public int Id { get; set; }
    }
}
