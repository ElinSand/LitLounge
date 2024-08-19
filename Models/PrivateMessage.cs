namespace LitLounge.Models
{
    public class PrivateMessage
    {
        public int Id { get; set; }
        public DateTime SentAt { get; set; }
        public string MessageContent { get; set; }

        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
    }
}
