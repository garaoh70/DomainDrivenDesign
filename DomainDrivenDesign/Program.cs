using System.Xml.Linq;

namespace DomainDrivenDesign;
class Program
{
    static void Main(string[] args)
    {
        var yen1 = new List2_4.Money(3000, "Yen");
        var yen2 = new List2_4.Money(3000, "Yen");
        var yen3 = new List2_4.Money(6000, "Yen");
        var yen4 = yen1.Add(yen2);
        Console.WriteLine($"yen1 eq yen2:{yen1 == yen2}");
        Console.WriteLine($"yen3 eq yen4:{yen3 == yen4}");


        Console.WriteLine("Hello, World!");
    }
}
