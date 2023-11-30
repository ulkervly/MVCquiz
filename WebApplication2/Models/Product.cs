using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }                                                                           
        
        public bool IsFeatured {  get; set; }
        public bool IsBestseller {  get; set; }
        public bool IsLatest {  get; set; }
        public List<ProductColour>? ProductColours { get; set; } 
        [NotMapped]
        public List<int> ColourIds { get; set; }
        public int CatagoryId {  get; set; }
        public Catagory? Catagory { get; set; }
    }
}
