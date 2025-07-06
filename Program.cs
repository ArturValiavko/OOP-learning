using System;
using System.Reflection.Metadata;

class Zmogus //Task3   
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
            arpilnametis();
        }
        else
        {
            Console.WriteLine($"Sveiki, mano vardas {Name}, amžius nenurodytas");
        }
    }
    public void arpilnametis()
    {

        if (Age < 18)
        {
            Console.WriteLine("Nepilnametis");
        }
        else { Console.WriteLine("Pilnametis"); }
    }
}    
    


class Programs
{
    static void Main()
    {
        Zmogus[] zmones = new Zmogus[]
        {
        new Zmogus("Artur", 29),
        new Zmogus("Tomas", 30),
        new Zmogus("Vaida", 26),
        new Zmogus("Ignas",-10)
        };
        foreach (Zmogus z in zmones)
    {
       z.Introduce();
    }
    }
    

  }