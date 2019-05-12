using SampleBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBlog.Application.Posts.Queries.GetAll
{
    public class PostsViewModels
    {
        public List<Post> Posts { get; set; }
    }
}
