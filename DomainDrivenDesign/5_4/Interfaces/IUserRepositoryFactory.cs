namespace DomainDrivenDesign.List5_4.Interfaces;

public interface IUserRepositoryFactory
{
    public IUserRepository Create(string path, string table);
}