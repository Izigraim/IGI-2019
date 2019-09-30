using Microsoft.EntityFrameworkCore.Migrations;

namespace JobTrackingSystem.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackingTasks_Users_whoGaveId",
                table: "TrackingTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackingTasks_Users_whoTakeId",
                table: "TrackingTasks");

            migrationBuilder.DropIndex(
                name: "IX_TrackingTasks_whoGaveId",
                table: "TrackingTasks");

            migrationBuilder.DropIndex(
                name: "IX_TrackingTasks_whoTakeId",
                table: "TrackingTasks");

            migrationBuilder.DropColumn(
                name: "whoGaveId",
                table: "TrackingTasks");

            migrationBuilder.DropColumn(
                name: "whoTakeId",
                table: "TrackingTasks");

            migrationBuilder.AddColumn<string>(
                name: "whoGave",
                table: "TrackingTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "whoTake",
                table: "TrackingTasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "whoGave",
                table: "TrackingTasks");

            migrationBuilder.DropColumn(
                name: "whoTake",
                table: "TrackingTasks");

            migrationBuilder.AddColumn<int>(
                name: "whoGaveId",
                table: "TrackingTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "whoTakeId",
                table: "TrackingTasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrackingTasks_whoGaveId",
                table: "TrackingTasks",
                column: "whoGaveId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingTasks_whoTakeId",
                table: "TrackingTasks",
                column: "whoTakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackingTasks_Users_whoGaveId",
                table: "TrackingTasks",
                column: "whoGaveId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackingTasks_Users_whoTakeId",
                table: "TrackingTasks",
                column: "whoTakeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
