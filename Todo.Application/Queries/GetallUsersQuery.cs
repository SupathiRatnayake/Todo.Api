using MediatR;
using Todo.Core.Entities;
using Todo.Core.Interfaces;

namespace Todo.Application.Queries
{
    public record GetAllUsersQuery() : IRequest<IEnumerable<UserEntity>>;

    public class GetallUsersQueryHandler(IUserRepository userRepository)
        : IRequestHandler<GetAllUsersQuery, IEnumerable<UserEntity>>
    {
        public async Task<IEnumerable<UserEntity>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetUsers();
        }
    }

}
