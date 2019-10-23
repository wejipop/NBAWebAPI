namespace NBAWebApi.Acl
{
    public class ExternalTeam
    {
        public bool IsNBAFranchise { get; set; }

        public bool IsAllStar { get; set; }

        public string City { get; set; }

        public string FullName { get; set; }

        public string Tricode { get; set; }

        public string TeamId { get; set; }

        public string Nickname { get; set; }

        public string ConfName { get; set; }
    }
}
