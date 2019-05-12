using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleBlog.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace SampleBlog.Application.Posts.Queries.GetById
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, GetPostQueryModel>
    {
        private readonly SampleBlogDbContext _context;
        public GetPostQueryHandler(SampleBlogDbContext context)
        {
            _context = context;
        }
        public async Task<GetPostQueryModel> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == request.Id);
            var getPostQueryModel = new GetPostQueryModel
            {
                Post = post
            };

            return getPostQueryModel;
        }
    }
}
