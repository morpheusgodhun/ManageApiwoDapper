using ManageApiwoDapper_Api.CategoryDtos;

namespace ManageApiwoDapper_Api.Repositories {
    public interface ICategoryRepository {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto categoryDto);
        void DeleteCategory(int id);
        void UpdateCategory(UpdateCategoryDto categoryDto);
        Task<GetByIDCategoryDto> GetCategory(int id);
    }
}
