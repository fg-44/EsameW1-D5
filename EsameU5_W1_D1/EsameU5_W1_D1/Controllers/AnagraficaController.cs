using EsameU5_W1_D1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsameU5_W1_D1.Controllers
{
    public class AnagraficaController : Controller
    {
        // GET: Anagrafica

        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DbViolazioni"].ConnectionString.ToString());
        public ActionResult Index()
        {
            return View();
        }

        // COMANDI PER VISUALIZZARE LISTA ANAGRAFICA UTENTI
        public ActionResult AnagraficaUtente()
        {
            List<Anagrafica> ListaAnagraficheUtenti = new List<Anagrafica>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Anagrafica", conn);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read()) 
                {
                    ListaAnagraficheUtenti.Add(new Anagrafica()
                    {
                        
                        Cognome = sqlDataReader["Cognome"].ToString(),
                        NomeUtente = sqlDataReader["NomeUtente"].ToString(),
                        Indirizzo  = sqlDataReader["Indirizzo"].ToString(),
                        Città = sqlDataReader["Città"].ToString(),
                        Cod_fisc = sqlDataReader["Cod_fisc"].ToString()

                    });
                    conn.Close();
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }

            return View(ListaAnagraficheUtenti);
        }

        // COMANDI PER CREARE LISTA ANAGRAFICA UTENTI

        public ActionResult CreareAnagraficaUtente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreareAnagraficaUtente( Anagrafica anagrafica) 
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Anagrafica VALUES (@Cognome, @NomeUtente, @Città, @Indirizzo @Cod_fisc)", conn);
                cmd.Parameters.AddWithValue("Cognome", anagrafica.Cognome);
                cmd.Parameters.AddWithValue("NomeUtente" , anagrafica.NomeUtente);
                cmd.Parameters.AddWithValue("Indirizzo", anagrafica.Indirizzo);
                cmd.Parameters.AddWithValue("Città", anagrafica.Città);
                cmd.Parameters.AddWithValue("Cod_fisc", anagrafica.Cod_fisc);
                cmd.ExecuteNonQuery();

                return RedirectToAction("Anagrafica");
            }
            catch 
            {
                return View();
            }
            finally 
            { 
                conn.Close(); 
            }
        }
    }
}