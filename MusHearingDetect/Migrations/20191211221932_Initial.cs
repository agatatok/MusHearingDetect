using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusHearingDetect.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    UserAge = table.Column<int>(nullable: false),
                    Answer1 = table.Column<bool>(nullable: true),
                    Answer2 = table.Column<bool>(nullable: true),
                    Answer3 = table.Column<bool>(nullable: true),
                    Answer4 = table.Column<bool>(nullable: true),
                    Answer5 = table.Column<bool>(nullable: true),
                    Answer6 = table.Column<bool>(nullable: true),
                    Answer7 = table.Column<bool>(nullable: true),
                    Answer8 = table.Column<bool>(nullable: true),
                    Answer9 = table.Column<bool>(nullable: true),
                    Answer10 = table.Column<bool>(nullable: true),
                    Answer11 = table.Column<bool>(nullable: true),
                    Answer12 = table.Column<bool>(nullable: true),
                    Answer13 = table.Column<bool>(nullable: true),
                    Answer14 = table.Column<bool>(nullable: true),
                    Answer15 = table.Column<bool>(nullable: true),
                    Answer16 = table.Column<bool>(nullable: true),
                    Answer17 = table.Column<bool>(nullable: true),
                    Answer18 = table.Column<bool>(nullable: true),
                    Answer19 = table.Column<bool>(nullable: true),
                    Answer20 = table.Column<bool>(nullable: true),
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
