using Microsoft.EntityFrameworkCore.Migrations;

namespace Mazindlu.Migrations
{
    public partial class RollbackMigrationDecember12_2020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookProviders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    ShortBio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyProviders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    ShortBio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookProviderPictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    URI = table.Column<string>(nullable: false),
                    BookProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookProviderPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookProviderPictures_BookProviders_BookProviderId",
                        column: x => x.BookProviderId,
                        principalTable: "BookProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Format = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    ContactNo = table.Column<string>(nullable: true),
                    BookProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_BookProviders_BookProviderId",
                        column: x => x.BookProviderId,
                        principalTable: "BookProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    PropertyProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyProviders_PropertyProviderId",
                        column: x => x.PropertyProviderId,
                        principalTable: "PropertyProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyProviderPictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    URI = table.Column<string>(nullable: false),
                    PropertyProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyProviderPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyProviderPictures_PropertyProviders_PropertyProviderId",
                        column: x => x.PropertyProviderId,
                        principalTable: "PropertyProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookPictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    URI = table.Column<string>(nullable: false),
                    BookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookPictures_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyPictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    URI = table.Column<string>(nullable: false),
                    PropertyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyPictures_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookPictures_BookId",
                table: "BookPictures",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookProviderPictures_BookProviderId",
                table: "BookProviderPictures",
                column: "BookProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookProviderId",
                table: "Books",
                column: "BookProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyProviderId",
                table: "Properties",
                column: "PropertyProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyPictures_PropertyId",
                table: "PropertyPictures",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyProviderPictures_PropertyProviderId",
                table: "PropertyProviderPictures",
                column: "PropertyProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookPictures");

            migrationBuilder.DropTable(
                name: "BookProviderPictures");

            migrationBuilder.DropTable(
                name: "PropertyPictures");

            migrationBuilder.DropTable(
                name: "PropertyProviderPictures");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "BookProviders");

            migrationBuilder.DropTable(
                name: "PropertyProviders");
        }
    }
}
