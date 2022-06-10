namespace WebChat.Domain.ChatModels
{
    public class RemoveUserFromChatModel
    {
        public int UserId { get; set; }
        public int ChatId { get; set; }
    }
}
