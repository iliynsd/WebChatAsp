namespace WebChat.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }

        public User()
        {

        }
        public User(string name, string type)
        {
            Name = name;
            Type = type;
            IsActive = true;
        }
    }
}