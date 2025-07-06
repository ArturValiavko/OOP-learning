using System;

class žmogus //Task0
{
    public string name = "";
    public int age;

    public void Introduce()
    {
        Console.WriteLine($"Sveiki, mano vardas {name}, man yra {age} metų");
     }
  }

class Programs
{
    static void Main()
    {
        žmogus persone1 = new žmogus();
        žmogus persone2 = new žmogus();
        persone1.name = "Artur";
        persone2.name = "Tomas";
        persone1.age = 29;
        persone2.age = 33;

        persone1.Introduce();
        persone2.Introduce();
    }

  }