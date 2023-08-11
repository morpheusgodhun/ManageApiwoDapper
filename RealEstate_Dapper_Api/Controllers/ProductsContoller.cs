using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsContoller : ControllerBase {
        private readonly IProductRepository _productRepository;

        public ProductsContoller(IProductRepository productRepository) {
            _productRepository = productRepository;
        }
        [HttpGet] 
        public async Task <IActionResult> ProductList() { 
        var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")] 
        public async Task <IActionResult> ProductListWithCategory() { 
        var values = await _productRepository.GetAllProductWithCategories();
            return Ok(values);
        }
    }
}
