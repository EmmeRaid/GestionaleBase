using System.Runtime.InteropServices;
using Gestionale.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Gestionale.Services
{
    public class UtenteService
    {

        public void StampaLogo()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(@"
   ____           _        _             _       
  / ___| ___   __| | ___  | | ___   __ _(_)_ __  
 | |  _ / _ \ / _` |/ _ \ | |/ _ \ / _` | | '_ \ 
 | |_| | (_) | (_| |  __/ | | (_) | (_| | | | | |
  \____|\___/ \__,_|\___| |_|\___/ \__, |_|_| |_|
                                   |___/         

            ╔═══════════════════════════╗
            ║       By. EmmeRaid        ║
            ╚═══════════════════════════╝
");
        }
        //INIZIALIZZAZIONE DELLA LISTA, IN MODO CHE POSSA ESSERE UTILIZZATA E RIEMPITA
        private List<Utente> utenti = new List<Utente>();

        //SEMPLICE FUNZIONE PER AGGIUNGERE I RELATIVI UTENTI ALL'INTERNO DELLA LISTA
        public void AggiungiUtente()
        {
            bool lettura = false;
            bool elimino = false;
            bool cambio = false;
            //LEGGO DA TEMRMINALE I DATI PER INSERIRLI ALL'INTERNO DELLA LISTA UTENTI
            Console.WriteLine("➡️  ID (numero intero)");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("➡️  Nome completo (es. Mario Rossi)");
            string? nome = Console.ReadLine();
            Console.WriteLine("➡️  Email (es. mario@email.it)");
            string? email = Console.ReadLine();

            var nuovo = new Utente { Id = id, Nome = nome, Email = email };

            //CONTROLLO SE L'UTENTE è GIA STATO SALVATO CON LO STESSO ID
            if (TrovaUtente(nuovo.Id, cambio, elimino, lettura) == 1)
            {
                Console.WriteLine("❌Mi dispiace l'utente inserito non può essere salvato, l'ID selezionato è gia esistente.");
            }
            else
            {
                Console.WriteLine("\n====================================");
                Console.WriteLine("✅ Nuovo utente inserito correttamente!");
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"🆔 ID: {id}");
                Console.WriteLine($"👤 Nome: {nome}");
                Console.WriteLine($"📧 Email: {email}");
                Console.WriteLine("====================================\n");
                utenti.Add(nuovo);
            }

        }


        /*
        FUNZIONE PER AGGIORNARE ALL'AVVIO DEL PROGRAMMA LA LISTA CON IL FILE JSON 
        CHE SUCCESSIVAMENTE VERRà AGGIORNATO CON ALTRI DATI DURANTE L'ESECUZIONE DEL PROGRAMMMA  
        */
        public void aggiorna()
        {
            string filePath = Path.Combine("saves", "Salvati.json");

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);

                utenti = JsonSerializer.Deserialize<List<Utente>>(json);

                Console.WriteLine("✅Lista utenti caricata con successo:");
            }
            else
            {
                Console.WriteLine($"File non trovato: {filePath}");
            }
        }


        //QUESTA FUNZIONE HA DUE POSSIBILE STRADE IN BASE AL VALORE BOOLEANO ASSEGNATO ALL'INTERNO DEL MAIN
        public int TrovaUtente(int id, bool cambio, bool elimino, bool lettura)
        {
            var utenteTrovato = utenti.FirstOrDefault(u => u.Id == id);


            if (utenteTrovato != null)
            {
                //IF PER CAMBIARE LE INFORMAZIONI DELL'UTENTE TROVATO
                if (cambio == true && elimino == false)
                {
                    modificaUtente(utenteTrovato);
                    return 3;
                }
                //QUESTA PARTE PER ELIMINARE IL CLIENTE TROVATO
                else if (cambio == false && elimino == true)
                {
                    EliminaUtente(utenteTrovato);
                    return 4;
                }
                //QUESTO SEMPLICEMENTE PER METTERLO A SCHERMO, UNA LOGICA DA RIVEDERE ALLE VOLTE POTREBBE NON FUNZIONARE
                else if ((cambio || elimino) == false && lettura == true)
                {
                    Console.WriteLine("== UTENTE TROVATO CON SUCCESSO! ==");
                    Console.WriteLine($"ID: {utenteTrovato.Id}, Nome: {utenteTrovato.Nome}, Email: {utenteTrovato.Email}");
                }
                else if (cambio == false && elimino == false)
                {
                    return 1;
                }


            }
            else
            {
                Console.WriteLine("== UTENTE NON TROVATO! ==");
            }
            elimino = false;
            cambio = false;
            return 0;
        }

        //FUNZIONE PER MODIFICARE I VALORI INTERNI DELL'UTENTE,PENSARE AD UN FUTURO AGGIORNAMENTO CON LA MODIFICA DETTAGLIATA IN BASE A COSA VUOI MODIFICARE
        public void modificaUtente(Utente utente)
        {
            Console.WriteLine("Siamo pronti per cambiare l'utente");
            Console.WriteLine("➡️  ID (numero intero)");
            int nuovoId = int.Parse(Console.ReadLine());
            Console.WriteLine("➡️  Nome completo (es. Mario Rossi)");
            string? nuovoNome = Console.ReadLine();
            Console.WriteLine("➡️  Email (es. mario@email.it)");
            string? nuovoEmail = Console.ReadLine();
            utente.Id = nuovoId;
            utente.Nome = nuovoNome;
            utente.Email = nuovoEmail;
        }

        //FUNZIONE BASE PER ELIMINARE L'UTENTE DELLA LISTA INVIATO ALLA FUNZIONE
        public void EliminaUtente(Utente utente)
        {
            if (utenti.Remove(utente))
            {
                Console.WriteLine($"✅ Utente con ID {utente.Id} eliminato con successo!");
            }
            else
            {
                // Questo caso è improbabile se utenteTrovato non è null all'inizio della funzione,
                // ma è una buona pratica includerlo per eventuali problemi di concorrenza o logica.
                Console.WriteLine($"❌ Errore: Impossibile eliminare l'utente con ID {utente.Id}.");
            }
        }

        //QUESTA FUNZIONE ANALIZZA LA STRUTTURA DELLA LISTA. SE È VUOTA NON CI DA VALORI ALTRIMENTI STAMPA A SCHERMO TUTTE LE INFORMAZIONI DEI VARI UTENTI
        public void StampaUtenti()
        {
            Console.WriteLine("\n📋 Lista clienti:\n");

            if (utenti != null && utenti.Count > 0)
            {
                int count = 0;

                // Stampa l'intestazione della tabella
                Console.WriteLine($"{"🆔 ID",-6} {"👤 Nome",-20} {"📧 Email",-30}   |   {"🆔 ID",-6} {"👤 Nome",-20} {"📧 Email",-30}");


                foreach (var u in utenti)
                {
                    // Usa PadRight per allineare correttamente i valori nella tabella
                    Console.Write($"{u.Id,-6} {u.Nome,-20} {u.Email,-30}");

                    count++;

                    if (count % 2 == 0)
                    {
                        Console.WriteLine(); // Vai a capo ogni 2 utenti
                    }
                    else
                    {
                        Console.Write("   |   "); // Separatore tra le 2 colonne
                    }
                }

                if (count % 2 != 0) Console.WriteLine(); // Vai a capo se ne rimane uno solo
            }
            else
            {
                Console.WriteLine("⚠️ Nessun utente presente nel gestionale.");
            }
        }




        public List<Utente> GetUtenti()
        {
            return utenti;
        }

        //QUESTA FUNZIONE MOSTRA COME DEVE ESSERE LA STRUTTURA DEL NUOVO UTENTE REGISTRATO DALL'AMMINISTRATORE 
        public void Info_inserimento()
        {
            Console.WriteLine("\n====================================");
            Console.WriteLine("📝 INSERIMENTO NUOVO CLIENTE");
            Console.WriteLine("====================================");
            Console.WriteLine("Per favore, inserisci i seguenti dati:");
            Console.WriteLine("➡️  ID (numero intero)");
            Console.WriteLine("➡️  Nome completo (es. Mario Rossi)");
            Console.WriteLine("➡️  Email (es. mario@email.it)");
            Console.WriteLine("------------------------------------");
        }

        //QUESTA FUNZIONE MOSTRA IL MENU DI INTERAZIONE DELL'AMMINISTRATORE
        public void Menu_Amministratore()
        {
            Console.WriteLine("=== GESTIONALE CLIENTI ===\n");
            Console.WriteLine("1. Aggiungi utente");
            Console.WriteLine("2. Elimina utente");
            Console.WriteLine("3. Modifica utente");
            Console.WriteLine("4. Visualizza utenti");
            Console.WriteLine("5. Stampa utente");
            Console.WriteLine("6. Esci");
            Console.WriteLine();
            Console.Write("Scegli un'opzione: ");
        }
    }
}