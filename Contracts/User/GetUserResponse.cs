namespace BackendAPI.Contracts.User
{
    public class GetUserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string UserRole { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string UserAddress { get; set; } = null!;

    }

}