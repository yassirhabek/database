using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class Werknemer
    {
        public int WerknemerID { get; set; }
        public string Naam { get; set; }
        public int TelefoonNummer { get; set; }

        public Werknemer()
        {

        }

        public Werknemer(int werknemerID, string naam, int telefoonNummer)
        {
            WerknemerID = werknemerID;
            Naam = naam;
            TelefoonNummer = telefoonNummer;
        }
    }
}
