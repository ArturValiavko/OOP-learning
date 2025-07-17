using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
/*
interface IGyvynas //Task14 pvz.  
{
    void SkleistiGarsa();
}
class Kate : IGyvynas
{
    public void SkleistiGarsa()
    {
        Console.WriteLine("Miau!");
    }
}
class Sunis : IGyvynas
{
    public void SkleistiGarsa()
    {
        Console.WriteLine("Au au!");
    }
}

class Program
{
    static void Main()
    {
        IGyvynas kate = new Kate();
        IGyvynas sunis = new Sunis();
        kate.SkleistiGarsa();
        sunis.SkleistiGarsa();

        List<IGyvynas> gyvunai = new List<IGyvynas> { new Kate(), new Sunis() };
        foreach (var g in gyvunai)
        {
            g.SkleistiGarsa();
        }
    }
}
*/

interface Mankšta // Task14
{
    void sportuoti();
    
}
class BICEP : Mankšta
{
    public void sportuoti()
    {
        Console.WriteLine("Bicep Curls");
    }
}
class Chest : Mankšta
{
    public void sportuoti()
    {
        Console.WriteLine("Push-ups");
    }
}

class Abs : Mankšta
{
    public void sportuoti()
    {
        Console.WriteLine("Plank");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine(DateTime.Today);
        Random random = new Random();
        List<Mankšta> pratimai = new List<Mankšta>();
        int RSkaicius = random.Next(1, 4);

        if (RSkaicius == 1)
        {
            pratimai.Add(new BICEP());
        }

        if (RSkaicius == 2)
        {
            pratimai.Add (new Chest());
        }

        if (RSkaicius == 3)
        {
            pratimai.Add(new Abs());
        }
        
        //List<Mankšta> pratimai = new List<Mankšta> { new BICEP(), new Chest(), new Abs() };
        foreach (var w in pratimai)
        {
            w.sportuoti();           
        }
    }
}