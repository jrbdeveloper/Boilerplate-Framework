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
        
        public IEnumerable<PersonViewModel> Get()
        {
            return _personDomain.GetAll();
        }
        
        public PersonViewModel Get(int id)
        {
            return _personDomain.GetById(id);
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