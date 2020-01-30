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
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    public class CDsController : ApiController
    {
        private SQLFinalEntities db = new SQLFinalEntities();

        // GET: api/CDs
        public IQueryable<CD> GetCD()
        {
            return db.CD;
        }

        // GET: api/CDs/5
        [ResponseType(typeof(CD))]
        public IHttpActionResult GetCD(string id)
        {
            CD cD = db.CD.Find(id);
            if (cD == null)
            {
                return NotFound();
            }

            return Ok(cD);
        }

        // PUT: api/CDs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCD(string id, CD cD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cD.RecordID)
            {
                return BadRequest();
            }

            db.Entry(cD).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CDExists(id))
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

        // POST: api/CDs
        [ResponseType(typeof(CD))]
        public IHttpActionResult PostCD(CD cD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CD.Add(cD);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CDExists(cD.RecordID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cD.RecordID }, cD);
        }

        // DELETE: api/CDs/5
        [ResponseType(typeof(CD))]
        public IHttpActionResult DeleteCD(string id)
        {
            CD cD = db.CD.Find(id);
            if (cD == null)
            {
                return NotFound();
            }

            db.CD.Remove(cD);
            db.SaveChanges();

            return Ok(cD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CDExists(string id)
        {
            return db.CD.Count(e => e.RecordID == id) > 0;
        }
    }
}