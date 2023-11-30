namespace WebApplication2.Models
{
    public class ProductColour
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColourId { get; set; }
        public Product Product { get; set; }
        public Colour Colour { get; set; }
    }
}
