using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_MinimalAPI_Weather_Browser.Migrations
{
    public partial class Weather_DBSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Temperature = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Wind = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Cloudiness = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Weathers",
                columns: new[] { "Id", "Cloudiness", "Icon", "Location", "Temperature", "Wind" },
                values: new object[,]
                {
                    { new Guid("1abb312a-e5d8-4ff0-afa5-61fc8679de10"), "cloudy", "🌞", "Canton", "31 °C", "62 km/h" },
                    { new Guid("20d58d9f-8271-4334-8bd5-b30e967f11af"), "misty", "🌦", "Champaign", "-2 °C", "81 km/h" },
                    { new Guid("28b43bde-83d2-40ec-b370-6a5414055683"), "snowy", "🌞", "Fairfield", "30 °C", "60 km/h" },
                    { new Guid("35269833-2e61-4425-afdd-a68e1180ee28"), "clear", "☀", "Garden Grove", "-10 °C", "88 km/h" },
                    { new Guid("45253e5e-0cf4-4b64-81ef-a7f67ca7e344"), "misty", "🌦", "Gainesville", "-19 °C", "96 km/h" },
                    { new Guid("49063ce9-3d21-4091-a48d-cec53f3ed7ad"), "snowy", "🌞", "Downey", "24 °C", "86 km/h" },
                    { new Guid("54c802dc-4839-4f9c-9e2b-8dbc01612777"), "clear", "🌤", "Cleveland", "18 °C", "72 km/h" },
                    { new Guid("5e45da53-5d97-47dc-acf0-7cc47a650a35"), "sunny", "❄", "Daytona Beach", "26 °C", "90 km/h" },
                    { new Guid("5e53e276-f1d9-4a4e-8e9a-fc841d862d3f"), "clear", "❄", "Danbury", "-9 °C", "82 km/h" },
                    { new Guid("6ab3de29-8b45-4af7-861c-74e2d36cc099"), "misty", "🌦", "Erie", "29 °C", "20 km/h" },
                    { new Guid("76760cb7-f78b-4e4b-9b34-55356c9a14a3"), "cloudy", "🌤", "Daytona Beach", "12 °C", "68 km/h" },
                    { new Guid("7bfd79e4-4dcf-4ec4-aa12-7f9d6c74b369"), "sunny", "❄", "Charleston", "-12 °C", "26 km/h" },
                    { new Guid("7ddb8956-a48b-4f9c-9fc1-a4b895004abe"), "sunny", "❄", "Duluth", "-9 °C", "72 km/h" },
                    { new Guid("88e047e6-44ad-488b-885f-8ed1723bbc7d"), "clear", "🌞", "Duluth", "17 °C", "83 km/h" },
                    { new Guid("9138b511-741f-4e75-af2e-b85f0b4c3afd"), "misty", "🌤", "Detroit", "-7 °C", "6 km/h" },
                    { new Guid("93a7bf52-4a4f-4a79-9021-7b1ef0504a56"), "misty", "☀", "Escondido", "-3 °C", "39 km/h" },
                    { new Guid("9a0bf0f9-fd1c-4d60-a95c-214065b61d63"), "sunny", "❄", "Fitchburg", "-15 °C", "50 km/h" },
                    { new Guid("9b8ce014-efaf-4b97-a2ed-adbe2b6212ac"), "sunny", "🌤", "Brownsville", "3 °C", "67 km/h" },
                    { new Guid("b434a409-5235-45ea-9409-efef8c5cade0"), "sunny", "🌤", "Chicago", "32 °C", "29 km/h" },
                    { new Guid("ba0052eb-6a86-4afb-8e6f-98f0503f968b"), "misty", "❄", "Fontana", "-17 °C", "71 km/h" },
                    { new Guid("c5671b48-78d4-432a-bc4c-08835d738c4c"), "misty", "⚡", "El Paso", "14 °C", "57 km/h" },
                    { new Guid("c570e7f2-6ac0-4f60-801e-b27d2cce2042"), "clear", "❄", "Clearwater", "11 °C", "38 km/h" },
                    { new Guid("cf240d06-05a7-46e8-89fa-8a9384168e57"), "snowy", "☀", "Fargo", "-5 °C", "38 km/h" },
                    { new Guid("d1b4e2b9-cdd5-4b39-ab43-5444a6e7917a"), "misty", "☀", "Denver", "29 °C", "29 km/h" },
                    { new Guid("da93a53a-4188-49cd-9657-9a7bb85db29c"), "snowy", "⛅", "Davidson County", "20 °C", "50 km/h" },
                    { new Guid("e375dfc6-83ec-4155-b204-5eb8d7c510c9"), "snowy", "❄", "Davenport", "33 °C", "67 km/h" },
                    { new Guid("ea01290c-938c-41b8-a661-777ac7f463d9"), "sunny", "☀", "Cleveland", "17 °C", "67 km/h" },
                    { new Guid("f0507bdf-6038-4cc4-82ff-765e726adf9b"), "misty", "🌦", "Davidson County", "35 °C", "70 km/h" },
                    { new Guid("f162346c-0c67-4bc0-adc2-3c5f47f2fd7b"), "clear", "❄", "Burlington", "3 °C", "39 km/h" },
                    { new Guid("fc10b0d3-3206-48a5-a4e8-41f33d352dac"), "sunny", "🌦", "Fitchburg", "27 °C", "76 km/h" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weathers");
        }
    }
}
