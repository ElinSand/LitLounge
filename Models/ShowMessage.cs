namespace LitLounge.Models
{
    public class ShowMessage
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public DateTime SentAt { get; set; }
        public string AuthorNickname { get; set; }

        public string ReceiverNickname { get; set; }

    }
}
