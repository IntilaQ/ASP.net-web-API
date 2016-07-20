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
using Sessiongrp45.Models;

namespace Sessiongrp45.Controllers
{
    public class DepartementsController : ApiController
    {
        private Sessiongrp45Context db = new Sessiongrp45Context();

        // GET: api/Departements
        public List<Departement> GetDepartements()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Departements.Include(a=>a.Employees).ToList();
        }

        [Route("api/Departements/GetDepartementByname/{key}/{id}")]
        [ResponseType(typeof(List<Departement>))]
        public IHttpActionResult GetDepartementByname(string key,int id)
        {
           List< Departement> departements = db.Departements.Where(s => s.Name.Contains(key) && s.DepartementId==id).ToList();
            if (departements == null)
            {
                return NotFound();
            }
            return Ok(departements);
        }


        // GET: api/Departements/5
        [ResponseType(typeof(Departement))]
        public IHttpActionResult GetDepartement(int id)
        {
            Departement departement = db.Departements.Find(id);
            if (departement == null)
            {
                return NotFound();
            }

            return Ok(departement);
        }

        // PUT: api/Departements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartement(int id, Departement departement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departement.DepartementId)
            {
                return BadRequest();
            }

            db.Entry(departement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartementExists(id))
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

        // POST: api/Departements
        [ResponseType(typeof(Departement))]
        public IHttpActionResult PostDepartement(Departement departement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Departements.Add(departement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = departement.DepartementId }, departement);
        }

        // DELETE: api/Departements/5
        [ResponseType(typeof(Departement))]
        public IHttpActionResult DeleteDepartement(int id)
        {
            Departement departement = db.Departements.Find(id);
            if (departement == null)
            {
                return NotFound();
            }

            db.Departements.Remove(departement);
            db.SaveChanges();

            return Ok(departement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartementExists(int id)
        {
            return db.Departements.Count(e => e.DepartementId == id) > 0;
        }
    }
}