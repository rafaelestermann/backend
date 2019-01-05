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
    public class AccountEntityController : TableController<AccountEntity>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            NoKnowContext context = new NoKnowContext();
            DomainManager = new EntityDomainManager<AccountEntity>(context, Request);
        }

        // GET tables/TodoItem
        public IQueryable<AccountEntity> GetAllAccountEntities()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<AccountEntity> GetAccountEntity(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<AccountEntity> PatchAccountEntity(string id, Delta<AccountEntity> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostAccountEntity(AccountEntity item)
        {
            AccountEntity current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAccountEntity(string id)
        {
            return DeleteAsync(id);
        }
    }
}