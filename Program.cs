using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Microsoft.VisualBasic;

//Task16
public delegate string TekstoOperacija(string input);
public delegate string SkaiciuOperacija(int x, int y);
public delegate int SkaiciuSarašoOperacija(int input);

class Program
{
    static string IDidziasias(string s) => s?.ToUpper() ?? ""; //TekstoOperacija
    static string IMazosiomis(string s) => s?.ToLower() ?? "";
    static string Atbulai(string s)
    {
        if (string.IsNullOrEmpty(s)) return "";
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
    static List<string> Pritaikyti(List<string> šaltinis, TekstoOperacija op)
    {
        var rezultatas = new List<string>(šaltinis.Count);
        foreach (var e in šaltinis)
            rezultatas.Add(op(e));
        return rezultatas;
    }

    static string Sudetis(int a, int b) => $"{a}+{b}={a + b}"; //SkaiciuOperacija
    static string Atimti(int a, int b) => $"{a}-{b}={a - b}";
    static string Daugyba(int a, int b) =>$"{a}*{b}={a * b}";
    static string Dalyba(int a, int b) => b == 0 ? "Dalyba iš nulio negalima!" : $"{a}/{b}={(double)a / b}";

    static void Vykditioperacija(int x, int y, SkaiciuOperacija operacija)
    {
        Console.WriteLine(operacija(x, y));
    }

    static int Padvigubinti(int x) => x * 2; //skaiciuSarasoOperacija
    static int PakeltiKvadratu(int x) => x*x;
    static int Mod10(int x) => x % 10;
    static int beNeigiamu(int x) => Math.Abs(x);

    static List<int> PritaikytiSarasui(List<int> saltinis, SkaiciuSarašoOperacija op)
    {
        var res = new List<int>(saltinis.Count);
        foreach (var n in saltinis)
            res.Add(op(n));
        return res;
    }
    static int Agreguoti(List<int> saltinis, Func<int, int, int> op, int seed)
    {
        int acc = seed;
        foreach (var n in saltinis)
            acc = op(acc, n);
        return acc; 
    }


    static void Main()
    {
        var tekstai = new List<string> { "Labas", "Pasauli", "C#", "Delegatai" };

        var d1 = new TekstoOperacija(IDidziasias);
        var d2 = new TekstoOperacija(IMazosiomis);
        var d3 = new TekstoOperacija(Atbulai);

        // var A = Pritaikyti(tekstai, d1);
        var A = Pritaikyti(tekstai, IDidziasias);
        var B = Pritaikyti(tekstai, d2);
        var C = Pritaikyti(tekstai, d3);
        var BeBalsiu = Pritaikyti(tekstai, s => new string((s ?? "").ToCharArray().Where(ch => !"AEIOUĄĘĖĮYOUaeiouąęėįyou".Contains(ch)).ToArray()));

        Console.WriteLine("Didžiosiomis:    " + string.Join(", ", A));
        Console.WriteLine("Mažosiomis:      " + string.Join(", ", B));
        Console.WriteLine("Žodis Atbulai:   " + string.Join(", ", C));
        Console.WriteLine(":   " + string.Join(", ", BeBalsiu));


        int a = 10, b = 5; // negali būti 0

        var ops = new List<SkaiciuOperacija> { Sudetis, Atimti, Daugyba, Dalyba };
        foreach (var op in ops)
        {
            Vykditioperacija(a, b, op);
        }

        // SkaiciuOperacija op1 = Sudetis;
        // SkaiciuOperacija op2 = Atimti;
        // SkaiciuOperacija op3 = Daugyba;
        // SkaiciuOperacija op4 = Dalyba;

        // Vykditioperacija(a, b, op1);
        // Vykditioperacija(a, b, op2);
        // Vykditioperacija(a, b, op3);
        // Vykditioperacija(a, b, op4);

        //Vykditioperacija(a, b, (x, y) => $"{x}+{y}= {x + y}");

        var skaičiai = new List<int> { 1, 7, 8, -5, 54, 69, 15, 4654, -456, 12, 363, 415 };

        var x2 = PritaikytiSarasui(skaičiai, Padvigubinti);
        var kv = PritaikytiSarasui(skaičiai, PakeltiKvadratu);
        var m10 = PritaikytiSarasui(skaičiai, Mod10);
        var beminus = PritaikytiSarasui(skaičiai, beNeigiamu);
        //var beNeigiamu = PritaikytiSarasui(skaičiai, x => Math.Abs(x));

        int suma = Agreguoti(skaičiai, (acc, n) => acc + n, 0);
        int sandauga = Agreguoti(skaičiai, (acc, n) => acc * n, 1);
        //long sandauga = Agreguoti(skaičiai, (acc, n) => checked((int)checked((long)acc * n)), 1); // overflow.
        int max = Agreguoti(skaičiai, (acc, n) => Math.Max(acc, n), int.MinValue);

        Console.WriteLine("Visas sarašas: " + string.Join (", ", skaičiai)); 
        Console.WriteLine("x2:   " + string.Join(", ", x2));
        Console.WriteLine("^2:   " + string.Join(", ", kv));
        Console.WriteLine("%10:  " + string.Join(", ", m10));
        Console.WriteLine("|x|:  " + string.Join(", ", beminus));
        Console.WriteLine($"Suma: {suma}");
        Console.WriteLine($"Sandauga: {sandauga}");
        Console.WriteLine($"Max: {max}");
    }

}