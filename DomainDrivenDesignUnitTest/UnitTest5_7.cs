using DomainDrivenDesign.List5_7;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DomainDrivenDesignUnitTest;

public class UnitTest5_7
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
    public void EntityFramework()
    {
        using var db = new DatabaseContext(_path!);

        var rdc = db.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        Assert.That(rdc, Is.Not.Null);
        rdc.CreateTables();

        db.Add(new UserDataModel() { UserName = "Garaoh70", UserId = $"{Guid.NewGuid()}" });
        db.SaveChanges();

        var s = db.Users.FirstOrDefault();
        Assert.That(s, Is.Not.Null);
        Assert.That(s.UserName, Is.EqualTo("Garaoh70"));
    }
}