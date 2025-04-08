using Microsoft.AspNetCore.Mvc;
namespace Module_4.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ValuesController1 : ControllerBase
    {
        // ✅ Ensure this list has some default values
        private static List<string> products = new List<string> { "Laptop", "Phone", "Table" };

        private readonly ILogger<ValuesController1> _logger;

        public ValuesController1(ILogger<ValuesController1> logger)
        {
            _logger = logger;
        }



        // ✅ GET API to return all products
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInformation("Get all products");
      
            if (products.Count == 0)
                return NotFound("No products found.");


            return Ok(products);
        }

        // ✅ POST API to add a product
        [HttpPost]
        public ActionResult Post([FromBody] string product)
        {
            if (string.IsNullOrEmpty(product))
            {
                return BadRequest("Product name cannot be empty.");
            }

            products.Add(product);
            return Ok($"Product '{product}' added successfully!");
        }
    }
}