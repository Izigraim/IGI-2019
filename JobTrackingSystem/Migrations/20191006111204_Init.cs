using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobTrackingSystem.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    nickname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackingTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    whoGaveId = table.Column<int>(nullable: true),
                    whoTakeId = table.Column<int>(nullable: true),
                    taskName = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    dateOfTaking = table.Column<DateTime>(nullable: false),
                    dateOfFinishing = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackingTasks_Users_whoGaveId",
                        column: x => x.whoGaveId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrackingTasks_Users_whoTakeId",
                        column: x => x.whoTakeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackingTasks_whoGaveId",
                table: "TrackingTasks",
                column: "whoGaveId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingTasks_whoTakeId",
                table: "TrackingTasks",
                column: "whoTakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackingTasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
