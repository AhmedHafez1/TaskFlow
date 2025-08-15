using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Auth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskComment_TaskItems_TaskItemId",
                table: "TaskComment");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskComment_Users_AuthorId",
                table: "TaskComment");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Users_AssigneeId",
                table: "TaskItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskComment",
                table: "TaskComment");

            migrationBuilder.DropColumn(
                name: "JoinedAt",
                table: "ProjectMembers");

            migrationBuilder.RenameTable(
                name: "TaskComment",
                newName: "TaskComments");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TaskItems",
                newName: "Title");

            migrationBuilder.RenameIndex(
                name: "IX_TaskComment_TaskItemId",
                table: "TaskComments",
                newName: "IX_TaskComments_TaskItemId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskComment_AuthorId",
                table: "TaskComments",
                newName: "IX_TaskComments_AuthorId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastLogin",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "AssigneeId",
                table: "TaskItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CompletedAt",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskComments",
                table: "TaskComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_TaskItems_TaskItemId",
                table: "TaskComments",
                column: "TaskItemId",
                principalTable: "TaskItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_Users_AuthorId",
                table: "TaskComments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Users_AssigneeId",
                table: "TaskItems",
                column: "AssigneeId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskComments_TaskItems_TaskItemId",
                table: "TaskComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskComments_Users_AuthorId",
                table: "TaskComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Users_AssigneeId",
                table: "TaskItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskComments",
                table: "TaskComments");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "TaskComments",
                newName: "TaskComment");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TaskItems",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_TaskComments_TaskItemId",
                table: "TaskComment",
                newName: "IX_TaskComment_TaskItemId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskComments_AuthorId",
                table: "TaskComment",
                newName: "IX_TaskComment_AuthorId");

            migrationBuilder.AlterColumn<int>(
                name: "AssigneeId",
                table: "TaskItems",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "JoinedAt",
                table: "ProjectMembers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskComment",
                table: "TaskComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComment_TaskItems_TaskItemId",
                table: "TaskComment",
                column: "TaskItemId",
                principalTable: "TaskItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComment_Users_AuthorId",
                table: "TaskComment",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Users_AssigneeId",
                table: "TaskItems",
                column: "AssigneeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
