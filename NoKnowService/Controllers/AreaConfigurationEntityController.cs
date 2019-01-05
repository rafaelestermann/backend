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
    public class AreaConfigurationEntityController : TableController<AreaConfigurationEntity>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            NoKnowContext context = new NoKnowContext();
            DomainManager = new EntityDomainManager<AreaConfigurationEntity>(context, Request);
        }

        // GET tables/AreaConfigurationEntity
        public IQueryable<AreaConfigurationEntity> GetAllAreaConfigurationEntities()
        {
            return Query();
        }

        // GET tables/AreaConfigurationEntity/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<AreaConfigurationEntity> GetAreaConfigurationEntity(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/AreaConfigurationEntity/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<AreaConfigurationEntity> PatchAreaConfigurationEntity(string id, Delta<AreaConfigurationEntity> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/AreaConfigurationEntity
        public async Task<IHttpActionResult> PostAreaConfigurationEntity(AreaConfigurationEntity item)
        {
            AreaConfigurationEntity current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/AreaConfigurationEntity/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAreaConfigurationEntity(string id)
        {
            return DeleteAsync(id);
        }
    }
}