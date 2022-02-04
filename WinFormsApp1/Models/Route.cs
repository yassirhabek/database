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
        public DateTime StartTijd { get; set; }
        public DateTime EindTijd { get; set; }
        public TimeSpan AantalUur { get; set; }
        public string Bijzonderheden { get; set; }

        public Route(int routeNummer, DateTime datum, Werknemer chauffeur, Werknemer bijRijder, DateTime startTijd, DateTime eindTijd, string bijzonderheden)
        {
            RouteNummer = routeNummer;
            Datum = datum;
            Chauffeur = chauffeur;
            BijRijder = bijRijder;
            StartTijd = startTijd;
            EindTijd = eindTijd;
            Bijzonderheden = bijzonderheden;

            AantalUur = this.totaalAantalUur(startTijd, eindTijd);
        }

        public Route(int routeNummer, DateTime datum, Werknemer chauffeur, Werknemer bijRijder, DateTime startTijd, DateTime eindTijd)
        {
            RouteNummer = routeNummer;
            Datum = datum;
            Chauffeur = chauffeur;
            BijRijder = bijRijder;
            StartTijd = startTijd;
            EindTijd = eindTijd;

            AantalUur = this.totaalAantalUur(startTijd, eindTijd);
        }

        private TimeSpan totaalAantalUur(DateTime startTijd, DateTime eindTijd)
        {
            string rawHalfuur = "00:30:00";
            TimeSpan halfUur = TimeSpan.Parse(rawHalfuur);

            TimeSpan aantalUur = eindTijd - startTijd - ;
            return aantalUur;
        }
    }
}
