using System.ComponentModel.DataAnnotations;

namespace PixelHeartApi.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Level { get; set; }

        public ICollection<UserSkill> UserSkills { get; set; }
    }
}