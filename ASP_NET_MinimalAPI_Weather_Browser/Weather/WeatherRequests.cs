using Microsoft.EntityFrameworkCore;

namespace MinimalAPI_Weather_Browser;

public static class WeatherRequests
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        app.MapGet("/api/weather", async (WeatherEntityDB db) => await db.Weathers.ToListAsync())
            .Produces<List<Weather>>()
            .WithTags("All Weather Browser");
            //.RequireAuthorization();

        app.MapGet("/api/weather/{id}", async (WeatherEntityDB db, Guid id) =>
        {
            var result = await db.Weathers.FindAsync(id);
            if (result is null) return Results.NotFound();

            return Results.Ok(result);
        }).WithTags("From ID Weather Browser API");

        app.MapPost("/api/weather", async (WeatherEntityDB db, Weather weather) =>
        {
            await db.Weathers.AddAsync(weather);
            await db.SaveChangesAsync();
            return Results.Ok();
        }).WithTags("POST Weather API").WithValidator<Weather>();

        app.MapPut("/api/weather/{id}", async (WeatherEntityDB db, Weather requestWeather, Guid id) =>
        {
            var result = await db.Weathers.FindAsync(id);
            if (result is null) return Results.NotFound();
            result.Location = requestWeather.Location;
            result.Temperature = requestWeather.Temperature;
            result.Wind = requestWeather.Wind;
            result.Cloudiness = requestWeather.Cloudiness;
            result.Icon = requestWeather.Icon;
            await db.SaveChangesAsync();
            return Results.NoContent();
        }).WithTags("Put Weather API").WithValidator<Weather>();

        app.MapDelete("/api/weather/{id}", async (WeatherEntityDB db, Guid id) =>
        {
            var result = await db.Weathers.FindAsync(id);
            if (result is null)
            {
                return Results.NotFound();
            }
            db.Weathers.Remove(result);
            await db.SaveChangesAsync();
            return Results.NoContent();
        }).WithTags("Delete Weather API").ExcludeFromDescription();

        return app;
    }
}