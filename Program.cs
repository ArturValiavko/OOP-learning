using System;
using System.Reflection.Metadata;

class Zmogus //Task4   
{
    public string Name { get; set; }
    public int Age { get; set; }


    public Zmogus(string name, int age)
    {
        Name = name;
        if (age < 0)
        {
            Console.WriteLine("amžius negali būti neigimas");
            age = 0;
        }
        Age = age;
    }
    public void Introduce()
    {
        if (Age != 0)
        {
            Console.WriteLine($"Sveiki, mano vardas {Name}, man yra {Age} metų");
           
        }
        else
        {
            Console.WriteLine($"Sveiki, mano vardas {Name}, amžius nenurodytas");
        }
    }
    public void ArPilnametis()
    {
        if (Age != 0)
        {
            if (Age < 18)
            {
                Console.WriteLine("Nepilnametis");
            }
            else { Console.WriteLine("Pilnametis"); }
        }
    }
}    
    


class Program
{
    static void Main()
    {
       List<Zmogus> zmones = new List<Zmogus>();
        {
            zmones.Add(new Zmogus("Artur", 29));
            zmones.Add(new Zmogus("Tomas", 30));
            zmones.Add(new Zmogus("Vaida", 26));
            zmones.Add(new Zmogus("Ignas", -10));
        }
        foreach (Zmogus z in zmones)
    {
            z.Introduce();
            z.ArPilnametis();
    }
    }
    

  }