namespace ShopWeb.Data.DTO.CategoriesDTO
{
    public class CategoriesUpdateDTO
    {
        public int categoryid { get; set; }

        public string categoryname { get; set; }

        public string description { get; set; }
        public DateTime modify_date { get; set; }
        public int modify_user { get; set; }

    }
}
