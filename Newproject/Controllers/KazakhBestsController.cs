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
    builder.EntitySet<KazakhBest>("KazakhBests");
    builder.EntitySet<Apple_iPad_Pro_A2229>("Apple_iPad_Pro_A2229"); 
    builder.EntitySet<Apple_Watch_Series_6>("Apple_Watch_Series_6"); 
    builder.EntitySet<category>("categories"); 
    builder.EntitySet<Nokia_230_DS>("Nokia_230_DS"); 
    builder.EntitySet<Samsung_Galaxy_S20_Plus>("Samsung_Galaxy_S20_Plus"); 
    builder.EntitySet<Skyworth_BD_400>("Skyworth_BD_400"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class KazakhBestsController : ODataController
    {
        private Model1 db = new Model1();

        // GET: odata/KazakhBests
        [EnableQuery]
        public IQueryable<KazakhBest> GetKazakhBests()
        {
            return db.KazakhBests;
        }

        // GET: odata/KazakhBests(5)
        [EnableQuery]
        public SingleResult<KazakhBest> GetKazakhBest([FromODataUri] int key)
        {
            return SingleResult.Create(db.KazakhBests.Where(kazakhBest => kazakhBest.id_product == key));
        }

        // PUT: odata/KazakhBests(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<KazakhBest> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            KazakhBest kazakhBest = await db.KazakhBests.FindAsync(key);
            if (kazakhBest == null)
            {
                return NotFound();
            }

            patch.Put(kazakhBest);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KazakhBestExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(kazakhBest);
        }

        // POST: odata/KazakhBests
        public async Task<IHttpActionResult> Post(KazakhBest kazakhBest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KazakhBests.Add(kazakhBest);
            await db.SaveChangesAsync();

            return Created(kazakhBest);
        }

        // PATCH: odata/KazakhBests(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<KazakhBest> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            KazakhBest kazakhBest = await db.KazakhBests.FindAsync(key);
            if (kazakhBest == null)
            {
                return NotFound();
            }

            patch.Patch(kazakhBest);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KazakhBestExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(kazakhBest);
        }

        // DELETE: odata/KazakhBests(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            KazakhBest kazakhBest = await db.KazakhBests.FindAsync(key);
            if (kazakhBest == null)
            {
                return NotFound();
            }

            db.KazakhBests.Remove(kazakhBest);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/KazakhBests(5)/Apple_iPad_Pro_A2229
        [EnableQuery]
        public IQueryable<Apple_iPad_Pro_A2229> GetApple_iPad_Pro_A2229([FromODataUri] int key)
        {
            return db.KazakhBests.Where(m => m.id_product == key).SelectMany(m => m.Apple_iPad_Pro_A2229);
        }

        // GET: odata/KazakhBests(5)/Apple_Watch_Series_6
        [EnableQuery]
        public IQueryable<Apple_Watch_Series_6> GetApple_Watch_Series_6([FromODataUri] int key)
        {
            return db.KazakhBests.Where(m => m.id_product == key).SelectMany(m => m.Apple_Watch_Series_6);
        }

        // GET: odata/KazakhBests(5)/category
        [EnableQuery]
        public SingleResult<category> Getcategory([FromODataUri] int key)
        {
            return SingleResult.Create(db.KazakhBests.Where(m => m.id_product == key).Select(m => m.category));
        }

        // GET: odata/KazakhBests(5)/Nokia_230_DS
        [EnableQuery]
        public IQueryable<Nokia_230_DS> GetNokia_230_DS([FromODataUri] int key)
        {
            return db.KazakhBests.Where(m => m.id_product == key).SelectMany(m => m.Nokia_230_DS);
        }

        // GET: odata/KazakhBests(5)/Samsung_Galaxy_S20_Plus
        [EnableQuery]
        public IQueryable<Samsung_Galaxy_S20_Plus> GetSamsung_Galaxy_S20_Plus([FromODataUri] int key)
        {
            return db.KazakhBests.Where(m => m.id_product == key).SelectMany(m => m.Samsung_Galaxy_S20_Plus);
        }

        // GET: odata/KazakhBests(5)/Skyworth_BD_400
        [EnableQuery]
        public IQueryable<Skyworth_BD_400> GetSkyworth_BD_400([FromODataUri] int key)
        {
            return db.KazakhBests.Where(m => m.id_product == key).SelectMany(m => m.Skyworth_BD_400);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KazakhBestExists(int key)
        {
            return db.KazakhBests.Count(e => e.id_product == key) > 0;
        }
    }
}
