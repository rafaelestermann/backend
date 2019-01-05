using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using NoKnowService.DataObjects;
using NoKnowService.Models;

namespace NoKnowService.Controllers
{
    public class GemeindeEntityController : TableController<GemeindeEntity>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            NoKnowContext context = new NoKnowContext();
            DomainManager = new EntityDomainManager<GemeindeEntity>(context, Request);
        }

        // GET tables/TodoItem
        public IQueryable<GemeindeEntity> GetAllGemeindeEntities()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-2%23FC9A27959
        public SingleResult<GemeindeEntity> GetGemeindeEntity(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<GemeindeEntity> PatchGemeindeEntity(string id, Delta<GemeindeEntity> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostGemeindeEntity(GemeindeEntity item)
        {
            GemeindeEntity current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteGemeindeEntity(string id)
        {
            return DeleteAsync(id);
        }
    }
}