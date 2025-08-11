using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class Skaitiklis // Task15
{
    public static int skaicius = 0;
    public Skaitiklis()
    {
        skaicius++;
    }
    public static void Print()
    {
        Console.WriteLine(skaicius);
    }

}
class Gyvunas
{
    public static int gyvunai = 0;
    public Gyvunas()
    {
        gyvunai++;
    }
    public static void Print2()
    {
        Console.WriteLine($"Sukurta gyvūnų {gyvunai}");
    }
}
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
        int bendrasRaidziuKiekis1 = 0;
        int bendrasRaidziuKiekisSuS = 0;
        List<Produktas> produktai = new List<Produktas>
        {

        new Produktas("Obuolys"),
        new Produktas("Bananai"),
        new Produktas("Sviestas"),
        new Produktas("Sviestas 1")
        };

        Skaitiklis s1 = new Skaitiklis();
        Skaitiklis s2 = new Skaitiklis();
        Skaitiklis s3 = new Skaitiklis();

        Gyvunas x1 = new Gyvunas();
        Gyvunas x2 = new Gyvunas();
        Gyvunas x3 = new Gyvunas();

        foreach (var produktas in produktai)
        {
            produktas.SpauzdnitInfo();
            bendrasRaidziuKiekis1 += produktas.Pavadinimas.Length;
            if (produktas.Pavadinimas.StartsWith("S", StringComparison.OrdinalIgnoreCase))
            {
                bendrasRaidziuKiekisSuS += produktas.Pavadinimas.Length;
            }
        }
        Produktas.SpauzdnitBendraKieki();

        Console.Write("Skaitiklis: ");
        Skaitiklis.Print();
        Gyvunas.Print2();

        int bendrasRaidziuKiekis = produktai.Sum(p => p.Pavadinimas.Length);
        Console.WriteLine($"Bendras raidžių kiekis pavadinimuose(LINQ): {bendrasRaidziuKiekis}");
        Console.WriteLine($"Bendras raidžių kiekis pavadinimuose(foreach): {bendrasRaidziuKiekis1}");
        int bendrasRaidziuKiekisSuS_LINQ = produktai
            .Where(p => p.Pavadinimas.StartsWith("S", StringComparison.OrdinalIgnoreCase))
            .Sum(p => p.Pavadinimas.Length);
        Console.WriteLine($"Bendras raidžių kiekis pavadinimuose, kurie prasideda S: {bendrasRaidziuKiekisSuS_LINQ}");    
        Console.WriteLine($"Bendras raidžių kiekis pavadinimuose, kurie prasideda S: {bendrasRaidziuKiekisSuS}");
    }
}

