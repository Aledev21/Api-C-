namespace User.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        
        public string FullName { get; set; }
        
        // Chave estrangeira para relacionar com o usuário
        public int UserId { get; set; }
        
        public User User { get; set; }
    }
}
