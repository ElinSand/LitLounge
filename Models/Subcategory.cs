﻿namespace LitLounge.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
