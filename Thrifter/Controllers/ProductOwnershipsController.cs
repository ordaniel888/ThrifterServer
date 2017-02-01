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
using Thrifter.DAL;

namespace Thrifter.Controllers
{
    public class ProductOwnershipsController : ApiController
    {
        private tbdrEntities db = new tbdrEntities();

        // GET: api/ProductOwnerships
        public IQueryable<ProductOwnership> GetProductOwnerships()
        {
            return db.ProductOwnerships;
        }

        // GET: api/ProductOwnerships/5
        [ResponseType(typeof(ProductOwnership))]
        public IHttpActionResult GetProductOwnership(DateTime id)
        {
            ProductOwnership productOwnership = db.ProductOwnerships.Find(id);
            if (productOwnership == null)
            {
                return NotFound();
            }

            return Ok(productOwnership);
        }

        // PUT: api/ProductOwnerships/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductOwnership(DateTime id, ProductOwnership productOwnership)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productOwnership.BuyDate)
            {
                return BadRequest();
            }

            db.Entry(productOwnership).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOwnershipExists(id))
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

        // POST: api/ProductOwnerships
        public IHttpActionResult PostProductOwnership(string json)
        {

            
                db.SaveChanges();
            
            

            return Ok();
        }

        // DELETE: api/ProductOwnerships/5
        [ResponseType(typeof(ProductOwnership))]
        public IHttpActionResult DeleteProductOwnership(DateTime id)
        {
            ProductOwnership productOwnership = db.ProductOwnerships.Find(id);
            if (productOwnership == null)
            {
                return NotFound();
            }

            db.ProductOwnerships.Remove(productOwnership);
            db.SaveChanges();

            return Ok(productOwnership);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductOwnershipExists(DateTime id)
        {
            return db.ProductOwnerships.Count(e => e.BuyDate == id) > 0;
        }
    }
}