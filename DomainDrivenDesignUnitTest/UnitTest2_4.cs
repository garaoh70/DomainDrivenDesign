using DomainDrivenDesign.List2_4;

namespace DomainDrivenDesignUnitTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test24Money()
    {
        var yen3000 = new Money(3000, "Yen");
        var yen4500 = new Money(4500, "Yen");
        var yen6000 = new Money(6000, "Yen");
        var yen7500 = new Money(7500, "Yen");
        var usd1000 = new Money(1000, "Usd");

        // 単位なしは例外を出力
        Assert.Throws<ArgumentException>(() => new Money(1234, ""));

        // 異なる単位の加算は例外を出力
        Assert.Throws<ArgumentException>(() => yen3000.Add(usd1000));
        Assert.Throws<ArgumentException>(() => yen3000.Sub(usd1000));

        // 足し算のテスト
        Assert.That(yen3000 + yen4500, Is.EqualTo(yen7500));
        Assert.That(yen3000 + yen3000, Is.EqualTo(yen6000));

        // 引き算のテスト
        Assert.That(yen7500 - yen3000, Is.EqualTo(yen4500));
    }
}


