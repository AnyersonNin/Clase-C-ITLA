namespace ShopWeb.Data.DTO.ProducsDTO
{
    public record ProductsUpdateDTO
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public int categoryid { get; set; }
        public int supplierid { get; set; }
        public decimal unitprice { get; set; }
        public bool discontinued { get; set; }

        public DateTime modify_date { get; set; }
        public int modify_user { get; set; }

    }
}
