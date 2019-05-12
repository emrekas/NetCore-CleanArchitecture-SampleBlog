using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBlog.Application.Posts.Queries.GetAll
{
    public class GetPostsListQuery : IRequest<PostsViewModels>
    {
    }
}
