using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMultimediale.Entities
{
  public class Episodio
    {
        
            public string Titolo { get; set; }
            public Durata Durata { get; set; }
            public bool Ascoltato { get; set; } = false;


            public Episodio(string titolo, Durata durata, bool ascoltato)
            {
                Titolo = titolo;
                Durata = durata;
                Ascoltato = ascoltato;
            }

            public Episodio()
            {

            }

        public string Print()
        {
            return $"Titolo {Titolo} | Durata: {Durata.Ore}:{Durata.Minuti}:{Durata.Secondi} | Ascoltato: {Ascoltato}";
        }

    }

        public struct Durata
        {
            public int Ore { get; set; }
            public int Minuti { get; set; }
            public int Secondi { get; set; }

            public Durata(int ore, int min, int sec)
            {
                Ore = ore;
                Minuti = min;
                Secondi = sec;
            }
        }
    }

