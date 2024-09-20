namespace ShopWeb.Data.DTO.SuppliersDTO
{
    public class SuppliersRemoveDTO
    {
        public int Supplierid { get; set; }
        public int delete_user { get; set; }
        public DateTime delete_date { get; set; }
        public bool deleted { get; set; }
    }
}
