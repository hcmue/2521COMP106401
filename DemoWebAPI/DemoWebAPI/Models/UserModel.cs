namespace DemoWebAPI.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class User : UserModel
    {
        public Guid Id { get; set; }
    }
}
