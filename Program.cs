using Gestionale.Models;
using Gestionale.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;



class Program
{
    static void Main()
    {
        var utenteService = new UtenteService();

        int eta = 0;

        //loop del programma
        while (eta != 5)
        {
            utenteService.Menu_Amministratore();
            switch (eta)
            {
                case 1:
                    Console.WriteLine("\n====================================");
                    Console.WriteLine("📝 INSERIMENTO NUOVO CLIENTE");
                    Console.WriteLine("====================================");
                    Console.WriteLine("Per favore, inserisci i seguenti dati:");
                    Console.WriteLine("➡️  ID (numero intero)");
                    Console.WriteLine("➡️  Nome completo (es. Mario Rossi)");
                    Console.WriteLine("➡️  Email (es. mario@email.it)");
                    Console.WriteLine("------------------------------------");
                    int id = int.Parse(Console.ReadLine());
                    string nome = Console.ReadLine();
                    string email = Console.ReadLine();
                    utenteService.AggiungiUtente(id, nome, email);
                    break;
                case 2:
                    Console.WriteLine("ciao2");
                    break;
                case 3:
                    Console.WriteLine("ciao3");
                    break;
                case 4:
                    Console.WriteLine("ciao4");
                    break;

            }
            eta = int.Parse(Console.ReadLine()!);
        }

        Console.WriteLine("=== GESTIONALE CLIENTI ===");

        utenteService.AggiungiUtente(1, "Mario Rossi", "mario@email.it");
        utenteService.AggiungiUtente(2, "Luca Bianchi", "luca@email.it");

        Console.WriteLine("\nLista clienti:");
        utenteService.StampaUtenti();
    }
}
