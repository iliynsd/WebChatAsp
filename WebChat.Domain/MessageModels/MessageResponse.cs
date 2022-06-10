namespace WebChat.Domain.MessageModels
{
    public class MessageResponse
    {
        public string Text { get; set; }
        public string Time { get; set; }
        public bool IsViewed { get; set; }
        public string Author { get; set; }
    }
}
