using DomainDrivenDesign.List4_4;

namespace DomainDrivenDesignUnitTest;

public class UnitTest4_4
{
    private string? _path;

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
    public void AddUser()
    {
        var user = new User(new UserName("garaph70"));
        var service = new UserService(_path!, "users");

        // 空のDBには追加できる
        Assert.That(service.Exists(user), Is.False);
        Assert.That(service.Insert(user), Is.True);

        // 同じオブジェクトは追加できない
        Assert.That(service.Exists(user), Is.True);
        Assert.That(service.Insert(user), Is.False);

        // 同じ名前も追加できない
        var user2 = new User(new UserName("garaph70"));
        Assert.That(service.Exists(user2), Is.True);
        Assert.That(service.Insert(user2), Is.False);
    }
}

