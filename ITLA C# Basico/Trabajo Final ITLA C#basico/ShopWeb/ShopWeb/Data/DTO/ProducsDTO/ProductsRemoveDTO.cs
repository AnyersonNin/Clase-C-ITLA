namespace ShopWeb.Data.DTO.ProducsDTO
{
    public class ProductsRemoveDTO
    {
        public int productid { get; set; }
        public int delete_user { get; set; }
        public DateTime delete_date { get; set; }
        public bool deleted { get; set; }

    }
}