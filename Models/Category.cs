namespace LitLounge.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
    }

    //public class Subcategory
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public int CategoryId { get; set; }
    //}
}
