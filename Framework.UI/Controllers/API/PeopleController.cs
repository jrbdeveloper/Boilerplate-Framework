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
    }
}