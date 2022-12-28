using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.Data.SqlClient;

namespace AppPokedex.Models
{
    public class BasedeDatos
    {
        public static void ConexionDB() {
            String cnnStr = ConfigurationManager.ConnectionStrings ["cnn"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection (cnnStr)) {
                cnn.Open ();


                cnn.Close ();
                cnn.Dispose ();
            }
        }

        public static void MostrarDB () {
            String cnnStr = ConfigurationManager.ConnectionStrings ["cnn"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection (cnnStr)) {
                cnn.Open ();

                SqlCommand cmdSql = new SqlCommand ("Select * from Pokemon", cnn);

                SqlDataReader dr = cmdSql.ExecuteReader ();

                while (dr.Read ()) {
                    Debug.Write ("Nombre" + dr.GetInt32 (0));
                    Debug.WriteLine ("- Tipo " + dr ["Tipo"].ToString ());
                    Debug.WriteLine("- Peso " + dr ["Peso".ToString ()]);
                    Debug.WriteLine ("- Altura" + dr ["Altura"].ToString ());
                    Debug.WriteLine ("- Genero" + dr ["Genero"].ToString ());
                    Debug.WriteLine ("- Fecha de captura" + dr ["FechaCaptura"].ToString ());
                }

                cnn.Close ();
                cnn.Dispose ();
            }
        }

        public pokemon MostrarDB (string Nombre) {
            pokemon pokemon = null;
            String cnnStr = ConfigurationManager.ConnectionStrings ["cnn"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection (cnnStr)) {
                cnn.Open ();

                SqlCommand cmdSql = new SqlCommand ("Select * from Pokemon where Nombre = @Nombre", cnn);
                cmdSql.Parameters.AddWithValue ("@Nombre", Nombre);

                SqlDataReader dr = cmdSql.ExecuteReader ();

                if (dr.Read ()) {
                    pokemon = new pokemon (dr.GetString (0), dr.GetString (1), dr.GetInt32 (3));
                }

                cnn.Close ();
                cnn.Dispose ();
            }
            return pokemon;
        }

        public static List<pokemon> obtenerPoke () {
            List<pokemon> losPokemon = new List<pokemon> ();
            String cnnStr = ConfigurationManager.ConnectionStrings ["cnn"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection (cnnStr)) {
                cnn.Open ();

                SqlCommand cmdSql = new SqlCommand ("Select * from Pokemon", cnn);                

                SqlDataReader dr = cmdSql.ExecuteReader ();

                while (dr.Read ()) {
                    losPokemon.Add (new pokemon (dr["Nombre"].ToString(), dr["Tipo"].ToString(), dr.GetInt32 (2)));
                }

                cnn.Close ();
                cnn.Dispose ();
            }
            return losPokemon;  
        }
    }
}