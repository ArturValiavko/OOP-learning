using System;

class Zmogus //Task0
{
    public string Name = "";
    public int Age;

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
        Zmogus p1 = new Zmogus("Artur", 29);
        Zmogus p2 = new Zmogus("Tomas", 30);

        p1.Introduce();
        p2.Introduce();
        
    }

  }