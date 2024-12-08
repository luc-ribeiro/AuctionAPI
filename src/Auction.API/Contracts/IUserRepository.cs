using DotnetAuction.API.Entities;

namespace DotnetAuction.API.Contracts;

public interface IUserRepository
{
    bool DoesExistUserWithEmail(string email);

    User GetUserByEmail(string email);
}
