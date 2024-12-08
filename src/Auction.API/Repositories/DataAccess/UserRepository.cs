using DotnetAuction.API.Contracts;
using DotnetAuction.API.Entities;

namespace DotnetAuction.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly DotnetAuctionDbContext _dbContext;

    public UserRepository(DotnetAuctionDbContext dbContext) => _dbContext = dbContext;

    public bool DoesExistUserWithEmail (string email)
    {
        return _dbContext.Users.Any(user => user.Email.Equals(email));
    }

    public User GetUserByEmail (string email) => _dbContext.Users.First(user => user.Email.Equals(email));
}
