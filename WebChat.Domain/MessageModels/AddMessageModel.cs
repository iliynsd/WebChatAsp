namespace WebChat.Domain.MessageModels
{
    public class AddMessageModel
    {
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public string Text { get; set; }
    }
}
