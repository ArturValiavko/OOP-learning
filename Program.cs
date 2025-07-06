using System;

class Zmogus //Task1
{
    public string Name { get; set; }
    public int Age { get; set; }    

    public Zmogus(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public void Introduce()
    {
        Console.WriteLine($"Sveiki, mano vardas {Name}, man yra {Age} metų");
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
        new Zmogus("Vaida", 26)
        };
        foreach (Zmogus z in zmones)
    {
       z.Introduce();
    }
    }
    

  }