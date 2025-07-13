using System;
using System.ComponentModel;
using System.IO.Pipes;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Linq;

class Zmogus //Task8
{
    public string Name { get; set; }
    public int Age { get; set; }


    public Zmogus(string name, int age)
    {
        Name = name;
        if (age < 0)
        {
            Console.WriteLine("Amžius negali būti neigiamas");
            age = 0;
        }
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
            return $"Vardas {Name}, amžius yra {Age}";
        }


    }
}    

class Program
{
    static void Main()
    {
        List<Zmogus> zmones = new List <Zmogus>();
        
        while (true)
        {

            Console.Write("Įveskite vardą: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                break;
            }
            Console.Write("Įveskit amžių: ");
            int age;

            if (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Neteisingas amžius");
                age = 0;
            }
            //Zmogus zmogus = new Zmogus(name, age);
            zmones.Add(new Zmogus(name, age));

        }
        var filtruoti = zmones.Where(a => a.Age > 17).ToList();

        Console.WriteLine("\n--- Rezultatai ---\n");


        if (filtruoti.Count == 0)
        {
            Console.WriteLine("Sąraše nėra pilnamečių.");
        }
        else
        {
            foreach (Zmogus zmogus in filtruoti)
            {
                Console.WriteLine(zmogus.GetInfo());

            }
        }     
    }
    
}
    

  