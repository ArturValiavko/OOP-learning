using System;
using System.Data;
using System.Dynamic;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


//task 17.3 events + lambdas

public class KiekioEventArgs : EventArgs
{
    public string Pavadinimas { get; }
    public int Kiekis { get; }
    public int Riba { get; }

    public KiekioEventArgs(string pavadinimas, int kiekis, int riba)
    {
        Pavadinimas = pavadinimas;
        Kiekis = kiekis;
        Riba = riba;

    }
 }
public class Sandelys
{
    public string Pavadinimas { get; }
    private Dictionary<string, int> produktai = new();
    private Dictionary<string, int> ribos = new();

    public event EventHandler<KiekioEventArgs>? KiekisNukritoZemiauRibos;

    public Sandelys(string pavadinimas)
    {
        Pavadinimas = pavadinimas;
    }

    public void PridetiProdukta(string pavadinimas, int kiekis, int riba)
    {
        produktai[pavadinimas] = kiekis;
        ribos[pavadinimas] = riba;
    }

    public void PridekKieki(string pavadinimas, int kiekis)
    {
        if (!produktai.ContainsKey(pavadinimas))
        {
            Console.WriteLine($"Produkas '{pavadinimas}' nerastas!");
            return;
        }

        produktai[pavadinimas] += kiekis;
        Console.WriteLine($"[Sandėlys] {pavadinimas}: {kiekis:+#;-#;0}, dabar {produktai[pavadinimas]}");

        if (produktai[pavadinimas] < ribos[pavadinimas])
        {
            KiekisNukritoZemiauRibos?.Invoke(
                this,
                new KiekioEventArgs(pavadinimas, produktai[pavadinimas], ribos[pavadinimas])
            );
        }
    }
}

class Program
{
    static void Main()
    {
        var Sandelys = new Sandelys("Centrinis");
        Sandelys.PridetiProdukta("Morka", 20, 10);
        Sandelys.PridetiProdukta("Bulvė", 15, 5);
        Sandelys.PridetiProdukta("Svogunas", 5, 5);

        Sandelys.KiekisNukritoZemiauRibos += (s, e) => Console.WriteLine($"įspėjimas: {e.Pavadinimas} ({e.Kiekis} vnt.) nukrito žemiau ribos {e.Riba}");
        Sandelys.KiekisNukritoZemiauRibos += (s, e) =>
        {
            if (e.Pavadinimas == "Morka")
            {
                Console.WriteLine($"[Specialus pranešimas] Morkų trūkumas! ({e.Kiekis} vnt.)");
            }
        };

        Sandelys.KiekisNukritoZemiauRibos += (s, e) =>
        {
            string logLine = $"{DateTime.Now}: {e.Pavadinimas} - kiekis {e.Kiekis}, riba {e.Riba}";
            Console.WriteLine("[LOG įrašas]" + logLine);
        };

        Sandelys.PridekKieki("Morka", -15);
        Sandelys.PridekKieki("Bulvė", -12);
        Sandelys.PridekKieki("Svogunas", -2);
    }   
}