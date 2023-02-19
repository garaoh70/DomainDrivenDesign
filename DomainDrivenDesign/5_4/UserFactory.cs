using DomainDrivenDesign.List5_4.Interfaces;

namespace DomainDrivenDesign.List5_4;

public class UserFactory : IUserFactory
{
    public IUser Create(string userName) => new User(new UserName(userName));

    public IUser Create(string userName, string userId) => new User(new UserName(userName), new UserId(userId));
}