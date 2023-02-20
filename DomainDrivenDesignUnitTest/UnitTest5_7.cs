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
        // テーブルの作成と１カラム追加
        using (var db = new DatabaseContext(_path!))
        {
            var rdc = db.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            Assert.That(rdc, Is.Not.Null);
            rdc.CreateTables();

            db.Add(new UserDataModel() { UserName = "garaoh70", UserId = $"{Guid.NewGuid()}" });
            db.SaveChanges();
        }

        // 追加されたかどうか確認
        using (var db = new DatabaseContext(_path!))
        {
            var count = db.Users.Count();
            Assert.That(count, Is.EqualTo(1));

            var model = db.Users.Single();
            Assert.That(model.UserName, Is.EqualTo("garaoh70"));
        }

        // 更新
        using (var db = new DatabaseContext(_path!))
        {
            var count = db.Users.Count();
            Assert.That(count, Is.EqualTo(1));

            var model = db.Users.Single();
            Assert.That(model.UserName, Is.EqualTo("garaoh70"));

            model.UserName = $"garaoh71";
            db.SaveChanges();
        }

        // 更新されたかどうか確認
        using (var db = new DatabaseContext(_path!))
        {
            var count = db.Users.Count();
            Assert.That(count, Is.EqualTo(1));

            var model = db.Users.Single();
            Assert.That(model.UserName, Is.EqualTo("garaoh71"));
        }

        // 更新をやめてみる
        using (var db = new DatabaseContext(_path!))
        {
            var count = db.Users.Count();
            Assert.That(count, Is.EqualTo(1));

            var model = db.Users.Single();
            model.UserName = $"garaoh72";
        }

        // 更新されていないか確認
        using (var db = new DatabaseContext(_path!))
        {
            var count = db.Users.Count();
            Assert.That(count, Is.EqualTo(1));

            var model = db.Users.Single();
            Assert.That(model.UserName, Is.EqualTo("garaoh71"));
        }

        // テーブルの多重作成は？
        using (var db = new DatabaseContext(_path!))
        {
            var rdc = db.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            Assert.That(rdc, Is.Not.Null);
            Assert.Throws<Microsoft.Data.Sqlite.SqliteException>(() => rdc.CreateTables());

            var count = db.Users.Count();
            Assert.That(count, Is.EqualTo(1));

            var model = db.Users.Single();
            Assert.That(model.UserName, Is.EqualTo("garaoh71"));
        }

        // ToDo: 悲観的排他制御、客観的排他制御を試す
        // テーブルの多重オープンは？
        using (var db = new DatabaseContext(_path!))
        {
            // 自分でトランザクションを開始
            using var transaction = db.Database.BeginTransaction();

            var count = db.Users.Count();
            Assert.That(count, Is.EqualTo(1));

            var model = db.Users.Single();
            Assert.That(model.UserName, Is.EqualTo("garaoh71"));

            model.UserName = "garaoh72";
            db.SaveChanges();

            using (var db2 = new DatabaseContext(_path!))
            {
                var count2 = db2.Users.Count();
                Assert.That(count2, Is.EqualTo(1));

                // 更新されていない
                var model2 = db2.Users.Single();
                Assert.That(model2.UserName, Is.EqualTo("garaoh71"));

                // 書き込みエラー、タイムアウト時間まで待っている
                model2.UserName = "garaoh75";
                Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateException>(() => db2.SaveChanges());
            }
        }
    }
}