using DomainDrivenDesign.List5_4.Interfaces;

namespace DomainDrivenDesign.List5_4;

public class UserNameFactory : IUserNameFactory
{
    public IUserName Create(string name) => new UserName(name);
}