namespace DomainDrivenDesign.List5_4.Interfaces;

public interface IUserRepository
{
    public bool Exists(IUser user);
    public bool Save(IUser user);
    public IUser? Find(IUserName userName);
}