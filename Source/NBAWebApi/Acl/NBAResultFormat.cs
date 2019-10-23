using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NBAWebApi.Acl
{
    [Serializable]
    public class NBAResultFormat<T>
    {
        [DataMember(Name = "league")]
        public LeagueFormat<T> League { get; set; }
    }

    [Serializable]
    public class LeagueFormat<T>
    {
        [DataMember(Name = "standard")]
        public List<T> Standard { get; set; }
    }
}

