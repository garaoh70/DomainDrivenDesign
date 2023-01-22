using System;
namespace DomainDrivenDesign.List2_4
{
    // 通貨と量を扱うクラス
    public record class Money
    {
        public int Amount { get; init; }
        public string Currency { get; init; }

        public Money(int amount, string currency)
        {
            if (string.IsNullOrEmpty(currency))
                throw new ArgumentException($"単位なし");

            Amount = amount;
            Currency = currency;
        }

        public Money Add(Money money)
        {
            if (Currency != money.Currency)
                throw new ArgumentException($"通貨単位が異なっている");

            return this with { Amount = Amount + money.Amount, };
        }
    }

    // メモ：コンストラクタでプロパティを指定してしまうと入力チェックしにくい
    public record class Money2(int Amount, string Currency)
    {
        public Money2 Add(Money2 money)
        {
            if (Currency != money.Currency)
                throw new ArgumentException($"通貨単位が異なっている");

            return this with { Amount = Amount + money.Amount, };
        }
    }
}

