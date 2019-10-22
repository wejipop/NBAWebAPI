namespace NBAWebApi.Acl
{
    public class ExternalPlayer
    {
        /// <summary>
        /// The id of the player based on nba database
        /// </summary>
        public string PersonId { get; set; }
        
        /// <summary>
        /// The first name of the player
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// The last name of the player
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// The height in feet
        /// </summary>
        public string HeightFeet { get; set; }
        
        /// <summary>
        /// The height in inches
        /// </summary>
        public string HeightInches { get; set; }
        
        /// <summary>
        /// The id of current team on bna database
        /// </summary>
        public string TeamId { get; set; }
        
        /// <summary>
        /// The date of birth in UTC standard time
        /// </summary>
        public string DateOfBirthUTC { get; set; }
        
        /// <summary>
        /// The player weight in pounds
        /// </summary>
        public string WeightPounds { get; set; }
        
        /// <summary>
        /// The country of origin
        /// </summary>
        public string Country { get; set; }
    }
}