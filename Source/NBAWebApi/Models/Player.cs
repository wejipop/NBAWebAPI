using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NBAWebApi.Models
{
    [Table("Player")]
    [Serializable]
    public class Player
    {
        /// <summary>
        /// The id of the player based on nba database
        /// </summary>
        [Key]
        [Column]
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        
        /// <summary>
        /// The first name of the player
        /// </summary>
        [Column]
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }
        
        /// <summary>
        /// The last name of the player
        /// </summary>
        [Column]
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
        
        /// <summary>
        /// The height in feet
        /// </summary>
        [Column]
        [DataMember(Name = "heightFeet")]
        public int HeightFeet { get; set; }
        
        /// <summary>
        /// The height in inches
        /// </summary>
        [Column]
        [DataMember(Name = "heightInches")]
        public int HeightInches { get; set; }
        
        /// <summary>
        /// The id of current team on bna database
        /// </summary>
        [Column]
        [DataMember(Name = "teamId")]
        public int TeamId { get; set; }
        
        /// <summary>
        /// The name of the current team
        /// </summary>
        [Column]
        [DataMember(Name = "teamName")]
        public string TeamName { get; set; }
        
        /// <summary>
        /// The date of birth in UTC standard time
        /// </summary>
        [Column("DateOfBirth")]
        [DataMember(Name = "dateOfBirthUTC")]
        public DateTime DateOfBirthUTC { get; set; }
        
        /// <summary>
        /// The player weight in pounds
        /// </summary>
        [Column]
        [DataMember(Name = "weightPounds")]
        public int WeightPounds { get; set; }
        
        /// <summary>
        /// The country of origin
        /// </summary>
        [Column]
        [DataMember(Name = "country")]
        public string Country { get; set; }

        /// <summary>
        /// The string representation of a players height in feet and inches
        /// </summary>
        public string HeightLabel => $"{this.HeightFeet}'{this.HeightInches}\"";

        /// <summary>
        /// The whole name
        /// </summary>
        public string Name => $"{this.FirstName} {this.LastName}";

        /// <summary>
        /// The age in years for the player
        /// </summary>
        public int Age => this.CalculateAge();
        
        private int CalculateAge()
        {
            var now = DateTime.UtcNow;
            var age = now.Year - this.DateOfBirthUTC.Year;

            if (now.Month < this.DateOfBirthUTC.Month || (now.Month == this.DateOfBirthUTC.Month && now.Day < this.DateOfBirthUTC.Day))
                age--;

            return age;
        }
    }
}