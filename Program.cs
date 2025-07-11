using System;
using System.ComponentModel;
using System.IO.Pipes;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

class Zmogus //Task6
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
            return $"Mano vardas {Name}, amžius Nenurodytas";
        }
        else
        {
            return $"Mano vardas {Name}, man yra {Age} metų";
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
        Console.WriteLine("\n--- Rezultatai ---\n");
        foreach (Zmogus z in zmones)
        {
            Console.WriteLine(z.GetInfo());
        }
        
        }
    
    }
    

  