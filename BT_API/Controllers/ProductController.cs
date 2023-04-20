using BT_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BT_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ProductResponse GetAllProducts()
        {
            return _context.GetAll();
        }

        [HttpPost("Add")]
        public ProductResponse Post(Product product)
        {
            var productRes = _context.Add(product);

            return productRes;
        }
      
        [HttpGet("GetById")]
        public ProductResponse Get(int id)
        {
            var product = _context.GetById(id);
            if (product == null)
                return new ProductResponse { Error = new Error { ErrorMessage = "No data. Please try again." } };
            return product;
        }
        [HttpPut("Update")]
        public ProductResponse Put(int id, Product productData)
        {
            if (productData == null || id == 0)
                return new ProductResponse { Error = new Error { ErrorMessage = "Invalid data" } };
            productData.Id = id;
            var productResp = _context.Update(productData);
            if (productResp == null)
                return new ProductResponse { Error = new Error { ErrorMessage = "No data. Please try again." } };
            return productResp;
        }
        [HttpDelete("Delete")]
        public ProductResponse Delete(int id)
        {
            var productResp = _context.Delete(id);
            if (productResp == null)
                return new ProductResponse { Error = new Error { ErrorMessage = "No data. Please try again." } };
            return productResp;
        }
    }
}
