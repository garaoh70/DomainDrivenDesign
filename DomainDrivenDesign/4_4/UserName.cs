namespace DomainDrivenDesign.List4_4;

public record class UserName
{
    public string Value { get; init; }

    public UserName(string userName)
    {
        if (userName.Length < 3)
            throw new Exception("ユーザー名不正");
        Value = userName;
    }

    public override string ToString() => Value;
}