using System;

namespace App1.Models
{
    public class Zajecia
    {
        public string Id { get; set; }
        public string Nazwa { get; set; }
        public string Godzina { get; set; }
    }

    public class ZajeciaSzczegoly
    {
        public string Id { get; set; }
        public string Nazwa { get; set; }
        public string Godzina { get; set; }
        public string Wykladowca { get; set; }
        public string Sala { get; set; }
        public Zajecia[] Alternatywy { get; set; }
    }
}