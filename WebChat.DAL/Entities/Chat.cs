using System.Collections.Generic;

namespace WebChat.DAL.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        
        public Chat(string name)
        {
            Name = name;
            IsActive = true;
        }
    }
}