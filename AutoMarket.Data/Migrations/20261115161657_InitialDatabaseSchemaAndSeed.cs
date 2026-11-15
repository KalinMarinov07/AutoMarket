using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoMarket.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseSchemaAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarListings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: false),
                    ManufactureMonth = table.Column<int>(type: "int", nullable: true),
                    ManufactureYear = table.Column<int>(type: "int", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    EngineType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarListings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarListings_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Audi" },
                    { 2, "BMW" },
                    { 3, "Mercedes-Benz" },
                    { 4, "Volkswagen" },
                    { 5, "Toyota" },
                    { 6, "Honda" },
                    { 7, "Ford" },
                    { 8, "Opel" },
                    { 9, "Skoda" },
                    { 10, "Peugeot" },
                    { 11, "Renault" },
                    { 12, "Hyundai" },
                    { 13, "Kia" },
                    { 14, "Mazda" },
                    { 15, "Volvo" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "A1" },
                    { 2, 1, "A3" },
                    { 3, 1, "A4" },
                    { 4, 1, "A5" },
                    { 5, 1, "A6" },
                    { 6, 1, "A7" },
                    { 7, 1, "A8" },
                    { 8, 1, "Q3" },
                    { 9, 1, "Q5" },
                    { 10, 1, "Q7" },
                    { 11, 2, "1 Series" },
                    { 12, 2, "2 Series" },
                    { 13, 2, "3 Series" },
                    { 14, 2, "4 Series" },
                    { 15, 2, "5 Series" },
                    { 16, 2, "7 Series" },
                    { 17, 2, "X1" },
                    { 18, 2, "X3" },
                    { 19, 2, "X5" },
                    { 20, 2, "X6" },
                    { 21, 3, "A-Class" },
                    { 22, 3, "B-Class" },
                    { 23, 3, "C-Class" },
                    { 24, 3, "E-Class" },
                    { 25, 3, "S-Class" },
                    { 26, 3, "CLA" },
                    { 27, 3, "CLS" },
                    { 28, 3, "GLA" },
                    { 29, 3, "GLC" },
                    { 30, 3, "GLE" },
                    { 31, 4, "Golf" },
                    { 32, 4, "Polo" },
                    { 33, 4, "Passat" },
                    { 34, 4, "Arteon" },
                    { 35, 4, "Tiguan" },
                    { 36, 4, "Touareg" },
                    { 37, 4, "T-Roc" },
                    { 38, 4, "Touran" },
                    { 39, 4, "Jetta" },
                    { 40, 4, "ID.4" },
                    { 41, 5, "Corolla" },
                    { 42, 5, "Yaris" },
                    { 43, 5, "Camry" },
                    { 44, 5, "Prius" },
                    { 45, 5, "RAV4" },
                    { 46, 5, "C-HR" },
                    { 47, 5, "Land Cruiser" },
                    { 48, 5, "Aygo" },
                    { 49, 5, "Avensis" },
                    { 50, 5, "Hilux" },
                    { 51, 6, "Civic" },
                    { 52, 6, "Accord" },
                    { 53, 6, "CR-V" },
                    { 54, 6, "HR-V" },
                    { 55, 6, "Jazz" },
                    { 56, 6, "Prelude" },
                    { 57, 6, "CR-Z" },
                    { 58, 6, "Insight" },
                    { 59, 6, "S2000" },
                    { 60, 6, "e" },
                    { 61, 7, "Fiesta" },
                    { 62, 7, "Focus" },
                    { 63, 7, "Mondeo" },
                    { 64, 7, "Kuga" },
                    { 65, 7, "Puma" },
                    { 66, 7, "Mustang" },
                    { 67, 7, "Explorer" },
                    { 68, 7, "Edge" },
                    { 69, 7, "S-Max" },
                    { 70, 7, "Galaxy" },
                    { 71, 8, "Astra" },
                    { 72, 8, "Corsa" },
                    { 73, 8, "Insignia" },
                    { 74, 8, "Vectra" },
                    { 75, 8, "Zafira" },
                    { 76, 8, "Mokka" },
                    { 77, 8, "Crossland" },
                    { 78, 8, "Grandland" },
                    { 79, 8, "Meriva" },
                    { 80, 8, "Adam" },
                    { 81, 9, "Fabia" },
                    { 82, 9, "Octavia" },
                    { 83, 9, "Superb" },
                    { 84, 9, "Scala" },
                    { 85, 9, "Kamiq" },
                    { 86, 9, "Karoq" },
                    { 87, 9, "Kodiaq" },
                    { 88, 9, "Rapid" },
                    { 89, 9, "Yeti" },
                    { 90, 9, "Enyaq" },
                    { 91, 10, "108" },
                    { 92, 10, "208" },
                    { 93, 10, "308" },
                    { 94, 10, "408" },
                    { 95, 10, "508" },
                    { 96, 10, "2008" },
                    { 97, 10, "3008" },
                    { 98, 10, "5008" },
                    { 99, 10, "206" },
                    { 100, 10, "407" },
                    { 101, 11, "Clio" },
                    { 102, 11, "Megane" },
                    { 103, 11, "Laguna" },
                    { 104, 11, "Talisman" },
                    { 105, 11, "Captur" },
                    { 106, 11, "Kadjar" },
                    { 107, 11, "Koleos" },
                    { 108, 11, "Scenic" },
                    { 109, 11, "Espace" },
                    { 110, 11, "Zoe" },
                    { 111, 12, "i10" },
                    { 112, 12, "i20" },
                    { 113, 12, "i30" },
                    { 114, 12, "i40" },
                    { 115, 12, "Elantra" },
                    { 116, 12, "Sonata" },
                    { 117, 12, "Tucson" },
                    { 118, 12, "Santa Fe" },
                    { 119, 12, "Kona" },
                    { 120, 12, "Ioniq 5" },
                    { 121, 13, "Picanto" },
                    { 122, 13, "Rio" },
                    { 123, 13, "Ceed" },
                    { 124, 13, "ProCeed" },
                    { 125, 13, "Sportage" },
                    { 126, 13, "Sorento" },
                    { 127, 13, "Stonic" },
                    { 128, 13, "Niro" },
                    { 129, 13, "Optima" },
                    { 130, 13, "EV6" },
                    { 131, 14, "Mazda2" },
                    { 132, 14, "Mazda3" },
                    { 133, 14, "Mazda6" },
                    { 134, 14, "CX-3" },
                    { 135, 14, "CX-30" },
                    { 136, 14, "CX-5" },
                    { 137, 14, "CX-60" },
                    { 138, 14, "CX-9" },
                    { 139, 14, "MX-5" },
                    { 140, 14, "RX-8" },
                    { 141, 15, "S40" },
                    { 142, 15, "S60" },
                    { 143, 15, "S80" },
                    { 144, 15, "S90" },
                    { 145, 15, "V40" },
                    { 146, 15, "V60" },
                    { 147, 15, "V90" },
                    { 148, 15, "XC40" },
                    { 149, 15, "XC60" },
                    { 150, 15, "XC90" }
                });

            migrationBuilder.InsertData(
                table: "CarListings",
                columns: new[] { "Id", "Description", "EngineType", "ManufactureMonth", "ManufactureYear", "Mileage", "ModelId", "Price", "VehicleType" },
                values: new object[] { 1, null, 1, null, 2016, 180000, 1, 10000m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CarListings_ModelId",
                table: "CarListings",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarListings");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
