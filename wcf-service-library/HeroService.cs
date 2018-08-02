using System;
using System.Net;
using System.ServiceModel.Web;
using MongoDB.Driver;

namespace HeroServiceContracts
{
    public class HeroService : IHeroService
    {
        private static IMongoCollection<Hero> heroCollection;

        public static void ConnectToDatabase()
        {
            // Connect to MongoDB and get the collection we wish to work on
            MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = mongoClient.GetDatabase("heroes");
            heroCollection = database.GetCollection<Hero>("hero-collection");
        }

        public Hero GetHero(string name)
        {
            var filter = new FilterDefinitionBuilder<Hero>().Eq("Name", name);
            Hero hero = heroCollection.Find(filter).SingleOrDefault<Hero>();

            if (hero == null)
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound();

            return hero;
        }

        public Hero[] GetHeroList()
        {
            var filter = new FilterDefinitionBuilder<Hero>().Empty;
            return heroCollection.Find(filter).ToList().ToArray();
        }

        public void DeleteHero(string name)
        {
            var filter = new FilterDefinitionBuilder<Hero>().Eq("Name", name);
            heroCollection.DeleteOne(filter);

            WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NoContent;
        }

        // Create or update hero
        public void PutHero(Hero hero)
        {
            Console.WriteLine(hero.Name + " " + hero.Strength);

            if (hero != null)
            {
                FilterDefinition<Hero> filter = new FilterDefinitionBuilder<Hero>().Eq("Name", hero.Name);
                UpdateDefinition<Hero> update = new UpdateDefinitionBuilder<Hero>().Set("Strength", hero.Strength);
                FindOneAndUpdateOptions<Hero> opts = new FindOneAndUpdateOptions<Hero>();
                opts.IsUpsert = true;

                heroCollection.FindOneAndUpdate(filter, update, opts);

                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Created;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.BadRequest;
            }
        }
    }
}
