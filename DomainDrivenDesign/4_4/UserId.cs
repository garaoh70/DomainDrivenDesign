namespace DomainDrivenDesign.List4_4;

public record class UserId
{
    public string Value { get; init; }

    public UserId(string id)
    {
        if (string.IsNullOrEmpty(id))
            throw new Exception("ID不正");
        Value = id;
    }

    public override string ToString() => Value;
}