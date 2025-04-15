using Gestionale.Models;
using System;
using System.Collections.Generic;

namespace Gestionale.Services
{
    public class UtenteService
    {
        private List<Utente> utenti = new List<Utente>();

        public void AggiungiUtente(int id, string nome, string email)
        {
            var nuovo = new Utente { Id = id, Nome = nome, Email = email };

            Console.WriteLine("\n====================================");
            Console.WriteLine("✅ Nuovo utente inserito correttamente!");
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"🆔 ID: {id}");
            Console.WriteLine($"👤 Nome: {nome}");
            Console.WriteLine($"📧 Email: {email}");
            Console.WriteLine("====================================\n");

            utenti.Add(nuovo);
        }

        public void StampaUtenti()
        {
            foreach (var u in utenti)
            {
                Console.WriteLine($"ID: {u.Id}, Nome: {u.Nome}, Email: {u.Email}");
            }
        }

        public List<Utente> GetUtenti()
        {
            return utenti;
        }

        public void Menu_Amministratore()
        {
            Console.WriteLine("=== GESTIONALE CLIENTI ===");
            Console.WriteLine("1. Aggiungi utente");
            Console.WriteLine("2. Elimina utente");
            Console.WriteLine("3. Modifica utente");
            Console.WriteLine("4. Visualizza utenti");
            Console.WriteLine("5. Esci");
            Console.WriteLine();
            Console.Write("Scegli un'opzione: ");
        }
    }
}