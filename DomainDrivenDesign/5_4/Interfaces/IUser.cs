namespace DomainDrivenDesign.List5_4.Interfaces;

public interface IUser
{
    public IUserName UserName { get; }
    public IUserId UserId { get; }
}