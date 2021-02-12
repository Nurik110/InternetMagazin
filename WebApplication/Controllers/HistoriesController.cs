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
using WebApplication;

namespace WebApplication.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    /*
    Для класса WebApiConfig может понадобиться внесение дополнительных изменений, чтобы добавить маршрут в этот контроллер. Объедините эти инструкции в методе Register класса WebApiConfig соответствующим образом. Обратите внимание, что в URL-адресах OData учитывается регистр символов.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using WebApplication;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<History>("Histories");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class HistoriesController : ODataController
    {
        private Model1 db = new Model1();

        // GET: odata/Histories
        [EnableQuery]
        public IQueryable<History> GetHistories()
        {
            return db.Histories;
        }

        // GET: odata/Histories(5)
        [EnableQuery]
        public SingleResult<History> GetHistory([FromODataUri] int key)
        {
            return SingleResult.Create(db.Histories.Where(history => history.id == key));
        }

        // PUT: odata/Histories(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<History> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            History history = await db.Histories.FindAsync(key);
            if (history == null)
            {
                return NotFound();
            }

            patch.Put(history);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(history);
        }

        // POST: odata/Histories
        public async Task<IHttpActionResult> Post(History history)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Histories.Add(history);
            await db.SaveChangesAsync();

            return Created(history);
        }

        // PATCH: odata/Histories(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<History> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            History history = await db.Histories.FindAsync(key);
            if (history == null)
            {
                return NotFound();
            }

            patch.Patch(history);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(history);
        }

        // DELETE: odata/Histories(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            History history = await db.Histories.FindAsync(key);
            if (history == null)
            {
                return NotFound();
            }

            db.Histories.Remove(history);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistoryExists(int key)
        {
            return db.Histories.Count(e => e.id == key) > 0;
        }
    }
}
