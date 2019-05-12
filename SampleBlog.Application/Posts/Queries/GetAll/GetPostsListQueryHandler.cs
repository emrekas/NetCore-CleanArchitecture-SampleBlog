using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleBlog.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace SampleBlog.Application.Posts.Queries.GetAll
{
    class GetPostsListQueryHandler : IRequestHandler<GetPostsListQuery, PostsViewModels>
    {
        private readonly SampleBlogDbContext _context;
        public GetPostsListQueryHandler(SampleBlogDbContext context)
        {
            _context = context;
        }
        public async Task<PostsViewModels> Handle(GetPostsListQuery request, CancellationToken cancellationToken)
        {
            var postsViewModels = new PostsViewModels { Posts = await _context.Posts.ToListAsync() };
            return postsViewModels;
        }
    }
}
