using Newtonsoft.Json.Linq;
using System;
using System.Collections;
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
        private ThrifterModel db = new ThrifterModel();

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
        public IHttpActionResult PostProductOwnership([FromBody]string json)
        {
            return Ok("Samir");

            JObject body = JObject.Parse(json);

            var email = body.GetValue("Email").ToString();
            Owner owner = db.Owners.FirstOrDefault(x => x.Email.Equals(email));
            if (owner == null)
            {
                owner = new Owner() { Email = email };
                db.Owners.Add(owner);
            }

            JArray productsBought = body.GetValue("Products") as JArray;

            foreach (JObject currProd in productsBought)
            {
                Product newProd = db.Products.FirstOrDefault(x => x.Name.Equals(currProd.GetValue("Name")));

                if (newProd == null)
                {
                    newProd = new Product
                    {
                        Name = currProd.GetValue("Name").ToString(),
                        AvgOriginalPrice = double.Parse(currProd.GetValue("Price").ToString()),
                        ImageLink = currProd.GetValue("ImageLink").ToString()
                    };

                    db.Products.Add(newProd);
                }
                
                db.ProductOwnerships.Add(new ProductOwnership() {
                    BuyDate = DateTime.Now,
                    IsSelling = false,
                    NotificationDate = DateTime.Now.AddSeconds(15),
                    Owner = owner,
                    OwnerId = owner.Id,
                    Product = newProd,
                    ProductId = newProd.Id,
                    State = 1
                });
            }

            db.SaveChanges();

            return Ok("kaki");
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