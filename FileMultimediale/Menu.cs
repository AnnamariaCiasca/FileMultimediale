using FileMultimediale.Entities;

using System;
using System.Collections.Generic;

namespace FileMultimediale
{
    public static class Menu

    {
        static CanzoniRepository cRep = new CanzoniRepository();
        static PodcastRepository pRep = new PodcastRepository();
     



        public static void Start()
        {

            char continua;




            do
            {
                int scelta = 0;

                Console.WriteLine("***********************************************");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Digita 1 per Visualizzare tutte le Canzoni");    //ok
                Console.WriteLine("Digita 2 per Visualizzare tutti i Podcast");    //ok
                Console.WriteLine("Digita 3 per Visualizzare tutte le canzoni del genere scelto");   //ok
                Console.WriteLine("Digita 4 per Visualizzare tutti gli episodi del podcast scelto");
                Console.WriteLine("Digita 5 per Visualizzare i podcast con durata minore o uguale a quella inserita");  //ok
                Console.WriteLine("Digita 6 per Creare una playlist di Canzoni");   //ok
                Console.WriteLine("Digita 7 per Scegliere un episodio da riprodurre");


                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("***********************************************");

                while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 7)
                {
                    Console.WriteLine("Inserire valore corretto!");
                }

                switch (scelta)
                {
                    case 1:
                        List<Canzone> canzoni = cRep.Fetch();
                        Stampa(canzoni);

                        break;


                    case 2:
                        List<Podcast> podcasts = pRep.Fetch();
                        Stampa(podcasts);

                        break;


                    case 3:

                        ElencoGen genere = ChiediGenere();
                        List<Canzone> canzone = cRep.GetByGenere(genere);
                        Stampa(canzone);
                        break;


                    case 4:
                        string titolo = ChiediPodcast();
                        List<Podcast> p = pRep.GetByTitolo(titolo);
                        Stampa(p);

                        break;

                    case 5:

                        Durata d = ChiediDurata();
                        
                        List<Episodio> epi = pRep.GetByDurata(d);
                        Stampa(epi);

                        break;

                    case 6:
                        CreaPlaylist();
                        break;

                    case 7:
                        string tit = ChiediPodcast();
                        List<Episodio> ep = pRep.GetByTitoloEp(tit);
                        Stampa(ep);
                        string titoloEp = ChiediEpisodio();
                       
                        Stampa(ep);
                      
                        break;

                  

                    default:
                        break;

                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nVuoi ritornare al Menù principale? Se sì, digita s");
                continua = Console.ReadKey().KeyChar;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");


            } while (continua == 's' || continua == 'S');
        }




        private static void Stampa(List<Canzone> canzoni)
        {
            foreach (var canzone in canzoni)
            {
                Console.WriteLine(canzone.Print());
            }
        }
        private static void Stampa(List<Podcast> podcasts)
        {
            foreach (var podcast in podcasts)
            {
                Console.WriteLine(podcast.Print());
            }
        }
        private static void Stampa(List<Episodio> episodi)
        {
            foreach (var episodio in episodi)
            {
                Console.WriteLine(episodio.Print());
            }
        }

        public static ElencoGen ChiediGenere()
        {
            {
                int genere = 0;

                Console.WriteLine($"Inserisci 0 per il genere {ElencoGen.ROCK}");
                Console.WriteLine($"Inserisci 1 per il genere {ElencoGen.POP}");
                Console.WriteLine($"Inserisci 2 per il genere {ElencoGen.DISCO}");
                Console.WriteLine($"Inserisci 3 per il genere {ElencoGen.BALLATA}");


                while (!int.TryParse(Console.ReadLine(), out genere) || genere < 0 || genere > 3)
                {
                    Console.WriteLine("\nPuoi inserire solo numeri interi compresi tra 1 e 3");
                }



                return (ElencoGen)genere;
            }
        }

        private static string ChiediPodcast()
        {
            List<Podcast> podcasts = pRep.Fetch();
            Stampa(podcasts);
            string titolo;
            do
            {
                Console.WriteLine("\nInserisci il titolo del Podcast di cui vuoi visualizzare gli episodi");
                titolo = Console.ReadLine().ToUpper();
            } while (!pRep.Exists(titolo));

            return titolo;
        }

        private static string ChiediEpisodio()
        {
           
            string titolo;
            do
            {
                Console.WriteLine("\nDigita il titolo");
                titolo = Console.ReadLine().ToUpper();
            } while (!pRep.ExistsEp(titolo));

            return titolo;
        }

        private static void CreaPlaylist()
        {
            char ancora;
            do
            {
                List<Canzone> canzoni = cRep.Fetch();

                Stampa(canzoni);

                List<Canzone> playlist = cRep.FetchPlaylist();
                string titolo;

                do
                {
                    Console.WriteLine("\nInserisci il titolo della canzone che vuoi inserire nella Playlist\n");
                    titolo = Console.ReadLine().ToUpper();
                } while (!cRep.Exists(titolo));

                cRep.AddCanzoneToPlaylist(titolo);

                Console.WriteLine("\n\nVuoi aggiungere un'altra canzone alla Playlist? Se sì, digita s");
                ancora = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");



            } while (ancora == 's' || ancora == 'S');
            }

        private static Durata ChiediDurata()
        {
            Durata d = new Durata();

            int ore;
            do
            {
                Console.WriteLine("Inserisci le ore di durata dell'audiolibro");
            } while (!int.TryParse(Console.ReadLine(), out ore));
            d.Ore = ore;

            int min;
            do
            {
                Console.WriteLine("Inserisci i minuti");
            } while (!int.TryParse(Console.ReadLine(), out min));
            d.Minuti = min;

            int sec;
            do
            {
                Console.WriteLine("Inserisci i secondi");
            } while (!int.TryParse(Console.ReadLine(), out sec));
            d.Secondi = sec;

            return d;
        }
    }

    }
