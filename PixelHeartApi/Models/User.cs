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
        public string Password { get; set; } //może to Hashcode powinen byc
        [Required]
        public string Backstory { get; set; }
        [Required]
        public int Level { get; set; }

        public ICollection<UserSkill> UserSkills { get; set; }
        public ICollection<UserGamel> UserGames { get; set; }

    }
}
