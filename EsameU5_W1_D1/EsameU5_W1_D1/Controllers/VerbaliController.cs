using EsameU5_W1_D1.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using static System.Net.Mime.MediaTypeNames;

namespace EsameU5_W1_D1.Controllers
{
    public class VerbaliController : Controller
    {
        // GET: Verbale
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DbViolazioni"].ConnectionString.ToString());

        public ActionResult Index()
        {
            return View();
        }

        //VISUALIZAZIONE VERBALE------------------------------------------------

        public ActionResult Verbali()
        {
            List<Verbali> listaVerbali = new List<Verbali>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Verbale", conn);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                    listaVerbali.Add(new Verbali()
                    {
                        Descrizione = sqlDataReader["Descrizione"].ToString(),
                        DataViolazione = DateTime.Parse(sqlDataReader["DataViolazione"].ToString()),
                        IndirizzoViolazione = sqlDataReader["IndirizzoViolazione"].ToString(),
                        NominativoAgente = sqlDataReader["NominativoAgente"].ToString(),
                        DataTrascrizioneVerbale = DateTime.Parse(sqlDataReader["DataTrascrizioneVerbale"].ToString()),
                        Importo = Decimal.Parse(sqlDataReader["Importo"].ToString()),
                        DecurtamentoPunti = Int32.Parse(sqlDataReader["DecurtamentoPunti"].ToString()),

                    });
                conn.Close();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }

            return View(listaVerbali);
        }
        
        //CREARE VERBALI -------------------------------------------------------

        public ActionResult CreateVerbale()
        {
            //IMPORTA DA ALTRE TABELLE//
            ViewBag.Tipologie = new List<ViolazioniVerbale>();
            ViewBag.Utenti = new List <AnagraficaVerbale>();

            try
            {
                //IMPORTA DATI  VIOLAZIONI
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Violazioni", conn);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                    ViewBag.TipoViolazione.Add(new ViolazioniVerbale()
                    {
                        Valore = Int32.Parse(sqlDataReader["Id_violazione"].ToString()),
                        Testo = String.Concat(sqlDataReader["TipoViolazione"].ToString(), " ", sqlDataReader["Descrizione"].ToString())
                        //Contestabilità = sqlDataReader["bool"].ToString(),
                    });

                    //IMPORTA DA ANAGRAFICAVERBALE//
                    cmd = new SqlCommand("SELECT Id_anagrafica, NomeUtente, Cognome FROM Anagrafica", conn);
                    sqlDataReader.Close();
                    sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    ViewBag.Utenti.Add(new AnagraficaVerbale()
                    {
                        Valore = Int32.Parse(sqlDataReader["Id_anagrafica"].ToString()),
                        Testo = String.Concat(sqlDataReader["NomeUtente"].ToString(), " ", sqlDataReader["Cognome"].ToString())
                    });
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }

            return View();

        }

        // ----------- //
        [HttpPost]
        public ActionResult CreareVerbale(Verbali verbali)
        {
            //IMPORTA DA ALTRE TABELLE//
            ViewBag.Tipologie = new List<ViolazioniVerbale>();
            ViewBag.Utenti = new List<AnagraficaVerbale>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Verbali VALUES(@Descrizione, @DataViolazione , @IndirizzoViolazione, @NominativoAgente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti)", conn);

                cmd.Parameters.AddWithValue("Descrizione", verbali.Descrizione);
                cmd.Parameters.AddWithValue("DataViolazione ", verbali.DataViolazione);
                cmd.Parameters.AddWithValue("IndirizzoViolazione", verbali.IndirizzoViolazione);
                cmd.Parameters.AddWithValue("NominativoAgente", verbali.NominativoAgente);
                cmd.Parameters.AddWithValue("DataTrascrizioneVerbale", verbali.DataTrascrizioneVerbale);
                cmd.Parameters.AddWithValue("Importo", verbali.Importo);
                cmd.Parameters.AddWithValue("DecurtamentoPunti", verbali.DecurtamentoPunti);


                cmd.ExecuteNonQuery();

                //------------------------
                //IMPORTA DATI  VIOLAZIONI


                cmd = new SqlCommand("SELECT * FROM Violazioni", conn);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                    ViewBag.TipoViolazione.Add(new ViolazioniVerbale()
                    {
                        Valore = Int32.Parse(sqlDataReader["Id_violazione"].ToString()),
                        Testo = String.Concat(sqlDataReader["TipoViolazione"].ToString(), " ", sqlDataReader["Descrizione"].ToString())
                        //Contestabilità = sqlDataReader["bool"].ToString(),
                    });

                //IMPORTA DA ANAGRAFICAVERBALE//
                cmd = new SqlCommand("SELECT Id_anagrafica, NomeUtente, Cognome FROM Anagrafica", conn);
                sqlDataReader.Close();
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                    ViewBag.Utenti.Add(new AnagraficaVerbale()
                    {
                        Valore = Int32.Parse(sqlDataReader["Id_anagrafica"].ToString()),
                        Testo = String.Concat(sqlDataReader["NomeUtente"].ToString(), " ", sqlDataReader["Cognome"].ToString())
                    });

                return RedirectToAction("Verbali");
            }
            catch
            {
                return View();
            }
            finally
            { 
                conn.Close( );
            }

        }
}
}