using Microsoft.AspNetCore.Mvc;
using Shop.Dal;

namespace HetWeer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly ILogger<BrandController> _logger;
        private readonly ProductCatalogContext _context;

        public BrandController(ILogger<BrandController> logger, ProductCatalogContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetBrands")]
        public IEnumerable<Brand> Get()
        {
           return _context.Brands.ToList();
        }
    }
}