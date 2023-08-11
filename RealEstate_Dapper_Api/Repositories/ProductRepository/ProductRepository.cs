using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository {
    public class ProductRepository : IProductRepository {
        private readonly Context _context;

        public ProductRepository(Context context) {
            _context = context;
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync() {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategories() {
            string query = "Select ProductID, Title,Price,City,Disctict,CategoryName From Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
    }
}
