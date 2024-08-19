using LitLounge.Areas.Identity.Data;

namespace LitLounge.Models
{
    public class Comment
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }
        public LitLoungeUser User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }







    }
}
