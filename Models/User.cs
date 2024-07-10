using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace User.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string? Email { get; set; }


        
        private string? _passwordHash;
        public string PasswordHash 
        { 
            get => _passwordHash; 
            set => _passwordHash = HashPassword(value); 
        }
        
        public string? PasswordSalt { get; set; } // Sal para salting da senha

        // Método para verificar a senha
        public bool VerifyPassword(string password)
        {
            string hashedPassword = HashPassword(password, Convert.FromBase64String(PasswordSalt));
            return PasswordHash == hashedPassword;
        }

        // Método privado para gerar o hash da senha
        private string HashPassword(string password, byte[] salt = null)
        {
            // Gerar um novo salt se não fornecido
            if (salt == null)
            {
                salt = new byte[16];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
            }

            // Configurações para o processo de hashing
            int iterations = 10000; // Número de iterações
            int hashLength = 32; // Tamanho do hash em bytes
            string hashAlgorithm = "SHA256"; // Algoritmo de hashing

            // Gerar o hash da senha com salting
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: iterations,
                numBytesRequested: hashLength));

            PasswordSalt = Convert.ToBase64String(salt);
            return hashedPassword;
        }
            public UserProfile Profile { get; set; } // Relação entre os models users

    }
}
