using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsameU5_W1_D1.Models
{
    public class Verbale
    {
           
        public string Descrizione { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string NominativoAgente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }
        public decimal DecurtamentoPunti { get; set; }
        
    }
}
