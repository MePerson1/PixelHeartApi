using System.ComponentModel.DataAnnotations;

namespace PixelHeartApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string Backstory { get; set; }
        [Required]
        public int Age { get; set; }

        public string? VerificationToken { get; set; }
        public DateTime? CreatedAt { get; set; }

        public ICollection<UserSkill> UserSkills { get; set; }
        public ICollection<UserGamel> UserGames { get; set; }

        public ICollection<Match> Matches { get; set; }

    }
}
