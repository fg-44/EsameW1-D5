using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace EsameU5_W1_D1.Models
{
    public class Violazioni
    {
        public int  Id_violazione {  get; set; }
        public string TipoViolazione { get; set; }
        public string Descrizione { get; set; }
        public bool Contestabilità { get; set; }    

    }

    public class ViolazioniVerbale
    {
        public int Valore { get; set; }
        public string Testo { get; set; }
    }
}