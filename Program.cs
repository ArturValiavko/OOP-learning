using System;
using System.ComponentModel;
using System.IO.Pipes;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Linq;

class Zmogus //Task8.1
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Zmogus(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public string KoksAm()
    {
        if (Age == 0)
        {
            return $"Vardas{Name}, amžius Nenurodytas";
        }
        else
        {
            return $"Vardas{Name}, amžius yra {Age}";
        }
    }
 }


class Program
{
    static void Main()
    {
        List<Zmogus> zmones = new List<Zmogus>();

        while (true)
        {
            Console.Write("Įveks vardą:");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                break;
            }
            Console.Write("Įvesk amžių:");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Neteisingas amžius");
                age = 0;
            }
            zmones.Add(new Zmogus(name, age));

        }
        var filtr = zmones.Where(a => a.Age > 17).ToList();

        if (filtr.Count == 0)
        {
            Console.WriteLine("sarašė nėra 18+");
        }
        else
        { 
           foreach (Zmogus abc in filtr)
           {
                Console.WriteLine(abc.KoksAm());            
           }
        }
    }
    
}