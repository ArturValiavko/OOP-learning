using System;

class Zmogus //Task3   
{
    public string Name { get; set; }
    public int Age { get; set; }    

    public Zmogus(string name, int age)
    {
        Name = name;
        if (age < 0)
        {
            Console.WriteLine("am=ius negali būti neigimas");
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
        else {
            Console.WriteLine($"Sveiki, mano vardas {Name}, amžius nenurodytas");
        }
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