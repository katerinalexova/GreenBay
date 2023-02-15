namespace GreenBay.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public double Coins { get; set; }
        public List<Item>? Items { get; set; }


        public User()
        {

        }
    }
}
