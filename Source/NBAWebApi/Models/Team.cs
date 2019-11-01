using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBAWebApi.Models
{
    [Table("Player")]
    public class Team
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        public bool IsNBAFranchise { get; set; }

        [Column]
        public bool IsAllStar { get; set; }

        [Column]
        public string City { get; set; }

        [Column]
        public string FullName { get; set; }

        [Column]
        public string Tricode { get; set; }

        [Column]
        public string Nickname { get; set; }

        [Column]
        public string ConfName { get; set; }

    }
}
 
