namespace DomainDrivenDesign.List5_4.Interfaces;

public interface IUserFactory
{
    public IUser Create(string userName);

    public IUser Create(string userName, string userId);
}