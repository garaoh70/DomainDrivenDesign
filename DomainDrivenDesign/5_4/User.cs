using DomainDrivenDesign.List5_4.Interfaces;

namespace DomainDrivenDesign.List5_4;

public record class User : IUser
{
    public IUserName UserName { get; init; }
    public IUserId UserId { get; init; }

    public User(IUserName userName)
    {
        UserName = userName;
        UserId = new UserId(Guid.NewGuid().ToString());
    }

    public User(IUserName userName, IUserId userId)
    {
        UserName = userName;
        UserId = userId;
    }
}