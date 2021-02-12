using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Commands
{
    public class AddUserCommand: IRequest<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, long>
    {
        private readonly IApplicationDbContext _context;

        public AddUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User {FirstName = request.FirstName, LastName = request.LastName};
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
