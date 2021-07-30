using System;
using System.Collections.Generic;
using FileMultimediale.Entities;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMultimediale
{
    class Podcast : FileMultimediale
    {
        public string Descrizione { get; set; }
        public List<Episodio> Episodi { get; set; } = new List<Episodio>();


        public Podcast(string titolo, Autore autore, string descrizione, List<Episodio> episodi)
           : base(titolo, autore)
        {
            Descrizione = descrizione;
            Episodi = episodi;
        }

        public override string Print()
        {
            return $"{base.Print()} Descrizione: {Descrizione} ";
        }

    
        }
    }

    

 
   

