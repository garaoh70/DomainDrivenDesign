namespace DomainDrivenDesign.List4_4;

public record class User
{
    public UserName UserName { get; init; }
    public UserId UserId { get; init; }

    public User(UserName userName)
    {
        UserName = userName;
        UserId = new(Guid.NewGuid().ToString());
    }
}