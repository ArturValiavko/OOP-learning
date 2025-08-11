using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

//task 15
class Produktas
{
    public static int sekantisID = 1;
    public int Id;
    public static int skaicius = 0;
    public string Pavadinimas;

    public Produktas(String pavadinimas)
    {
        Id = sekantisID;
        Pavadinimas = pavadinimas;

        sekantisID++;
        skaicius++;

    }
    public void SpauzdnitInfo()
    {
        Console.WriteLine($"ID: {Id},Pavadinimas: {Pavadinimas}");
       
    }
    public static void SpauzdnitBendraKieki()
    { 
        Console.WriteLine($"Iš viso produktų: {skaicius}");
    }

}

class Program
{
    static void Main()
    {
        List<Produktas> produktai = new List<Produktas>
        {

        new Produktas("Obuolys"),
        new Produktas("Bananai"),
        new Produktas("Sviestas"),
        new Produktas("Sviestas1")
        };


        Console.Write("Įvekite pirmają raidę filtravimui: ");
        string? raide = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(raide))
        {
            var produktaiPagalRaide = produktai
          .Where(p => p.Pavadinimas.StartsWith(raide, StringComparison.OrdinalIgnoreCase))
          .Select(p => new
          {
              Pavadinimas = p.Pavadinimas,
              raidziuKiekis = p.Pavadinimas.Length
          })
          .ToList();

            if (produktaiPagalRaide.Count > 0)
            {
                Console.WriteLine($"Produktai, kurie prasideda raide '{raide}' :");
                foreach (var p in produktaiPagalRaide)
                {
                    Console.WriteLine($"-{p.Pavadinimas}({p.raidziuKiekis} raidės)");
                }
                int bendrasRaidziuKiekis = produktaiPagalRaide.Sum(p => p.raidziuKiekis);
                Console.WriteLine($"\nBendras riadžių kiekis: {bendrasRaidziuKiekis}");
            }
            else
            {
                Console.WriteLine($"\n Produktų, prasidedančių su raide '{raide}', nearasta.");
            }
        } 
        else
        {
            Console.WriteLine($"\nNeivesta jokia raidė '{raide}'");
        }
      


        //  var produktaiSuB = produktai
        //     .Where(p => p.Pavadinimas.StartsWith("B", StringComparison.OrdinalIgnoreCase))
        //     .Select(p => new
        //     {
        //         Pavadinimas = p.Pavadinimas,
        //         raidziuKiekis1 = p.Pavadinimas.Length
        //     })
        //     .ToList();
        // Console.WriteLine("produktai, kurie prasideda raide B:");
        // foreach (var p in produktaiPagalRaide)
        // {
        //     Console.WriteLine($"-{p.Pavadinimas}({p.raidziuKiekis} raidės)");
        // }
        // int bendrasRaidziuKiekis1 = produktaiPagalRaide.Sum(p => p.raidziuKiekis);
        // Console.WriteLine($"\nBendras riadžių kiekis: {bendrasRaidziuKiekis1}");
    }
}

