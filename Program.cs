using System;


//task 17 events 


public class TemperaturosDaviklis
{
    public event Action<int> TemperaturaPakyla;
    private int temperatura;

    public void NUstatytitemperatura(int nuajaTemp)
    {
        temperatura = nuajaTemp;
        Console.WriteLine($"Nustatyta temperatūra: {temperatura} °C");

        if (temperatura > 25)
        {
            TemperaturaPakyla?.Invoke(temperatura);
        }
    }

}

class Program
{
    static void Main()
    {
        TemperaturosDaviklis daviklis = new TemperaturosDaviklis();

        daviklis.TemperaturaPakyla += temp =>
        {
            Console.WriteLine($"Įspejimas: temperatūra per aukšta! ({temp}°C)");
        };
        daviklis.NUstatytitemperatura(20);
        daviklis.NUstatytitemperatura(21);
    }

}