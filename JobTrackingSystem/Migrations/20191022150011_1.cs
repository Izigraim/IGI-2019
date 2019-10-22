using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobTrackingSystem.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackingTasks_TakingTasks_TakingTasksId",
                table: "TrackingTasks");

            migrationBuilder.DropTable(
                name: "TakingTasks");

            migrationBuilder.DropIndex(
                name: "IX_TrackingTasks_TakingTasksId",
                table: "TrackingTasks");

            migrationBuilder.DropColumn(
                name: "TakingTaskId",
                table: "TrackingTasks");

            migrationBuilder.DropColumn(
                name: "TakingTasksId",
                table: "TrackingTasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TakingTaskId",
                table: "TrackingTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TakingTasksId",
                table: "TrackingTasks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TakingTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakingTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TakingTasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackingTasks_TakingTasksId",
                table: "TrackingTasks",
                column: "TakingTasksId");

            migrationBuilder.CreateIndex(
                name: "IX_TakingTasks_UserId",
                table: "TakingTasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackingTasks_TakingTasks_TakingTasksId",
                table: "TrackingTasks",
                column: "TakingTasksId",
                principalTable: "TakingTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
