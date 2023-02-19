using DomainDrivenDesign.List5_4.Interfaces;

namespace DomainDrivenDesign.List5_4;

public class UserRepositoryFactory : IUserRepositoryFactory
{
    public IUserRepository Create(string path, string table) => new UserRepository(path, table);
}