using MediatR;
using SampleBlog.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SampleBlog.Domain.Entities;


namespace SampleBlog.Application.Comments.Commands.Create
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly SampleBlogDbContext _context;
        public CreateCommentCommandHandler(SampleBlogDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {

            var entity = new Comment
            {
                Author = request.Author,
                ContentText = request.ContentText,
                Email = request.Email,
                PostId = request.PostId,
                Status = request.Status
            };
            await _context.AddAsync(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;

        }
    }
}
