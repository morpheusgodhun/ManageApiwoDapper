using Dapper;
using RealEstate_Dapper_Api.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories {
    public class CategoryRepository : ICategoryRepository {
        private readonly Context _context;

        public CategoryRepository(Context context) {
            _context = context;
        }
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync() {
            string query = "Select * From Category";
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                //eşleştireceğim kısım queryasync'den sonraki 
                return values.ToList();
            }
        }
        public async void CreateCategory(CreateCategoryDto categoryDto) {
            string query = "insert into Category(CategoryName,CategoryStatus) values(@categoryname, @categorystatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryname", categoryDto.CategoryName);
            parameters.Add("categorystatus", true);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id) {
            string query = "Delete From Category Where CategoryID =@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, new { id });
            }
        }



        public async void UpdateCategory(UpdateCategoryDto categoryDto) {
            string query = "Update * From Category Set CategoryName= @p1, CategoryStatus = @p2 Where CategoryID=@p3";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryname", categoryDto.CategoryName);
            parameters.Add("@categorystatus", categoryDto.CategoryStatus);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, new {
                    p1 = categoryDto.CategoryName,
                    p2 = categoryDto.CategoryStatus,
                    p3 = categoryDto.CategoryID
                });
            }
        }

        public async Task<GetByIDCategoryDto> GetCategory(int id) {
            string query = "Select * From Category Where CategoryID = @CategoryID";
            var parameters=new DynamicParameters();
            parameters.Add("CategoryID" ,id);
            using (var connection = _context.CreateConnection()) {
              var values=  await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query, parameters);
                return values;
            }
        }
    }
}
