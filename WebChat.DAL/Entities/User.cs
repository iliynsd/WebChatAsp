namespace WebChat.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }

        public User(string name, string email, string type)
        {
            Name = name;
            Email = email;
            Type = type;
            IsActive = true;
        }
    }
}