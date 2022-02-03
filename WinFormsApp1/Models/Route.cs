using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class Route
    {
        public int RouteNummer { get; set; }
        public DateTime Datum { get; set; }
        public Werknemer Chauffeur { get; set; }
        public Werknemer BijRijder { get; set; }
        public TimeSpan StartTijd { get; set; }
        public TimeSpan EindTijd { get; set; }
        public string Bijzonderheden { get; set; }

        public Route(int routeNummer, DateTime datum, Werknemer chauffeur, Werknemer bijRijder, TimeSpan startTijd, TimeSpan eindTijd, string bijzonderheden)
        {
            RouteNummer = routeNummer;
            Datum = datum;
            Chauffeur = chauffeur;
            BijRijder = bijRijder;
            StartTijd = startTijd;
            EindTijd = eindTijd;
            Bijzonderheden = bijzonderheden;
        }

        public Route(int routeNummer, DateTime datum, Werknemer chauffeur, Werknemer bijRijder, TimeSpan startTijd, TimeSpan eindTijd)
        {
            RouteNummer = routeNummer;
            Datum = datum;
            Chauffeur = chauffeur;
            BijRijder = bijRijder;
            StartTijd = startTijd;
            EindTijd = eindTijd;
        }
    }
}
