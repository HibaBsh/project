using Microsoft.EntityFrameworkCore.Migrations;

namespace BookManagement.Migrations
{
    public partial class initialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Catcode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(nullable: false),
                    Lname = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    nationality_ID = table.Column<int>(nullable: false),
                    Imagepath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Authors_Nationality_nationality_ID",
                        column: x => x.nationality_ID,
                        principalTable: "Nationality",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    category_ID = table.Column<int>(nullable: false),
                    authors_ID = table.Column<int>(nullable: false),
                    Imagepath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Authors_authors_ID",
                        column: x => x.authors_ID,
                        principalTable: "Authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Category_category_ID",
                        column: x => x.category_ID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_nationality_ID",
                table: "Authors",
                column: "nationality_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_authors_ID",
                table: "Books",
                column: "authors_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_category_ID",
                table: "Books",
                column: "category_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Nationality");
        }
    }
}
