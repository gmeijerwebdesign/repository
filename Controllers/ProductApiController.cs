using System.Collections.Generic;
using System.Linq;
using System.Web.Http; // let op, dit is Web API 2 namespace

namespace Premium_Data.Controllers
{
    public class ProductApiController : ApiController
    {
        private readonly JouwDbContext _context;

        public ProductApiController()
        {
            _context = new JouwDbContext();
        }

        [HttpGet]
        [Route("api/ProductApi")]
        public IHttpActionResult GetAllProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }
    }
}
