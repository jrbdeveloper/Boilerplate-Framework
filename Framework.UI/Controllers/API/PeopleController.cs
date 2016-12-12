using Framework.Core.Contracts.Domain;
using Framework.Core.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace Framework.UI.Controllers.API
{
    public class PeopleController : BaseApiController
    {
        private readonly IPersonDomain _personDomain;

        public PeopleController(IPersonDomain personDomain)
        {
            _personDomain = personDomain;
        }

        // GET: api/People
        public IEnumerable<PersonViewModel> Get()
        {
            return _personDomain.GetAll();
        }

        // GET: api/People/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/People
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}