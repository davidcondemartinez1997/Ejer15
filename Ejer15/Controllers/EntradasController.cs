﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Ejer15;
using Ejer15.Models;
using Ejer15.Repository;
using Ejer15.Servicios;

namespace Ejer15.Controllers
{
    public class EntradasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Entradas
        public IQueryable<Entrada> GetEntradas()
        {
            return db.Entradas;
        }

        // GET: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult GetEntrada(long id)
        {
            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                return NotFound();
            }

            return Ok(entrada);
        }

        // PUT: api/Entradas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntrada(long id, Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entrada.ID)
            {
                return BadRequest();
            }

            db.Entry(entrada).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntradaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Entradas
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult PostEntrada(Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEntradasRepository entradasRepository = new EntradasRepository();
            IEntradasService entradasService = new EntradasService(entradasRepository);
            entrada = entradasService.Create(entrada);

            return CreatedAtRoute("DefaultApi", new { id = entrada.ID }, entrada);
        }

        // DELETE: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult DeleteEntrada(long id)
        {
            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                return NotFound();
            }

            db.Entradas.Remove(entrada);
            db.SaveChanges();

            return Ok(entrada);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntradaExists(long id)
        {
            return db.Entradas.Count(e => e.ID == id) > 0;
        }
    }
}