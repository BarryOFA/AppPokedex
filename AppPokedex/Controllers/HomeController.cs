using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppPokedex.Models;
using Microsoft.Data.SqlClient;

namespace AppPokedex.Controllers {
    public class HomeController : Controller {
        // GET: Home
        public ActionResult Index () {
            List<pokemon> losPokemon = BasedeDatos.obtenerPoke();
            return View (losPokemon);
        }

        // GET: Home/Details/5
        public ActionResult Details (string Nombre) {
                return View ();
        }

        // GET: Home/Create
        public ActionResult Create () {
            return View ();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create (FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit (string Nombre) {
            //Buscar el id y crear un objeto Empleado


            return View ();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit (int id, FormCollection collection) {
            try {
                //Buscar en la base el id que se modificará
                //update
                // TODO: Add update logic here

                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete (int id) {
            //Buscar el numero de empleado (id) en la base y entregue el objeto empleado

            return View ();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete (int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        public pokemon MostrarDB (string Nombre) {
            pokemon pokemon = null;
            String cnnStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PokedexDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection cnn = new SqlConnection (cnnStr)) {
                cnn.Open ();

                SqlCommand cmdSql = new SqlCommand ("Select * from Pokemon where Nombre = @Nombre", cnn);
                cmdSql.Parameters.AddWithValue ("@Nombre", Nombre);

                SqlDataReader dr = cmdSql.ExecuteReader ();

                if(dr.Read ()) {
                    pokemon = new pokemon (dr.GetString (0), dr.GetString (1), dr.GetInt32 (3));
                }

                cnn.Close ();
                cnn.Dispose ();
            }
            return pokemon;
        }
    }
}