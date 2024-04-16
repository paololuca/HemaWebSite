using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternalWebSiteStats.DAL.Entity
{
    public class Tournament
    {
        public string Name { get; set; }
        public int Pools { get; set; }
    }
}