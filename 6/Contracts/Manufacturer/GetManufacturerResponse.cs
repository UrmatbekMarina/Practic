namespace BackendAPI.Contracts
{
    public class GetManufacturerResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Inn { get; set; }
        public string? Location { get; set; }

    }

}