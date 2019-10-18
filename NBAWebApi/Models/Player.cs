using System;
using System.Runtime.Serialization;

namespace NBAWebApi.Models
{
    [Serializable]
    public class Player
    {
        /// <summary>
        /// The id of the player based on nba database
        /// </summary>
        [DataMember(Name = "personId")]
        public string PersonId { get; set; }
        
        /// <summary>
        /// The first name of the player
        /// </summary>
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }
        
        /// <summary>
        /// The last name of the player
        /// </summary>
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
        
        /// <summary>
        /// The height in feet
        /// </summary>
        [DataMember(Name = "heightFeet")]
        public string HeightFeet { get; set; }
        
        /// <summary>
        /// The height in inches
        /// </summary>
        [DataMember(Name = "heightInches")]
        public string HeightInches { get; set; }
        
        /// <summary>
        /// The id of current team on bna database
        /// </summary>
        [DataMember(Name = "teamId")]
        public string TeamId { get; set; }
        
        /// <summary>
        /// The name of the current team
        /// </summary>
        [DataMember(Name = "teamName")]
        public string TeamName { get; set; }
        
        /// <summary>
        /// The date of birth in UTC standard time
        /// </summary>
        [DataMember(Name = "dateOfBirthUTC")]
        public string DateOfBirthUTC { get; set; }
        
        /// <summary>
        /// The player weight in pounds
        /// </summary>
        [DataMember(Name = "weightPounds")]
        public string WeightPounds { get; set; }
        
        /// <summary>
        /// The country of origin
        /// </summary>
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
            if (string.IsNullOrWhiteSpace(this.DateOfBirthUTC))
            {
                return 0;
            }
            
            var now = DateTime.UtcNow;
            var dob = Convert.ToDateTime(DateOfBirthUTC);
            var age = now.Year - dob.Year;

            if (now.Month < dob.Month || (now.Month == dob.Month && now.Day < dob.Day))
                age--;

            return age;
        }
    }
}