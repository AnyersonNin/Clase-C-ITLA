namespace ShopWeb.Data.DTO.CategoriesDTO
{
    public class CategoriesAddDTO
    {
        public int categoryid { get; set; }
        public string categoryname { get; set; }
        public string description { get; set; }

        public int creation_user { get; set; }
        public DateTime creation_date { get; set; }
    }
}
