namespace BackendAPI.Contracts
{
    public class GetDeliveryResponse
    {
        public int Id { get; set; }
        public string DeliveryStatus { get; set; } = null!;
        public int? DeliveryPrice { get; set; }
        public int? UserId { get; set; }
        public int? GoodsId { get; set; }

    }

}