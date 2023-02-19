using DomainDrivenDesign.List5_4;
using DomainDrivenDesign.List5_4.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesignUnitTest;

public class UnitTest5_4
{
    private string? _path = null;

    [SetUp]
    public void Setup()
    {
        _path = Path.GetTempFileName();
    }

    [TearDown]
    public void TearDown()
    {
        if (!string.IsNullOrEmpty(_path))
        {
            try
            {
                File.Delete(_path);
                _path = null;
            }
            catch
            {
            }
        }
    }

    [Test]
    public void DI()
    {
        var di = DependencyInjection.Services;

        var repository = di.GetService<IUserRepositoryFactory>()?.Create(_path!, "users");
        Assert.That(repository, Is.Not.Null);

        var user1 = di.GetService<IUserFactory>()?.Create("Garaoh70");
        Assert.That(user1, Is.Not.Null);

        // 空のDBには追加できる
        Assert.That(repository.Exists(user1), Is.False);
        Assert.That(repository.Save(user1), Is.True);

        // 同じオブジェクトは追加できない
        Assert.That(repository.Exists(user1), Is.True);
        Assert.That(repository.Save(user1), Is.False);

        // 同じ名前も追加できない
        var user2 = di.GetService<IUserFactory>()?.Create("Garaoh70");
        Assert.That(user2, Is.Not.Null);
        Assert.That(repository.Exists(user2), Is.True);
        Assert.That(repository.Save(user2), Is.False);
    }
}

