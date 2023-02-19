using DomainDrivenDesign.List5_4.Interfaces;

namespace DomainDrivenDesign.List5_4;

public record class UserName : IUserName
{
    public string Name { get; }

    public UserName(string userName)
    {
        if (userName.Length < 3)
            throw new Exception("ユーザー名不正");
        Name = userName;
    }
}