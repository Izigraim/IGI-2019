using Microsoft.EntityFrameworkCore.Migrations;

namespace JobTrackingSystem.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "whoGaveId",
                table: "TrackingTasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrackingTasks_whoGaveId",
                table: "TrackingTasks",
                column: "whoGaveId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackingTasks_AspNetUsers_whoGaveId",
                table: "TrackingTasks",
                column: "whoGaveId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackingTasks_AspNetUsers_whoGaveId",
                table: "TrackingTasks");

            migrationBuilder.DropIndex(
                name: "IX_TrackingTasks_whoGaveId",
                table: "TrackingTasks");

            migrationBuilder.DropColumn(
                name: "whoGaveId",
                table: "TrackingTasks");
        }
    }
}
