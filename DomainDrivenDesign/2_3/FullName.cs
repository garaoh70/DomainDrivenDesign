using System.Text.RegularExpressions;

namespace DomainDrivenDesign.List2_3
{
    // 氏名クラス
    public record class FirstName
    {
        public string Value { get; init; }

        // アルファベットに制限する
        public FirstName(string value)
        {
            if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                throw new ArgumentException("Format Error", nameof(Value));

            Value = value;
        }
    }

    // 名前クラス
    public record class LastName
    {
        public string Value { get; init; }

        // アルファベットに制限する
        public LastName(string value)
        {
            if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                throw new ArgumentException("Format Error", nameof(Value));

            Value = value;
        }
    }

    // 氏名クラス
    public record class FullName
    {
        public FirstName FirstName { get; init; }
        public LastName LastName { get; init; }

        public FullName(FirstName firstName, LastName lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}

