using Gestionale.Models;
using Gestionale.Services;
using System;



class Program
{
    static void Main()
    {
        var utenteService = new UtenteService();
        bool cambio = false;
        bool elimino = false;
        bool lettura = false;
        int id = 0;
        int Selezione_funzione = 0;

        utenteService.StampaLogo();
        utenteService.aggiorna();
        //LOOP DEL PROGRAMA CHE VA A FINIRE UNA VOLTA CHE L'AMMINISTRATORE INSERISCE IL NUMERO "6"
        while (Selezione_funzione != 6)
        {
            utenteService.Menu_Amministratore();
            Selezione_funzione = int.Parse(Console.ReadLine()!);
            switch (Selezione_funzione)
            {

                /*
                1. AGGIUNGI UTENTE
                2. ELIMINA UTENTE
                3. MODIFICA UTENTE
                4. VISUALIZZA UTENTI
                5. STAMPA UTENTE
                6. EXIT DAL PROGRAMMA
                */

                //AGGIUNGI UTENTE
                case 1:
                    //MOSTRO A SCHERMO LE INFORMAZIONI CORRETTE PER INSERIRE I DATI 
                    utenteService.Info_inserimento();

                    //AVVIAMO UN PROCEDIMENTO IN CASO AMMINISTRATORE VOLESSE AGGIUNGERE ALTRI UTENTI
                    Console.WriteLine("\n====================================");
                    Console.WriteLine("\n=QUANTI UTENTI VORRESTI AGGIUNGERE?=");
                    int numero = int.Parse(Console.ReadLine());

                    //UN LOOP CHE VA AD AGGIUNGERE QUANTI UTENTI TANTO IL NUMERO SELEZIONATO NELLA VARIABILE NUMERO
                    for (int i = 0; i < numero; i++)
                    {
                        utenteService.Info_inserimento();
                        utenteService.AggiungiUtente();
                    }

                    break;

                //ELIMINA UTENTE
                case 2:
                    Console.WriteLine("➡️ INSERISCI ID DELL'UTENTE CHE VUOI ELIMINARE (numero intero)");
                    id = int.Parse(Console.ReadLine());
                    elimino = true;
                    cambio = false;
                    utenteService.TrovaUtente(id, cambio, elimino, lettura);
                    break;

                //MODIFICA UTENTE 
                case 3:
                    Console.WriteLine("➡️ INSERISCI ID DELL'UTENTE CHE VUOI MODIFICARE (numero intero)");
                    id = int.Parse(Console.ReadLine());
                    cambio = true;
                    elimino = false;
                    utenteService.TrovaUtente(id, cambio, elimino, lettura);
                    break;

                //VISUALIZZA LA LISTA COMPLETA DEGLI UTENTI
                case 4:
                    //QUESTA FUNZIONA VA A STAMPARE L'ELENCO COMPLETO DELLA LISTA UTENTI 
                    utenteService.StampaUtenti();
                    break;

                //SELEZIONA UN UTENTE SPECIFICO E LO STAMPA, LA SELEZIONE AVVIENE TTRAMITE ID 
                case 5:
                    //IN QUESTA FUNZIONE INVECE ANDIAMO A STAMPARE L'UTENTE DESIDERATO TRAMITE ID 
                    Console.WriteLine("INSERISCI IL NUMERO ID DELL'UTENTE DESIDERATO");
                    id = int.Parse(Console.ReadLine());
                    cambio = false;
                    elimino = false;
                    lettura = true;
                    utenteService.TrovaUtente(id, cambio, elimino, lettura);
                    break;
            }

            cambio = false;
            elimino = false;
            lettura = false;
        }
    }
}
