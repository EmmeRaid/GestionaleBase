using Gestionale.Models;
using Gestionale.Services;
using System;
using System.Collections.Generic;



class Program
{
    static void Main()
    {
        var utenteService = new UtenteService();
        string SelezioneP;

        //loop del programma
        while ((int.Parse(SelezioneP) = Console.ReadLine()) != 5)
        {
            utenteService.Menu_Amministratore();            

        }

        Console.WriteLine("=== GESTIONALE CLIENTI ===");

        utenteService.AggiungiUtente(1, "Mario Rossi", "mario@email.it");
        utenteService.AggiungiUtente(2, "Luca Bianchi", "luca@email.it");

        Console.WriteLine("\nLista clienti:");
        utenteService.StampaUtenti();
    }
}
