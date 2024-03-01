using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace EsameU5_W1_D1.Models
{
    public class Anagrafica
    {
        public string Cognome { get; set; }
        public string NomeUtente { get; set; }
        public string Indirizzo { get; set; }
        public string Città { get; set; }
        public string Cod_fisc { get; set; }


    }

    public class AnagraficaVerbale
    {
        public int Valore { get; set; }
        public string Testo { get; set; }
    }
}