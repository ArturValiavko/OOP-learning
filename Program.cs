using System;
using System.Data;
using System.Dynamic;


//task 17 events 

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
    public int Kiekis { get; private set; }
    public int Riba { get; }

    public event EventHandler<KiekioEventArgs>? KiekisNukritoZemiauRibos;

    public Sandelys(string pavadinimas, int pradinisKiekis, int riba)
    {
        Pavadinimas = pavadinimas;
        Kiekis = pradinisKiekis;
        Riba = riba;
    }
    public void Paimk(int kiekis)
    {
        int buvo = Kiekis;
        Kiekis += kiekis;
        Console.WriteLine($"[Sandėlys] '{Pavadinimas}': {kiekis}, kiekis dabar {Kiekis} ");

        if (buvo >= Riba && Kiekis < Riba)
        {
            KiekisNukritoZemiauRibos?.Invoke(this, new KiekioEventArgs(Pavadinimas, Kiekis, Riba));
        }
    }
}
public static class Prenumeratoriai
{
    public static void IspetiKonsolėje(object? sender, KiekioEventArgs e)
    {
        Console.WriteLine($"ĮSPEJIMAS: '{e.Pavadinimas}' kiekis {e.Kiekis} < riba {e.Riba}");
    }
    public static void SiustiElLaiška(object? sender, KiekioEventArgs e)
    {
        Console.WriteLine($"[Email] Tema: Mažas kiekis - {e.Pavadinimas}. Kiekis: {e.Kiekis}.");
    }
}

class Program
{
    static void Main()
    {
        var morka = new Sandelys("Morka", pradinisKiekis: 15, riba: 15);
        var bulvė = new Sandelys("Bulvė", pradinisKiekis: 8, riba: 5);

        morka.KiekisNukritoZemiauRibos += Prenumeratoriai.IspetiKonsolėje;
        morka.KiekisNukritoZemiauRibos += Prenumeratoriai.SiustiElLaiška;

        bulvė.KiekisNukritoZemiauRibos += (s, e) =>
        Console.WriteLine($"LOG: {e.Pavadinimas} nukrito žemiau ribos ({e.Kiekis}/{e.Riba})");

        bulvė.KiekisNukritoZemiauRibos += Prenumeratoriai.IspetiKonsolėje;
        bulvė.KiekisNukritoZemiauRibos += Prenumeratoriai.SiustiElLaiška;

        morka.Paimk(-3);
        morka.Paimk(5);

        bulvė.Paimk(-5);
        bulvė.Paimk(3);

        morka.KiekisNukritoZemiauRibos -= Prenumeratoriai.SiustiElLaiška;
        morka.Paimk(1);
    }
}