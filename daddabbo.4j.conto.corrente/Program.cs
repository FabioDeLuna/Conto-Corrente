using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daddabbo._4j.conto.corrente
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Progetto Conto Corrente");
            Console.WriteLine("Sviluppato da Nicolò D'Addabbo, Dennis Dong e Fabio De Luna\n");

            /***CREAZIONE BANCA***/

            Console.Write("\nNome Banca: ");
            string nBanca = Console.ReadLine();

            Console.Write("\nIndirizzo" +
                ": ");
            string iBanca = Console.ReadLine();

            Banca banca = new Banca(nBanca, iBanca); // Banca

            /***INSERIMENTO DATI***/
            string selezione = StampaMenu();
            while (selezione != "99")
            {
                switch (selezione)
                {
                    case "1":
                        InterfacciaBanca(banca);
                        break;
                    case "2":
                        InterfacciaUtente(banca);
                        break;
                    }
                    selezione = StampaMenu();
                }
                Console.WriteLine("Chiudi il prgramma premendo qualsiasi tasto");
                Console.ReadKey();
            }

        public static string StampaMenu()
        {
            string selezione = "";

            do
            {
                try
                {
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    Console.WriteLine("1-Interfaccia banca                                             2-Interfaccia Utente");
                    Console.WriteLine("                                    99-Esci                                         ");
                    Console.Write("Inserisci> ");
                    selezione = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("\n");
                }
                catch
                {
                    Console.WriteLine("Errore di inserimento");
                    selezione = "0";
                }
            } while (selezione != "1" && selezione != "2" && selezione != "99");

            return selezione;
        }

        public static string InterfacciaBanca(Banca banca)
        {
            string selezione = "0";
            do
            {
                try
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("INTERFACCIA BANCA");
                    Console.WriteLine("1a- Modifica banca");
                    Console.WriteLine("2a- Crea Utente");
                    Console.WriteLine("3a- Stampa Informazioni banca");
                    Console.WriteLine("4a- Stampa tutti i clienti\n\n");
                    Console.WriteLine("2- Interfaccia Utente                      99- Esci");
                    Console.Write("Inserisci> ");
                    selezione = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("\n");
                }
                catch
                {
                    Console.WriteLine("Errore di inserimento");
                    selezione = "0";
                }
            } while (selezione != "1a" && selezione != "2a" && selezione != "3a" && selezione != "4a" && selezione != "2" && selezione != "99");

            switch (selezione)
            {
                case "1a":
                    ModificaInfoBanca(banca);
                    break;
                case "2a":
                    NuovoUtente(banca);
                    break;
                case "3a":
                    Console.WriteLine("Nome banca: " + banca.Nome + "\nIndirizzo banca: " + banca.Indirizzo);
                    break;
                case "4a":
                    Console.WriteLine("\n------------------------------");
                    Console.WriteLine("\nElenco clienti della banca " + banca.Nome);
                    foreach (ContoCorrente _conto in banca.conti)
                    {
                        Console.WriteLine(_conto.Intestatario.Nome + " IBAN: " + _conto.Iban);
                    }
                    Console.WriteLine("------------------------------\n");
                    break;
                case "2":
                    InterfacciaUtente(banca);
                    break;
                case "99":
                    break;
            }
            return selezione;
        }

        public static string InterfacciaUtente(Banca banca)
        {
            string selezione = "0";
            do
            {
                try
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("INTERFACCIA UTENTE   ");
                    Console.WriteLine("1b- Effettua bonifico");
                    Console.WriteLine("2b- Effettua versamento");
                    Console.WriteLine("3b- Effettua prelievo");
                    Console.WriteLine("4b- Visualizza movimenti");
                    Console.WriteLine("5b- Stampa saldo conto");
                    Console.WriteLine("6b- Aggiungi nuovo conto\n\n");
                    Console.WriteLine("1- Interfaccia Banca                      99- Esci");
                    Console.Write("Inserisci> ");
                    selezione = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("\n");
                }
                catch
                {
                    Console.WriteLine("Errore di inserimento");
                    selezione = "0";
                }
            } while (selezione != "1b" && selezione != "2b" && selezione != "3b" && selezione != "4b" && selezione != "5b" && selezione != "6b" && selezione != "1" && selezione != "99");

            switch (selezione)
            {
                case "1b":
                    EffettuaBonifico(banca);
                    break;
                case "2b":
                    EffettuaVersamento(banca);
                    break;
                case "3b":
                    EffettuaPrelievo(banca);
                    break;
                case "4b":
                    StampaMovimenti(banca);
                    break;
                case "5b":
                    Console.Write("Inserire IBAN del conto da verficare: ");
                    string ibanVerficare = Console.ReadLine();
                    bool ibanTrovato = false;
                    foreach (ContoCorrente c in banca.conti)
                    {
                        if (c.Iban == ibanVerficare)
                        {
                            ibanTrovato = true;
                            Console.WriteLine("\n------------------------------\n");
                            Console.WriteLine("Il saldo del conto " + ibanVerficare + " è di: " + c.Saldo);
                            Console.WriteLine("\n------------------------------\n");
                        }
                    }
                    if (ibanTrovato == false)
                    {
                        Console.WriteLine("IBAN non trovato");
                    }
                    break;
                case "6b":
                    AddContoAggiuntivo(banca);
                    break;
                case "1":
                    InterfacciaBanca(banca);
                    break;
                case "99":
                    break;
            }
            return selezione;
        }

        public static void ModificaInfoBanca(Banca banca)
        {
            int selezione = 0;

            while (selezione != 1 && selezione != 2 && selezione != 99)
            {
                try
                {
                    Console.WriteLine("\n------------------------------");
                    Console.WriteLine("1 - Modifica nome");
                    Console.WriteLine("2 - Modifica indirizzo");
                    Console.WriteLine("\n99 - Indietro");
                    Console.WriteLine("\n------------------------------\n");
                    selezione = int.Parse(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine("Errore di inserimento");
                    selezione = 0;
                }
            }

            switch (selezione)
            {
                case 1:
                    Console.Write("Inserisci nome: ");
                    banca.Nome = Console.ReadLine();
                    Console.WriteLine("Nome modificato");
                    break;
                case 2:
                    Console.Write("Inserisci indirizzo: ");
                    banca.Indirizzo = Console.ReadLine();
                    Console.WriteLine("Indirizzo modificato");
                    break;
                case 99:
                    break;
            }
        }

        public static void NuovoUtente(Banca banca)
        {
            Random iban_casuale = new Random();
            string nome, cf, telefono, mail, indirizzo;
            DateTime dataNascita = new DateTime();

            Console.Write("\nInserisci nome: ");
            nome = Console.ReadLine().ToString();

            Console.Write("\nInserisci codice fiscale: ");
            cf = Console.ReadLine().ToString();

            Console.Write("\nInserisci numero di telefono: ");
            telefono = Console.ReadLine().ToString();

            Console.Write("\nInserisci mail: ");
            mail = Console.ReadLine().ToString();

            Console.Write("\nInserisci indirizzo: ");
            indirizzo = Console.ReadLine().ToString();

            bool errore = true;
            while (errore == true)
            {
                try
                {
                    string[] data;

                    Console.Write("\nInserisci data di nascita (anno/mese/giorno): ");
                    data = Console.ReadLine().ToString().Split('/');

                    dataNascita = new DateTime(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));
                    errore = false;     
                }
                catch
                {
                    errore = true;
                    Console.WriteLine("Errore nell'inserimento dei dati");
                }
            }

            Intestatario intestatario = new Intestatario(nome, cf, telefono, mail, indirizzo, dataNascita);
            Console.WriteLine("Intestatario inserito correttamente");
            banca.AddCliente(intestatario);
            string risp;
            do
            {
                Console.Write("Vuoi creare un conto online? (si/no) ");
                risp = Console.ReadLine().ToLower();

                if(risp == "si" || risp == "sì")
                {
                    Console.WriteLine("Creazione conto online...");
                    ContoCorrente contoOnline = new ContoOnLine(intestatario, 100, "IT39" + iban_casuale.Next(10000, 1000000), banca, 2500);
                    Console.WriteLine("Conto corrente creato con numero massimo di movimenti pari a 100, un prelievo massimo di 2500 e con iban: " + contoOnline.Iban + "\n\n");
                } else if (risp == "no")
                {
                    Console.WriteLine("Creazione del conto...");

                    ContoCorrente conto = new ContoCorrente(intestatario, 100, "IT39" + iban_casuale.Next(10000, 1000000), banca);
                    banca.AddConto(conto);

                    Console.WriteLine("Conto corrente creato con numero massimo di movimenti pari a 100 e con iban: " + conto.Iban + "\n\n");
                }
                else
                {
                    Console.WriteLine("\nErrore, valore inserito non valido\n");
                }
                
            } while (risp != "si" && risp != "sì" && risp != "no");
           
        }

        public static void StampaMovimenti(Banca banca)
        {
            int selezione = 0;

            while(selezione != 99)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("\n------------------------------");
                        Console.WriteLine("1 - Stampa movimenti di un dato giorno");
                        Console.WriteLine("2 - Stampa movimenti di un dato cliente");
                        Console.WriteLine("3 - Stampa movimenti di un dato cliente in un dato giorno");
                        Console.WriteLine("\n99 - Indietro");
                        selezione = int.Parse(Console.ReadLine());
                        if (selezione != 1 && selezione != 2 && selezione != 3 && selezione != 99)
                        {
                            Console.WriteLine("Errore nell'inserimento dei dati");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Errore nell'inserimento dei dati");
                        selezione = 0;
                    }
                    
                } while (selezione != 1 && selezione != 2 && selezione != 3 && selezione != 99);

                switch (selezione)
                {
                    case 1:
                        DateTime data = new DateTime();
                        bool errore = true;
                        while (errore == true)
                        {
                            try
                            {
                                string[] sdata;

                                Console.Write("\nInserisci data (anno/mese/giorno): ");
                                sdata = Console.ReadLine().ToString().Split('/');

                                data = new DateTime(int.Parse(sdata[0]), int.Parse(sdata[1]), int.Parse(sdata[2]));
                                errore = false;
                            }
                            catch
                            {
                                errore = true;
                                Console.WriteLine("Errore nell'inserimento dei dati");
                            }
                        }

                        Console.WriteLine(banca.GetMovimento(data));
                        break;

                    case 2:
                        string iban;
                        bool trovato = false;
                        Console.WriteLine("Inserire IBAN del cliente da cercare: ");
                        iban = Console.ReadLine();
                        Intestatario intestatario = new Intestatario("", "", "", "", "", DateTime.Now);
                        foreach(ContoCorrente i in banca.conti)
                        {
                            if(i.Iban == iban)
                            {
                                intestatario = i.Intestatario;
                                trovato = true;
                            }
                        }

                        if (trovato)
                        {
                            Console.WriteLine(banca.GetMovimento(intestatario));
                        }
                        else
                        {
                            Console.WriteLine("Cliente non trovato");
                        }
                        break;

                    case 3:
                        DateTime data2 = new DateTime();
                        bool errore2 = true;
                        while (errore2 == true)
                        {
                            try
                            {
                                string[] sdata;

                                Console.Write("\nInserisci data (anno/mese/giorno): ");
                                sdata = Console.ReadLine().ToString().Split('/');

                                data = new DateTime(int.Parse(sdata[0]), int.Parse(sdata[1]), int.Parse(sdata[2]));
                                errore = false;
                            }
                            catch
                            {
                                errore = true;
                                Console.WriteLine("Errore nell'inserimento dei dati");
                            }
                        }

                        string iban2;
                        bool trovato2 = false;
                        Console.WriteLine("Inserire IBAN del cliente da cercare: ");
                        iban2 = Console.ReadLine();
                        Intestatario intestatario2 = new Intestatario("", "", "", "", "", DateTime.Now);
                        foreach (ContoCorrente i in banca.conti)
                        {
                            if (i.Iban == iban2)
                            {
                                intestatario2 = i.Intestatario;
                                trovato2 = true;
                            }
                        }

                        if (trovato2)
                        {
                            Console.WriteLine(banca.GetMovimento(data2, intestatario2));
                        }
                        else
                        {
                            Console.WriteLine("Cliente non trovato");
                        }
                        break;
                }
            }
        }

        public static void EffettuaBonifico(Banca banca)
        {
            bool trovato = false;
            Console.Write("\nInserire IBAN mittente: ");
            string ibanMittente = Console.ReadLine();
                 
            foreach(ContoCorrente c in banca.conti)
            {
                if (c.Iban == ibanMittente)
                {
                    trovato = true;
                }
            }

            if (trovato)
            {
                trovato = false;
                Console.Write("\nInserire IBAN destinatario: ");
                string ibanDestinatario = Console.ReadLine().ToString();
                foreach (ContoCorrente c in banca.conti)
                {
                    if (c.Iban == ibanDestinatario)
                    {
                        trovato = true;
                    }
                }
                if (trovato)
                {
                    Bonifico bonifico = new Bonifico(banca, ibanMittente, ibanDestinatario);
                    double importo = 0;
                    do
                    {
                        Console.Write("\nInserire importo bonifico: ");
                        importo = double.Parse(Console.ReadLine().ToString());
                    } while (importo < 0);
                    bonifico.EffettuaBonifico(importo);
                    Console.WriteLine("Bonifico dal valore di " + importo + " euro effettuato all'ora " + DateTime.Now);
                }
                else
                {
                    Console.WriteLine("IBAN destinatario non trovato");
                    Console.Write("\nVuoi Creare un nuovo conto corrente? (si/no) ");
                    string risp = Console.ReadLine().ToLower();

                    if(risp == "si" || risp == "sì")
                    {
                        NuovoUtente(banca);
                    }
                }
            }
            else
            {
                Console.WriteLine("IBAN mittente non trovato");
                Console.Write("\nVuoi Creare un nuovo conto corrente? (si/no) ");
                string risp = Console.ReadLine().ToLower();

                if (risp == "si" || risp == "sì")
                {
                    NuovoUtente(banca);
                }
            }

        }

        public static void EffettuaVersamento(Banca banca)
        {
            Console.WriteLine("Inserire IBAN conto: ");
            string iban = Console.ReadLine();

            ContoCorrente conto = banca.getConto(iban);

            Console.WriteLine("Inserire importo versamento: ");
            double importo = double.Parse(Console.ReadLine());

            conto.IncrementaSaldo(importo);
            Console.WriteLine("Versamento di " + importo + " euro effettuato");
        }

        public static void EffettuaPrelievo(Banca banca)
        {
            Console.WriteLine("Inserire IBAN conto: ");
            string iban = Console.ReadLine();

            ContoCorrente conto = banca.getConto(iban);

            Console.WriteLine("Inserire importo prelievo: ");
            double importo = double.Parse(Console.ReadLine());

            string risultatoPrelievo = conto.Preleva(importo);

            if (risultatoPrelievo != "Hai prelevato con successo")
            {
                Console.WriteLine("Errore il tuo saldo è minore del prelievo richiesto");
            }
            else
            {
                Console.WriteLine("Prelievo di " + importo + " euro effettuato");
            }   
        }

        public static void AddContoAggiuntivo(Banca banca)
        {
            bool trovato = false;
            Random iban_casuale = new Random();
            Console.Write("\nInserire codice fiscale cliente: ");
            Intestatario cliente = new Intestatario("", "", "", "", "", DateTime.Now);
            string cf = Console.ReadLine();

            foreach (Intestatario c in banca.clienti)
            {
                if (c.Cf == cf)
                {
                    trovato = true;
                    cliente = c;
                }
            }

            if (trovato)
            {
                string risposta = "";
                do
                {
                    Console.WriteLine("Vuoi aggiungere un conto online? (si/no)");
                    risposta = Console.ReadLine().ToLower();
                    if (risposta != "si" && risposta != "no")
                    {
                        Console.WriteLine("Errore nell'inserimento dati");
                    }
                } while (risposta != "si" && risposta != "sì" && risposta != "no");

                if (risposta == "no")
                {
                    Console.WriteLine("Creazione del conto...");
                    ContoCorrente conto = new ContoCorrente(cliente, 100, "IT39" + iban_casuale.Next(10000, 1000000), banca);
                    banca.AddConto(conto);
                    cliente.AddConto(conto);

                    Console.WriteLine("Conto corrente creato con numero massimo di movimenti pari a 100 e con iban: " + conto.Iban + "\n\n");
                } else
                {
                    Console.WriteLine("Creazione conto online...");
                    ContoCorrente contoOnline = new ContoOnLine(cliente, 100, "IT39" + iban_casuale.Next(10000, 1000000), banca, 2500);
                    Console.WriteLine("Conto corrente creato con numero massimo di movimenti pari a 100, un prelievo massimo di 2500 e con iban: " + contoOnline.Iban + "\n\n");
                }
            }
            else
            {
                string risposta = "";
                do
                {
                    Console.WriteLine("Cliente non trovato, vuoi inserirlo? (si/no)");
                    risposta = Console.ReadLine().ToLower();
                } while (risposta != "si" && risposta != "no");
                
                if(risposta == "si")
                {
                    NuovoUtente(banca);
                }
            }
        }
    }
}