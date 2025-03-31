using MediatR;
using Todo.Core.Entities;
using Todo.Core.Interfaces;

namespace Todo.Application.Queries
{
    public record GetUserByIdQuery(Guid UserId) : IRequest<UserEntity>;
    public class GetUserByIdQueryHandler(IUserRepository userRepository) 
        : IRequestHandler<GetUserByIdQuery ,UserEntity>
    {
        public async Task<UserEntity> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetUserByIdAsync(request.UserId);
        }
    }
}
