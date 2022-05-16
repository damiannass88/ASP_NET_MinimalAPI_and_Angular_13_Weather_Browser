using Microsoft.EntityFrameworkCore;

namespace MinimalAPI_Weather_Browser
{
    public interface IWeatherEntityDB
    {
        DbSet<Weather> Weathers { get; set; }
    }


    /// <summary>
    /// To create migrations (entity framework) classes, tape in Package Manager: Add-Migration Weather_DBSet
    /// To set datebase, with 3 product ex. tape in Package Manager command: Update-Database
    /// </summary>
    public class WeatherEntityDB : DbContext, IWeatherEntityDB
    { 
        public WeatherEntityDB(DbContextOptions options) : base(options) {  }

        public DbSet<Weather> Weathers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weather>(eb =>
            {
                eb.HasKey(x => x.Id);
                eb.Property(x => x.Id).ValueGeneratedOnAdd();
                eb.Property(x => x.Location).HasColumnType("nvarchar(50)");
                eb.Property(x => x.Temperature).HasMaxLength(8);
                eb.Property(x => x.Wind).HasMaxLength(8);
                eb.Property(x => x.Cloudiness).HasMaxLength(25);
                eb.Property(x => x.Icon).HasMaxLength(100);
            });

            modelBuilder.Entity<Weather>().HasData(
              RandomSeedingWeather()
            );

        }
        public List<Weather> RandomSeedingWeather()
        {
            var paramsList = new List<Weather>();

            string[] locations = { "Brownsville", "Bryan", "Buffalo", "Burlington", "Cambridge", "Canton", "Carrollton", "Cathedral City",
                "Champaign", "Charleston", "Charlotte", "Chesapeake", "Chicago", "Clarksville", "Clearwater", "Cleveland", "Columbus",
                "Costa Mesa", "Dallas", "Danbury", "Davenport", "Davidson County", "Dayton", "Daytona Beach", "Deltona", "Denton",
                "Denver", "Detroit", "Downey", "Duluth", "Durham", "El Monte", "El Paso", "Elizabeth", "Elkhart", "Erie",
                "Escondido", "Eugene", "Evansville", "Fairfield", "Fargo", "Fayetteville", "Fitchburg", "Flint", "Fontana",
                "Fort Worth", "Frederick", "Fremont", "Fresno", "Fullerton", "Gainesville", "Garden Grove", "Garland"};
            string[] cloudiness = { "sunny", "snowy", "misty", "cloudy", "clear", "foggy" };
            string[] icons = { "☀", "⛅", "🌞", "❄", "⚡", "🌦", "🌤", "❄", "🌪" };

            var rand = new Random();

            for (int i = 0; i < 30; i++)
            {
                paramsList.Add(new Weather()
                {
                    Id = Guid.NewGuid(),
                    Location = locations[rand.Next(0, locations.Length-1)],
                    Temperature = rand.Next(-20, 39).ToString(),
                    Wind = rand.Next(0, 100).ToString(),
                    Cloudiness = cloudiness[rand.Next(0, cloudiness.Length-1)],
                    Icon = icons[rand.Next(0, icons.Length-1)],
                });
            };
             
            return paramsList;
        }
    }
}