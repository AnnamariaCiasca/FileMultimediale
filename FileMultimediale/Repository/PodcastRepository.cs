using FileMultimediale.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FileMultimediale
{
    class PodcastRepository : IRepository<Podcast>
    {

        static Episodio e1 = new Episodio("Episodio 1", new Durata(3, 12, 45), true);
        static Episodio e2 = new Episodio("Episodio 2", new Durata(2, 10, 15), false);
        static Episodio e3 = new Episodio("Episodio 1 - Augusto", new Durata(4, 15, 30), true);
        static Episodio e4 = new Episodio("Episodio 2 - Tiberio", new Durata(1, 45, 40), true);
        static Episodio e5 = new Episodio("Episodio 3 - Caligola", new Durata(2, 37, 40), false);
        static Episodio e6 = new Episodio("Ep1", new Durata(4, 12, 25), false);


        public static List<Episodio> episodi = new List<Episodio>
        {
            e1,
            e2,
            e3,
            e4,
            e5,
            e6
        };


        static List<Podcast> podcasts = new List<Podcast>
        {
            new Podcast("LA SECONDA GUERRA MONDIALE", new Autore("Marco", "Rossi", 1969), "Storia", new List<Episodio>{e1,e2 }),

            new Podcast("L'IMPERO ROMANO", new Autore("Alberto", "Angela", 1962), "Storia", new List<Episodio>{e3,e4,e5 }),

            new Podcast("LA SOCIETA' DIGITALE", new Autore("Serena", "Verdi", 1969), "Attualità", new List<Episodio>{e6 })

        };

        public List<Podcast> Fetch()
        {
            return podcasts;
        }

        internal bool Exists(string titolo)
        {
            return podcasts.Any(pc => pc.Titolo == titolo);
        }




        public List<Podcast> GetByTitolo(string titolo)
        {
          return  podcasts.Where(pc => pc.Titolo == titolo).ToList();
          
        }
        public List<Episodio> GetByTitoloEp(string titolo)
        {
            return episodi.Where(e => e.Titolo == titolo).ToList();

        }
        internal bool ExistsEp(string titolo)
        {
            return episodi.Any(e => e.Titolo == titolo);
        }

        internal List<Episodio> GetByDurata(Durata d)
        {
            var ep1 = episodi.Where(ep => ep.Durata.Ore <= d.Ore).ToList();
            var ep2 = ep1.Where(ep => ep.Durata.Minuti <= d.Minuti).ToList();
            var ep3 = ep2.Where(ep => ep.Durata.Secondi <= d.Secondi).ToList();

            return ep3;
        }



    }
}