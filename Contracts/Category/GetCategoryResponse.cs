namespace BackendAPI.Contracts
{
    public class GetCategoryResponse
    {

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public int? GoodsId { get; set; }

    }

}