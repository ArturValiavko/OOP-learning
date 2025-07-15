using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public static class FileHelper
{
    private static string Filepath = "duomenys.json";
    public static void SaveToFile(List<Zmogus> zmones)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(zmones, options);
        File.WriteAllText(Filepath, json);
    }

    public static List<Zmogus> LoadFromFile()
    {
        if (!File.Exists(Filepath))
        {
            return new List<Zmogus>();
        }
        string json = File.ReadAllText(Filepath);
        return JsonSerializer.Deserialize<List<Zmogus>>(json);
    }

}
public class Zmogus // Task 13
{
    public string Name { get; set; }
    public string Sname { get; set; }
    public int Age { get; set; }
    public int Id { get; set; }

    public Zmogus(int id, string name, string sname, int age) // KONSTRUKTAS 
    {
        Name = name;
        Sname = sname;
        Age = age < 0 ? 0 : age;
        Id = id;


    }

    protected virtual string GetInfo() //Metodas 1 
    {
        if (Age == 0)
        {
            return $" {Id} | Vardas - {Name}, pavardė - {Sname}, amžius nenurodytas";
        }
        else
        {
            return $" {Id} | Vardas - {Name}, pavardė - {Sname}, amžius - {Age}";
        }

    }

    public virtual void Print()
    {
        Console.WriteLine(GetInfo());
    }
}

public class Studentas : Zmogus
{
    public string Universitetas { get; set; }

    public Studentas(int id, string name, string sname, int age, string universitetas)// KONSTRUKTAS  2
    : base(id, name, sname, age)
    {
        Universitetas = universitetas;
    }
    protected override string GetInfo() //Metodas 2
    {
        string baseInfo = base.GetInfo();
        if (Age != 0)
        {
            baseInfo += $", universitetas - {Universitetas}";
        }
        return baseInfo;
    }
}

class Program
{
    public static void Main() // METODAS
    {
        List<Zmogus> abc = FileHelper.LoadFromFile();//abc tai sara6o pavadinimas kuriame yra  
        int id = abc.Count > 0 ? abc.Max(z => z.Id) : 0;
        while (true)
        {

            id++;
            Console.Write("Įvesk vardą: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                break;
            }

            Console.Write("Įvesk pavardę: ");
            string? sname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(sname))
            {
                sname = "Nėra";
            }
            Console.Write("Amžių: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Neteisingai įvestas amžius, priskiriamas 0");
                age = 0;
            }
            Console.WriteLine("Ar įvestas žmogus studentas?(y/n)");
            string? arstud = Console.ReadLine();
            bool yrastud = arstud != null && arstud.Trim().ToLower() == "y";

            if (yrastud)
            {
                Console.Write("Įvesk universiteto pavadinimą: ");
                string? universitetas = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(universitetas))
                {
                    universitetas = "Nežinomas";
                }
                abc.Add(new Studentas(id, name, sname, age, universitetas));
            }
            else
            {
                abc.Add(new Zmogus(id, name, sname, age));

            }
            FileHelper.SaveToFile(abc);
        }

        while (true)
        {
            Console.WriteLine("SARAŠO VALDYMAS  \n 1 - Surasti žmogu sarašė \n 2 - Vidutinis amžius sarašė \n 3 - Surūšiuota pagal ID MaxMin \n 4 - Surūšiuota pagal ID MinMAx \n 5 - Visas sąrašas: \n 6 - Ištrinti įrašą iš sarašo: \n 7 - Redaguoti įrašą pagal ID:  ");
            Console.Write("Pasirink skaičiu 1-7: (Enter - išeiti) ");
            if (int.TryParse(Console.ReadLine(), out int pasirinkimas))
            {
                switch (pasirinkimas)
                {
                    case 1:
                        if (abc.Count > 0)
                        {
                            while (true)
                            {
                                Console.Write("\n Kokio žmogaus ieškote?: (Enter to skip) ");
                                string? ieskomasVardas = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(ieskomasVardas))
                                {
                                    break;
                                }
                                var rasti = abc.Where(z => z.Name.Equals(ieskomasVardas, StringComparison.OrdinalIgnoreCase)).ToList();
                                if (rasti.Count > 0)
                                {
                                    foreach (Zmogus a in rasti)
                                    {
                                        a.Print();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Tokio žmogaus nėra \n");
                                    continue;
                                }

                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sarašas tuščias");
                        }
                        break;


                    case 2:
                        double vidurkis = abc.Average(z => z.Age);
                        Console.WriteLine($"Amžiaus vidurkis = {vidurkis:F1} \n Visas sarašas: ");

                        break;

                    case 3:

                        var idmaxmin = abc.OrderByDescending(z => z.Id).ToList();
                        Console.WriteLine("\n ID - max to min ");
                        foreach (Zmogus z in idmaxmin)
                        {
                            z.Print();
                        }

                        break;
                    case 4:

                        var idminmax = abc.OrderBy(z => z.Id).ToList();
                        Console.WriteLine("\n ID - min to max ");
                        foreach (Zmogus z in idminmax)
                        {
                            z.Print();
                        }

                        break;

                    case 5:

                        Console.WriteLine("\n Visas sąrašas  ");
                        foreach (Zmogus z in abc)
                        {
                            z.Print();
                        }
                        break;

                    case 6:

                        Console.WriteLine("Įvesk ID kuri nori pašalinti");
                        if (int.TryParse(Console.ReadLine(), out int IdRemove))
                        {
                            var zmogusToDelete = abc.FirstOrDefault(z => z.Id == IdRemove);
                            if (zmogusToDelete != null)
                            {
                                abc.Remove(zmogusToDelete);
                                FileHelper.SaveToFile(abc);
                                Console.WriteLine("Žmogus ištrintas");
                            }
                            else
                            {
                                Console.WriteLine("ID nerastas");
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Tokio ID sąraše nėra");
                        }
                        break;

                    case 7:

                        Console.WriteLine("Įvesk ID kuri nori readaguoti");
                        if (int.TryParse(Console.ReadLine(), out int Idredagavimas))
                        {
                            var zmogusRedaguoti = abc.Find(z => z.Id == Idredagavimas);
                            if (zmogusRedaguoti != null)
                            {
                                Console.Write("Įvesk Nauja Vardą: ");
                                string? name = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(name))
                                {
                                    zmogusRedaguoti.Name = name;
                                    
                                }
                                Console.Write("Įvesk Nauja Pavardę: ");

                                string? sname = Console.ReadLine();

                                if (!string.IsNullOrWhiteSpace(sname))
                                {
                                    zmogusRedaguoti.Sname = sname;
                                }

                                Console.Write("Įvesk Naują Amžių: ");
                                string? ageInput = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(ageInput))
                                {

                                    if (!int.TryParse(ageInput, out int age))
                                    {
                                        Console.WriteLine("Neteisingai įvestas amžius, priskiriamas 0");
                                        age = 0;
                                    }
                                    zmogusRedaguoti.Age = age;
                                    
                                }
                                if (zmogusRedaguoti is Studentas studentas)
                                {
                                    Console.Write("Įvesk Naują universiteto pavadinimą: ");
                                    string? universitetas = Console.ReadLine();
                                    if (!string.IsNullOrWhiteSpace(universitetas))
                                    {
                                        studentas.Universitetas = universitetas;
                                    }
                                }
                                Console.WriteLine("Duomenis atnaujinti");
                                FileHelper.SaveToFile(abc);
                            }
                            else
                            {
                                Console.WriteLine("Tokio ID sąraše nėra");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Neteisingas ID formatas");
                        }

                        break;

                    default:

                        Console.WriteLine("Nebuvo pasirinktas sakičius");
                        break;
                }


            }
            else
            {
                break;
            }

        }


    }
}