using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnakeApi.Models
{
    [Table("Scores")]
    public class Score
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Score")]
        public int ScoreValue { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}
