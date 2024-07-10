namespace User.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        
        public required string FullName { get; set; }
        
        // Chave estrangeira para relacionar com o usuário
        public int UserId { get; set; }
        
        public required User User { get; set; }
    }
}
