using RealEstate_Dapper_Api.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository {
    public interface IProductRepository {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategories();

    }
}
