using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NBAWebApi.Models;

namespace NBAWebApi.Acl
{
    [Serializable]
    public class NBAPlayerResultFormat
    {
        [DataMember(Name = "league")]
        public LeagueFormat League { get; set; }
    }

    [Serializable]
    public class LeagueFormat
    {
        [DataMember(Name = "standard")]
        public List<Player> Standard { get; set; }
        
        [DataMember(Name = "africa")]
        public List<Player> Africa { get; set; }
        
        [DataMember(Name = "sacramento")]
        public List<Player> Sacramento { get; set; }
        
        [DataMember(Name = "vegas")]
        public List<Player> Vegas { get; set; }
        
        [DataMember(Name = "utah")]
        public List<Player> Utah { get; set; }
    }
}

