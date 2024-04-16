using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq;
using MongoDB.Bson.Serialization;
using InternalWebSiteStats.DAL.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace InternalWebSiteStats.DAL
{
    public class SqlDal_Mongo_Hema
    {
        const string connectionUri = "mongodb+srv://paololuca:sAxXUKrqU20Mj6sp@piellelandia.y5mdses.mongodb.net/?retryWrites=true&w=majority&appName=Piellelandia";
        private MongoClient client;
        private IMongoDatabase database;
        private string dbName = "hemasite";



        public SqlDal_Mongo_Hema()
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.AllowInsecureTls = true;
            // Set the ServerApi field of the settings object to set the version of the Stable API on the client
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
            client = new MongoClient(settings);
            // Accesso al database "sample_mflix"
            database = client.GetDatabase(dbName);
        }



        public Tournament LoadTorunamentsDesc(int idTorneo)
        {
            
            // Accesso alla collezione "movies"
            var collection = database.GetCollection<BsonDocument>("TOURNAMENT");

            // Definizione della query (ad esempio, trova tutti i documenti con un certo titolo)
            var filter = Builders<BsonDocument>.Filter.Eq("IdTorneo", idTorneo);

            // Esecuzione della query
            var result = collection.Find(filter).ToList();

            var t = result.FirstOrDefault();

            if (t != null)
            {
                return new Tournament()
                {
                    Name = t[2].ToString(),
                    Pools = Convert.ToInt32(t[3])
                };
            }
            else
                return null;
        }

        public List<Matches> LoadPoolsMatches(int idTorneo)
        {
            List<Matches> matches = new List<Matches>();

            // Accesso alla collezione "movies"
            var collection = database.GetCollection<BsonDocument>("POOLS_MATCHES");

            // Definizione della query (ad esempio, trova tutti i documenti con un certo titolo)
            var filter = Builders<BsonDocument>.Filter.Eq("IdTorneo", idTorneo);

            // Esecuzione della query
            var result = collection.Find(filter).ToList();



            if (result != null)
            {
                foreach (var r in result)
                {
                    matches.Add(new Matches()
                    {
                        Pool = Convert.ToInt32(r[2]),
                        Fighter1 = r[3].ToString(),
                        Fighter1_Hit = Convert.ToInt32(r[4]),
                        Double = Convert.ToBoolean(r[7]),
                        Fighter2_Hit = Convert.ToInt32(r[6]),
                        Fighter2 = r[5].ToString()
                    });
                }

            }

            return matches.OrderBy(x => x.Pool).ToList();
            
        }

        public List<Stats> LoadStats(int idTorneo)
        {
            var statsList = new List<Stats>();

            // Accesso alla collezione "movies"
            var collection = database.GetCollection<BsonDocument>("POOLS_STATS");

            // Definizione della query (ad esempio, trova tutti i documenti con un certo titolo)
            var filter = Builders<BsonDocument>.Filter.Eq("IdTorneo", idTorneo);

            var sortDefinition = Builders<BsonDocument>.Sort.Descending("Differenziale")
            .Descending("Vittorie")
            .Descending("PuntiFatti")
            .Ascending("PuntiSubiti")
            .Descending("Ranking");

            // Esecuzione della query
            var result = collection.Find(filter).Sort(sortDefinition).ToList();

            if (result != null)
            {
                int i = 1;

                foreach (var r in result)
                {
                    statsList.Add(new Stats()
                    {
                        Pos = i++,

                        Surname = r[6].ToString(),
                        Name = r[7].ToString(),
                        Victory = Convert.ToInt32(r[8]),
                        Loss = Convert.ToInt32(r[9]),
                        Hit = Convert.ToInt32(r[10]),
                        Hitted = Convert.ToInt32(r[11]),
                        Delta = Convert.ToDouble(r[12]),
                        Ranking = Convert.ToDouble((double)r[14]),
                    });
                }
            }

            return statsList;
        }
    }
}