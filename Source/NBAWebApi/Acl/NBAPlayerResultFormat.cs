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
        public List<ExternalPlayer> Standard { get; set; }
        
        [DataMember(Name = "africa")]
        public List<ExternalPlayer> Africa { get; set; }
        
        [DataMember(Name = "sacramento")]
        public List<ExternalPlayer> Sacramento { get; set; }
        
        [DataMember(Name = "vegas")]
        public List<ExternalPlayer> Vegas { get; set; }
        
        [DataMember(Name = "utah")]
        public List<ExternalPlayer> Utah { get; set; }
    }
}

