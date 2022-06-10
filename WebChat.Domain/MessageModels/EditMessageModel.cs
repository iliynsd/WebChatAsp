namespace WebChat.Domain.MessageModels
{
    public class EditMessageModel
    {
        public int MesId { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public string Text { get; set; }
    }
}
