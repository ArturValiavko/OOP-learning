using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.IO.Pipes;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

public class Zmogus // Task 9.3
{
    public string Name { get; set; }
    public string Sname { get; set; }
    public int Age { get; set; }
    public int Id { get; set; }
    public Zmogus(int id, string name, string sname, int age) // KONSTRUKTAS 
    {
        Name = name;
        Sname = sname;
        Age = age < 0 ? 0: age;
        Id = id;  
        
        
    }
    public void Print() //Metodas 
    {
        if (Age == 0)
        {
            Console.WriteLine($" {Id} | Vardas - {Name}, pavardė - {Sname}, amžius nenurodytas");
        }
        else
        {
            Console.WriteLine($" {Id} | Vardas - {Name}, pavardė - {Sname}, amžius - {Age} ");  
        }
        
     } 

  }

class Program
{
    public static void Main() // METODAS
    {
        int id = 0;
        List<Zmogus> abc = new List<Zmogus>(); //abc tai sara6o pavadinimas kuriame yra  
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
            abc.Add(new Zmogus(id, name, sname, age));
        }

        while (true)
        {
            Console.WriteLine("SARAŠO VALDYMAS (Enter - išeiti) \n 1 - Surasti žmogu sarašė \n 2 - Vidutinis amžius sarašė \n 3 - Surūšiuota pagal ID MaxMin \n 4 - Surūšiuota pagal ID MinMAx \n 5 - Visas sąrašas: \n 6 - Ištrinti įrašą iš sarašo: \n 7 - Redaguoti įrašą pagal ID:  ");
            Console.Write("Pasirink skaičiu 1-6: ");
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
                        if (int.TryParse(Console.ReadLine(), out int IdRemuve))
                        {
                            var zmogusToDelete = abc.FirstOrDefault(z => z.Id == IdRemuve);
                            if (zmogusToDelete != null)
                            {
                                abc.Remove(zmogusToDelete);
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
                                    Console.WriteLine("Duomenis atnaujinti");
                                }
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