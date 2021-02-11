using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Newproject;

namespace Newproject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    /*
    Для класса WebApiConfig может понадобиться внесение дополнительных изменений, чтобы добавить маршрут в этот контроллер. Объедините эти инструкции в методе Register класса WebApiConfig соответствующим образом. Обратите внимание, что в URL-адресах OData учитывается регистр символов.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Newproject;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<category>("categories");
    builder.EntitySet<KazakhBest>("KazakhBests"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class categoriesController : ODataController
    {
        private Model1 db = new Model1();

        // GET: odata/categories
        [EnableQuery]
        public IQueryable<category> Getcategories()
        {
            return db.categories;
        }

        // GET: odata/categories(5)
        [EnableQuery]
        public SingleResult<category> Getcategory([FromODataUri] int key)
        {
            return SingleResult.Create(db.categories.Where(category => category.id == key));
        }

        // PUT: odata/categories(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<category> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            category category = await db.categories.FindAsync(key);
            if (category == null)
            {
                return NotFound();
            }

            patch.Put(category);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(category);
        }

        // POST: odata/categories
        public async Task<IHttpActionResult> Post(category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.categories.Add(category);
            await db.SaveChangesAsync();

            return Created(category);
        }

        // PATCH: odata/categories(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<category> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            category category = await db.categories.FindAsync(key);
            if (category == null)
            {
                return NotFound();
            }

            patch.Patch(category);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(category);
        }

        // DELETE: odata/categories(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            category category = await db.categories.FindAsync(key);
            if (category == null)
            {
                return NotFound();
            }

            db.categories.Remove(category);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/categories(5)/KazakhBests
        [EnableQuery]
        public IQueryable<KazakhBest> GetKazakhBests([FromODataUri] int key)
        {
            return db.categories.Where(m => m.id == key).SelectMany(m => m.KazakhBests);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool categoryExists(int key)
        {
            return db.categories.Count(e => e.id == key) > 0;
        }
    }
}
