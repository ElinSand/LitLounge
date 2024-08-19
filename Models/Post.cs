using LitLounge.Areas.Identity.Data;

namespace LitLounge.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        
        public int? SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }

        public string? UserId { get; set; }
        public LitLoungeUser User { get; set; }

        public ICollection<Comment> Comments { get; set; } // Lista över kommentarer
        public int LikeCount { get; set; } // Antal likes
        public int ReportCount { get; set; } // Antal rapporteringar

        //public string ProfileImagePath { get; set; }

        //public bool IsReported { get; set; }
        //public List<Comment>? Comments { get; set; }



    }
}
