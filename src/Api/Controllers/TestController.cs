using Api.Entities.Auth;
using Api.Entities.Default;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        public readonly Repository<User> _manager;

        public TestController(IConfiguration configuration)
        {
            _manager = new Repository<User>(new AuthContext(configuration));
        }

        public ActionResult Get()
        {
            var rs = _manager.Query().ToList();
            return this.Ok(rs);
        }
    }
}