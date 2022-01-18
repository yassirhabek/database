using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class Werknemer
    {
        public int WerknemerID { get; set; }
        public string Naam { get; set; }
        public double AantalUren { get; set; }

        public Werknemer()
        {

        }

        public Werknemer(int werknemerID, string naam)
        {
            WerknemerID = werknemerID;
            Naam = naam;
            AantalUren = 0;
        }
    }
}
