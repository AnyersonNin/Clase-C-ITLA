namespace ShopWeb.Data.DTO.CustomersDTO
{
    public class CustomersRemoveDTO
    {
        public int custid { get; set; }

        public int delete_user { get; set; }
        public DateTime delete_date { get; set; }
        public bool deleted { get; set; }

    }
}
