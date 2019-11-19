using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusHearingDetect.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: false),
                    UserAge = table.Column<int>(nullable: false),
                    Answer1 = table.Column<bool>(nullable: false),
                    Answer2 = table.Column<bool>(nullable: false),
                    Answer3 = table.Column<bool>(nullable: false),
                    Answer4 = table.Column<bool>(nullable: false),
                    Answer5 = table.Column<bool>(nullable: false),
                    Answer6 = table.Column<bool>(nullable: false),
                    Answer7 = table.Column<bool>(nullable: false),
                    Answer8 = table.Column<bool>(nullable: false),
                    Answer9 = table.Column<bool>(nullable: false),
                    Answer10 = table.Column<bool>(nullable: false),
                    Answer11 = table.Column<bool>(nullable: false),
                    Answer12 = table.Column<bool>(nullable: false),
                    Answer13 = table.Column<bool>(nullable: false),
                    Answer14 = table.Column<bool>(nullable: false),
                    Answer15 = table.Column<bool>(nullable: false),
                    Answer16 = table.Column<bool>(nullable: false),
                    Answer17 = table.Column<bool>(nullable: false),
                    Answer18 = table.Column<bool>(nullable: false),
                    Answer19 = table.Column<bool>(nullable: false),
                    Answer20 = table.Column<bool>(nullable: false),
                    Result = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
