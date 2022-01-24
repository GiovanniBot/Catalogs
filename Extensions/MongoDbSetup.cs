using Catalogs.Repositories;
using Catalogs.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Catalogs.Extensions
{
    public static class MongoDbSetup
    {
        public static void AddMongoDb(this IServiceCollection services, IConfiguration Configuration)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            services.AddSingleton<IMongoClient>(serviceProvider => 
            {
                var settings = Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                return new MongoClient(settings.ConnectionString);
            });

            services.AddSingleton<IItemsRepository, MongoDbItemsRepository>();
        }
    }
}