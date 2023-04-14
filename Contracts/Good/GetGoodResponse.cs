namespace BackendAPI.Contracts
{
    public class GetGoodResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CustomerId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? Value { get; set; }
        public int? Price { get; set; }
        public int? Discount { get; set; }

    }

}