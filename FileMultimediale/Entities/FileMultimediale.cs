using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMultimediale
{
    public abstract class FileMultimediale
    {

        public string Titolo { get; set; }
        public Autore Autore { get; set; }

        public FileMultimediale(string titolo, Autore autore)
        {
            Titolo = titolo;
            Autore = autore;
        }

        public virtual string Print()
        {
            return $"Titolo: {Titolo} | Autore: {Autore} |";
        }

    }


    public struct Autore
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public int AnnoNascita { get; set; }
        public Autore(string nome, string cognome, int annoNascita)
        {
            Nome = nome;
            Cognome = cognome;
            AnnoNascita = annoNascita;
        }
    }
}