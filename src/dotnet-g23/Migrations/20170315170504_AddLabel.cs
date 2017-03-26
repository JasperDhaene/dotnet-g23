using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_g23.Migrations
{
    public partial class AddLabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Labels",
                table => new
                {
                    LabelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyForeignKey = table.Column<int>(nullable: false),
                    GroupForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.LabelId);
                    table.ForeignKey(
                        "FK_Labels_Companies_CompanyForeignKey",
                        x => x.CompanyForeignKey,
                        "Companies",
                        "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Labels_Groups_GroupForeignKey",
                        x => x.GroupForeignKey,
                        "Groups",
                        "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Labels_CompanyForeignKey",
                "Labels",
                "CompanyForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Labels_GroupForeignKey",
                "Labels",
                "GroupForeignKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Labels");
        }
    }
}