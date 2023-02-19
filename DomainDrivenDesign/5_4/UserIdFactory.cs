using DomainDrivenDesign.List5_4.Interfaces;

namespace DomainDrivenDesign.List5_4;

public class UserIdFactory : IUserIdFactory
{
    public IUserId Create(string id) => new UserId(id);
}