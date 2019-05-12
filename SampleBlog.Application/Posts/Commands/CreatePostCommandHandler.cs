using MediatR;
using SampleBlog.Domain.Entities;
using SampleBlog.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleBlog.Application.Posts.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly SampleBlogDbContext _context;
        public CreatePostCommandHandler(SampleBlogDbContext sampleBlogDbContext)
        {
            _context = sampleBlogDbContext;
        }

        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Post
                {
                    ContentText = request.ContentText,
                    Title = request.Title,
                    CreatedDate = DateTime.Now,
                    Status = request.Status,
                    UserId=1
                    //TagPosts = request.TagPosts
                };
                _context.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                return entity.Id;

            }
            catch (Exception e)
            {
                var a = e.Message;
                throw;
            }


        }
    }
}
