using System;
using System.Text;

public class Plane
{
    private string brand;
    private string model;
    private int year;
    private double enginePower;
    private double flightDistance;

    public static int TotalPlaneCount { get; private set; } = 0;
    public static double TotalFlightDistance { get; private set; } = 0;

    public Plane(string brand, string model, int year, double enginePower, double flightDistance)
    {
        this.brand = brand;
        this.model = model;
        this.year = year;
        this.enginePower = enginePower;
        this.flightDistance = flightDistance;

        TotalPlaneCount++;
        TotalFlightDistance += flightDistance;
    }

    public Plane(string brand, string model, int year, double enginePower) : this(brand, model, year, enginePower, 0)
    {
    }

    public Plane(string brand, string model, int year) : this(brand, model, year, 0, 0)
    {
    }

    public void TakeOff()
    {
        Console.WriteLine($"{brand} {model} взлетает.");
    }

    public void Fly()
    {
        Console.WriteLine($"{brand} {model} летит.");
    }

    public void Land()
    {
        Console.WriteLine($"{brand} {model} приземляется.");
    }

    public string GetBrand()
    {
        return brand;
    }

    public string GetModel()
    {
        return model;
    }

    public int GetYear()
    {
        return year;
    }

    public double GetEnginePower()
    {
        return enginePower;
    }

    public double GetFlightDistance()
    {
        return flightDistance;
    }

    public void IncreaseFlightDistance(ref double distance)
    {
        flightDistance += distance;
        TotalFlightDistance += distance;
    }

    static Plane()
    {
        Console.WriteLine("Вызван статический конструктор.");
    }

    public void PrintPlaneInfo()
    {
        Console.WriteLine($"Бренд: {brand}");
        Console.WriteLine($"Модель: {model}");
        Console.WriteLine($"Год: {year}");
        Console.WriteLine($"Мощность двигателя: {enginePower} л.с.");
        Console.WriteLine($"Пройденное расстояние: {flightDistance} миль");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Plane plane1 = new Plane("Boeing", "747", 2018, 350, 2000);
        Plane plane2 = new Plane("Airbus", "A380", 2020, 400);

        plane1.TakeOff();
        plane1.Fly();
        double distance1 = 1500;
        plane1.IncreaseFlightDistance(ref distance1);
        plane1.Land();

        plane2.TakeOff();
        plane2.Fly();
        double distance2 = 1800;
        plane2.IncreaseFlightDistance(ref distance2);
        plane2.Land();

        Console.WriteLine($"Общее количество самолетов: {Plane.TotalPlaneCount}");
        Console.WriteLine($"Общее пройденное расстояние: {Plane.TotalFlightDistance} миль");

        plane1.PrintPlaneInfo();
        plane2.PrintPlaneInfo();

        Random random = new Random();
        string[] messages = { "Желаем приятного полета!", "Берегите себя!", "Всегда рады помочь!" };
        Console.WriteLine(messages[random.Next(messages.Length)]);

        Console.WriteLine($"Текущее время: {DateTime.Now}");
        Console.WriteLine("Программа завершила выполнение. Нажмите Enter для выхода.");
        Console.ReadLine(); 
    }
}
