public class Currency
{
    public double Value { get; set; }

    public Currency(double value)
    {
        Value = value;
    }
}

public class CurrencyUSD : Currency
{
    public CurrencyUSD(double value) : base(value) { }

    //Преобразование в EUR
    public static implicit operator CurrencyEUR(CurrencyUSD usd)
    {
        //Примерный курс 1 USD = 0.85 EUR
        return new CurrencyEUR(usd.Value * 0.85);
    }

    //Преобразование в RUB
    public static implicit operator CurrencyRUB(CurrencyUSD usd)
    {
        //Примерный курс 1 USD = 75 RUB
        return new CurrencyRUB(usd.Value * 75);
    }
}

public class CurrencyEUR : Currency
{
    public CurrencyEUR(double value) : base(value) { }

    //Преобразование в USD
    public static implicit operator CurrencyUSD(CurrencyEUR eur)
    {
        //Примерный курс 1 EUR = 1.18 USD
        return new CurrencyUSD(eur.Value * 1.18);
    }

    //Преобразование в RUB
    public static implicit operator CurrencyRUB(CurrencyEUR eur)
    {
        //Примерный курс 1 EUR = 88 RUB
        return new CurrencyRUB(eur.Value * 88);
    }
}

public class CurrencyRUB : Currency
{
    public CurrencyRUB(double value) : base(value) { }

    //Преобразование в USD
    public static implicit operator CurrencyUSD(CurrencyRUB rub)
    {
        //Примерный курс 1 RUB = 0.013 USD
        return new CurrencyUSD(rub.Value * 0.013);
    }

    //Преобразование в EUR
    public static implicit operator CurrencyEUR(CurrencyRUB rub)
    {
        //Примерный курс 1 RUB = 0.011 EUR
        return new CurrencyEUR(rub.Value * 0.011);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите сумму в USD:");
        double amountInUSD = Convert.ToDouble(Console.ReadLine());

        CurrencyUSD usd = new CurrencyUSD(amountInUSD);

        //Конвертация в EUR и RUB
        CurrencyEUR eur = usd; //Неявное преобразование в EUR
        CurrencyRUB rub = usd; //Неявное преобразование в RUB

        Console.WriteLine($"{amountInUSD} USD = {eur.Value} EUR");
        Console.WriteLine($"{amountInUSD} USD = {rub.Value} RUB");

        Console.WriteLine("Введите сумму в EUR:");
        double amountInEUR = Convert.ToDouble(Console.ReadLine());

        CurrencyEUR eur2 = new CurrencyEUR(amountInEUR);

        //Конвертация обратно в USD и RUB
        usd = eur2; //Неявное преобразование в USD
        rub = eur2; //Неявное преобразование в RUB

        Console.WriteLine($"{amountInEUR} EUR = {usd.Value} USD");
        Console.WriteLine($"{amountInEUR} EUR = {rub.Value} RUB");

        Console.WriteLine("Введите сумму в RUB:");
        double amountInRUB = Convert.ToDouble(Console.ReadLine());

        CurrencyRUB rub2 = new CurrencyRUB(amountInRUB);

        //Конвертация обратно в USD и EUR
        usd = rub2; //Неявное преобразование в USD
        eur2 = rub2; //Неявное преобразование в EUR

        Console.WriteLine($"{amountInRUB} RUB = {usd.Value} USD");
        Console.WriteLine($"{amountInRUB} RUB = {eur2.Value} EUR");
    }
}