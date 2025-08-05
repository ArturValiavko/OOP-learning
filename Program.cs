using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text.Json;

public class Zmogus
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Zmogus(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age < 0 ? 0 : age;
    }
    public virtual string GetInfo()
    {
        return $"{Id} | {Name}, amžius {Age}";
    }
    public virtual void Print()
    {
        Console.WriteLine(GetInfo());
    }
}
public class Studentas : Zmogus
{
    public string Universitetas { get; set; }
    public Studentas(int id, string name, int age, string universitetas) : base(id, name, age)
    {
        Universitetas = universitetas;
    }
    public override string GetInfo()
    {
        return base.GetInfo() + $", universitetas: {Universitetas}";
    }


}

public interface IManksta
{
    void sportuoti();
}
public class Bicep : IManksta
{
    public void sportuoti()
    {
        Console.WriteLine("Atlikti bicep Cruls");
    }
}

public class Puchups : IManksta
{
    public void sportuoti()
    {
        Console.WriteLine("Atlikti Push-ups");
    }
}   
public class Plank : IManksta
{
    public void sportuoti()
    {
        Console.WriteLine("Atlikti plank");
    }
}

public static class FileHelper
{
    private static string Filepath = "zmones1.json";
    public static void SaveToFile(List<Zmogus> zmones)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };
        string json = JsonSerializer.Serialize(zmones, options);
        File.WriteAllText(Filepath, json);
    }


    public static List<Zmogus> LoadFromFile()
    {
        if (!File.Exists(Filepath))
            return new List<Zmogus>();
        string json = File.ReadAllText(Filepath);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        return JsonSerializer.Deserialize<List<Zmogus>>(json, options) ?? new List<Zmogus>();
    }
}

class Program
{
    static void Main()
    {
        List<Zmogus> zmones = FileHelper.LoadFromFile();
        int nextID = zmones.Any() ? zmones.Max(zmones => zmones.Id) + 1 : 1;


        while (true)
        {
            Console.WriteLine("\n--- Pagrindinis meniu ---");
            Console.WriteLine("1. Pridėti žmogų/studentą");
            Console.WriteLine("2. Redaguoti pagal ID");
            Console.WriteLine("3. Ištrinti pagal ID");
            Console.WriteLine("4. Rodyti visus");
            Console.WriteLine("5. Paskirti atsitiktinę mankštą žmogui pagal ID(-)");
            Console.WriteLine("0. Išeiti");
            Console.Write("Pasirinkti: ");
            string? choice = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(choice) || choice == "0")
                break;

            switch (choice)
            {
                case "1":
                    Console.Write("Ar studentas? (y/n)");
                    bool isStudent = Console.ReadLine()?.Trim().ToLower() == "y";

                    Console.Write("Vardas: ");
                    string name = Console.ReadLine() ?? "";

                    Console.Write("Amžius: ");
                    int age = int.TryParse(Console.ReadLine(), out var a) ? a : 0;


                    if (isStudent)
                    {
                        Console.Write("Universitetas");
                        string? universitetas = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(universitetas))
                        {
                            universitetas = "Nežinomas";
                        }
                        zmones.Add(new Studentas(nextID++, name, age, universitetas));
                    }
                    else
                    {
                        zmones.Add(new Zmogus(nextID++, name, age));
                    }
                    FileHelper.SaveToFile(zmones);
                    Console.WriteLine("įrašyta ir išsaugota");
                    break;

                case "2":
                    Console.WriteLine("\n-- Visas sąrašas --");
                    foreach (var z in zmones)
                        z.Print();
                    Console.Write("Įvesk ID kuri norėsi redaguoti: ");

                    if (int.TryParse(Console.ReadLine(), out int redagId))
                    {
                        var Zmogus = zmones.Find(z => z.Id == redagId);
                        if (Zmogus != null)
                        {
                            Console.Write("Naujas vardas (palik tuščią jei nekeičiame):");
                            string? newName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newName))
                                Zmogus.Name = newName;

                            Console.Write("Naujas amžius: ");
                            string? naujasamžius = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(naujasamžius))
                            {
                                if (int.TryParse(naujasamžius, out int newage))
                                    Zmogus.Age = newage < 0 ? 0 : newage;
                                else
                                    Console.WriteLine("Įvestas amžius buvo neteisingas, paliktas seans.");
                            }
                            if (Zmogus is Studentas studentas)
                            {
                                Console.Write("Naujas universitetas (palik tuščią jei nekeičiame)");
                                string? newUni = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(newUni))
                                    studentas.Universitetas = newUni;
                            }
                            FileHelper.SaveToFile(zmones);
                            Console.WriteLine("Duomenys atnaujinti ir išsaugoti.");
                        }
                        else
                        {
                            Console.WriteLine("Žmogus su tokiu ID nerastas.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Neteisingas ID formatas");
                    }
                    break;

                case "3":
                        Console.WriteLine("\n-- Visas sąrašas --");
                        foreach (var z in zmones)
                        z.Print();
                        Console.Write("Kurį ID norėsi ištrinti: ");

                    if (int.TryParse(Console.ReadLine(), out int salinimasId))
                    {
                        var Zmogus = zmones.Find(z => z.Id == salinimasId);
                        if (Zmogus != null)
                        {
                            zmones.Remove(Zmogus);
                            FileHelper.SaveToFile(zmones);
                            Console.WriteLine("Žmogus sekmingai ištrintas ir pakeitimai išsaugoti");
                        }
                        else
                        {
                            Console.WriteLine("Žmogus su tokiu ID nerastas");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Neteisingas ID formatas");
                    }
                break;



                case "4":
                    Console.WriteLine("\n-- Visas sąrašas --");
                        foreach (var z in zmones)
                        z.Print();
                break;

                case "5":
                    Console.WriteLine("Įveskite žmogaus ID, kuriam norite priskirti mankštą: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        var Zmogus = zmones.Find(zmones => zmones.Id == id);
                        if (Zmogus != null)
                        {
                            Random rnd = new Random();
                            List<IManksta> mankštos = new List<IManksta>
                            {
                                new Bicep(),
                                new Plank(),
                                new Puchups(),
                            };
                            var pasirinktaManksta = mankštos[rnd.Next(mankštos.Count)];
                            Console.Write("${Zmogus.Name} atlieka pratimą: ");
                            pasirinktaManksta.sportuoti();
                        }
                        else
                        {
                            Console.WriteLine("Žmogus nerastas");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Neteisingas ID formatas");
                    }
                break;


                default:
                Console.WriteLine("Šito pasirinkimo dar nėra įgivendinta ");
                break;
            }
        }
    }
}




