using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMultimediale
{
   public class Canzone : FileMultimediale
    {
        public ElencoGen Genere { get; set; }
    
        public Canzone(string titolo, Autore autore, ElencoGen genere)
           : base(titolo, autore)
        {
            Genere = genere;
        }

        public override string Print()
        {
            return $"{base.Print()} Genere: {Genere} |";
        }
    }

    public enum ElencoGen
    {
        ROCK,
        POP,
        DISCO,
        BALLATA
        
    }
}