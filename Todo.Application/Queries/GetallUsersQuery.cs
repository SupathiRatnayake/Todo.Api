using MediatR;
using Todo.Core.Entities;
using Todo.Core.Interfaces;

namespace Todo.Application.Queries
{
    public record GetallUsersQuery() : IRequest<IEnumerable<UserEntity>>;

    public class GetallUsersQueryHandler(IUserRepository userRepository)
        : IRequestHandler<GetallUsersQuery, IEnumerable<UserEntity>>
    {
        public async Task<IEnumerable<UserEntity>> Handle(GetallUsersQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetUsers();
        }
    }

}
