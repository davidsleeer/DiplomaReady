using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    public class CustsController : ApiController
    {
        private SQLFinalEntities db = new SQLFinalEntities();

        // GET: api/Custs
        public IQueryable<Cust> GetCust()
        {
            return db.Cust;
        }

        // GET: api/Custs/5
        [ResponseType(typeof(Cust))]
        public IHttpActionResult GetCust(int id)
        {
            Cust cust = db.Cust.Find(id);
            if (cust == null)
            {
                return NotFound();
            }

            return Ok(cust);
        }

        // PUT: api/Custs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCust(int id, Cust cust)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cust.CustID)
            {
                return BadRequest();
            }

            db.Entry(cust).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustExists(id))
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

        // POST: api/Custs
        [ResponseType(typeof(Cust))]
        public IHttpActionResult PostCust(Cust cust)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Add_Cust(cust.CustID, cust.FirstName, cust.LastName, cust.CustPcode, cust.InterestCode, cust.CustAddress);

            }
            catch (Exception)
            {
                if (CustExists(cust.CustID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cust.CustID }, cust);
        }

        // DELETE: api/Custs/5
        [ResponseType(typeof(Cust))]
        public IHttpActionResult DeleteCust(int id)
        {
            Cust cust = db.Cust.Find(id);
            if (cust == null)
            {
                return NotFound();
            }

            db.Cust.Remove(cust);
            db.SaveChanges();

            return Ok(cust);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustExists(int id)
        {
            return db.Cust.Count(e => e.CustID == id) > 0;
        }
    }
}