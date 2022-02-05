﻿using System;
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
        public TimeSpan AantalUur { get; set; }
        public string Bijzonderheden { get; set; }

        public Route()
        {

        }

        public Route(int routeNummer, DateTime datum, Werknemer chauffeur, Werknemer bijRijder, TimeSpan startTijd, TimeSpan eindTijd, string bijzonderheden)
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

        public Route(int routeNummer, DateTime datum, Werknemer chauffeur, Werknemer bijRijder, TimeSpan startTijd, TimeSpan eindTijd)
        {
            RouteNummer = routeNummer;
            Datum = datum;
            Chauffeur = chauffeur;
            BijRijder = bijRijder;
            StartTijd = startTijd;
            EindTijd = eindTijd;

            AantalUur = this.totaalAantalUur(startTijd, eindTijd);
        }

        private TimeSpan totaalAantalUur(TimeSpan startTijd, TimeSpan eindTijd)
        {
            string rawHalfuur = "00:30:00";
            TimeSpan halfUur = TimeSpan.Parse(rawHalfuur);

            TimeSpan aantalUur = eindTijd - startTijd - halfUur;
            return aantalUur;
        }
    }
}
