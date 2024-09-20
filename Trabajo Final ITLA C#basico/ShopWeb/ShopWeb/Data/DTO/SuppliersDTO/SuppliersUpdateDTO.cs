namespace ShopWeb.Data.DTO.SuppliersDTO
{
    public class SuppliersUpdateDTO
    {
        public int supplierid { get; set; }
        public string companyname { get; set; }
        public string contactname { get; set; }
        public string contacttitle { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postalcode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }

        public DateTime modify_date { get; set; }
        public int modify_user { get; set; }
    }
}
