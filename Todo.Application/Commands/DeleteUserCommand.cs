using MediatR;
using Todo.Core.Interfaces;

namespace Todo.Application.Commands
{
    public record DeleteUserCommand(Guid UserId) 
        : IRequest<bool>;
    public class DeleteUserCommandHandler(IUserRepository userRepository)
        : IRequestHandler<DeleteUserCommand, bool>
    {
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.DeletUserAsync(request.UserId);
        }
    }
}
