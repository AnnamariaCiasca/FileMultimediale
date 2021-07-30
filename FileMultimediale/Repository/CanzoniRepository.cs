using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMultimediale
{
    class CanzoniRepository : IRepository<Canzone>
    {
        static List<Canzone> canzoni = new List<Canzone>
        {
            new Canzone("ALBACHIARA", new Autore("Vasco", "Rossi", 1952), ElencoGen.ROCK),
            new Canzone("LA CURA", new Autore("Franco", "Battiato", 1945), ElencoGen.BALLATA),
            new Canzone("MINUETTO", new Autore("Mia", "Martini", 1947), ElencoGen.BALLATA),
        };

        List<Canzone> playlist = new List<Canzone>();
        public List<Canzone> Fetch()
        {
            return canzoni;
        }

        public List<Canzone> FetchStaticList()
        {
            return canzoni;
        }

        public List<Canzone> FetchPlaylist()
        {

            return canzoni;

        }

        internal bool Exists(string titolo)
        {
            return canzoni.Any(c => c.Titolo == titolo);
        }

        internal void AddCanzoneToPlaylist(string titolo)
        {
            var c = canzoni.Where(canz => canz.Titolo == titolo);

            
                foreach (var song in c)
                {
                    playlist.Add(song);
                }

            foreach (var s in playlist)
            {
                Console.WriteLine(s.Print());
            }


        }

        public List<Canzone> GetByGenere(ElencoGen genere)
        {
            return canzoni.Where(c => c.Genere == genere).ToList();
        }
    }
}
