namespace GreenBay.Models.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int Price { get; set; }
        public bool Sold { get; set; } = false;
        public User User { get; set; }

        public Item()
        {

        }
    }
}
