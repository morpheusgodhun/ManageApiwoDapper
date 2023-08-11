namespace RealEstate_Dapper_Api {
    public class ResultProductWithCategoryDto {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string City { get; set; }
        public string Discict { get; set; }
        public int ProductCategory { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }

    }
}
