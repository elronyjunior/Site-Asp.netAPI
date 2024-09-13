using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PersonagemAPI.Models;

namespace PersonagemAPI.Controllers.API
{
    public class PersonagemController : ApiController
    {
        private BancoTCCEntities1 db = new BancoTCCEntities1();

        // GET: api/Personagem
        public IQueryable<Personagem> GetPersonagem()
        {
            return db.Personagem;
        }

        // GET: api/Personagem/5
        [ResponseType(typeof(Personagem))]
        public IHttpActionResult GetPersonagem(int id)
        {
            Personagem personagem = db.Personagem.Find(id);
            if (personagem == null)
            {
                return NotFound();
            }

            return Ok(personagem);
        }

        // PUT: api/Personagem/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonagem(int id, Personagem personagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personagem.ID)
            {
                return BadRequest();
            }

            db.Entry(personagem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonagemExists(id))
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

        // POST: api/Personagem
        [ResponseType(typeof(Personagem))]
        public IHttpActionResult PostPersonagem(Personagem personagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personagem.Add(personagem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personagem.ID }, personagem);
        }

        // DELETE: api/Personagem/5
        [ResponseType(typeof(Personagem))]
        public IHttpActionResult DeletePersonagem(int id)
        {
            Personagem personagem = db.Personagem.Find(id);
            if (personagem == null)
            {
                return NotFound();
            }

            db.Personagem.Remove(personagem);
            db.SaveChanges();

            return Ok(personagem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonagemExists(int id)
        {
            return db.Personagem.Count(e => e.ID == id) > 0;
        }
    }
}