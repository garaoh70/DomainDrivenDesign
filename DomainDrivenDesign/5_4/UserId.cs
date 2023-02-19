using DomainDrivenDesign.List5_4.Interfaces;

namespace DomainDrivenDesign.List5_4;

public record class UserId : IUserId
{
    public string Id { get; init; }

    public UserId(string id)
    {
        if (string.IsNullOrEmpty(id))
            throw new Exception("ID不正");
        Id = id;
    }
}