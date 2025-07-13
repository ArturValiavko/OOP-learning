using System;
using System.ComponentModel;
using System.Dynamic;
using System.IO.Pipes;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;


class Zmogus
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Zmogus(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public string GetInfo()
    {
        if (Age == 0)
        {
            return $"Vardas {Name}, amžius Nenurodytas";
        }
        else
        {
            return $"Vardas {Name}, amžius {Age}";
        }  
    }
}

class Program
{
    static void Main()
    {
        List<Zmogus> abc = new List<Zmogus>();

        while (true)
        {
            Console.Write("Įvesk vardą: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                break;
            }
            Console.Write("Įvesk amžių: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Neteisingas amžius");
                age = 0;
            }
            abc.Add(new Zmogus(name, age));
        }
        if (abc.Count == 0)
        {
            Console.WriteLine("Sąrašas tuščias");
            return;
        }
        var htol = abc = abc.OrderByDescending(a => a.Age).ToList();
        Console.WriteLine($"\n--- Rezultatai ---\n Vyraiusias žmogus:\n{htol[0].GetInfo()} \n\n Visas sarašas:");
        foreach (Zmogus a in abc)
        {
            Console.WriteLine(a.GetInfo());
        }
    }
}
