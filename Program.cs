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

public class Zmogus // Task 10 
{
    public string Name { get; set; }
    public string Sname { get; set; }
    public int Age { get; set; }
    public int Id { get; set; }
    public Zmogus(int id, string name, string sname, int age) // KONSTRUKTAS 
    {
        if (age <= 0)
        {
            age = 0;
        }
        Name = name;
        Sname = sname;
        Age = age;
        Id = id;  
        
        
    }
    public void Print() //Metodas 
    {
        if (Age == 0)
        {
            Console.WriteLine($" {Id} | Vardas -{Name}, pavardė -{Sname}, amžius nenurodytas");
        }
        else
        {
            Console.WriteLine($" {Id} | Vardas-{Name}, pavarde - {Sname}, amzius - {Age} ");  
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
                Console.WriteLine("Neteisingai įvestas amžius, priskiriamas 0.");
                age = 0;
            }
            abc.Add(new Zmogus(id, name, sname, age));
        }

        int sarašas = abc.Count();
        if (sarašas > 0)
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
                    break;
                }
            }

        
            double vidurkis = abc.Average(z => z.Age);
            Console.WriteLine($"Amžiaus vidurkis = {vidurkis:F1} \n Visas sarašas: ");

            var idmaxmin = abc.OrderByDescending(z => z.Id).ToList();
            Console.WriteLine("\n ID - max to min ");
             foreach (Zmogus z in idmaxmin)
            {

                z.Print();
            }

             Console.WriteLine("\n ID - min to max "); 
            foreach (Zmogus z in abc)
            { 
                z.Print();
            }
        }
        else
        {
            Console.WriteLine("Sarašas tuščias");
        }
        
        
    }
    
}