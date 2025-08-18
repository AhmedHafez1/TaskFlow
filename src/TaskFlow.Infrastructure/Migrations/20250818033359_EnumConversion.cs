using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EnumConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
        ALTER TABLE ""TaskItems""
        ALTER COLUMN ""TaskPriority"" TYPE integer
        USING CASE ""TaskPriority""
            WHEN 'Low' THEN 0
            WHEN 'Medium' THEN 1
            WHEN 'High' THEN 2
            WHEN 'Critical' THEN 3
        END;
    "
            );

            migrationBuilder.Sql(
                @"
        ALTER TABLE ""TaskItems""
        ALTER COLUMN ""Status"" TYPE integer
        USING CASE ""Status""
            WHEN 'ToDo' THEN 0
            WHEN 'InProgress' THEN 1
            WHEN 'Postponed' THEN 2
            WHEN 'Done' THEN 3
        END;
    "
            );

            migrationBuilder.Sql(
                @"
        ALTER TABLE ""Projects""
        ALTER COLUMN ""Status"" TYPE integer
        USING CASE ""Status""
            WHEN 'Active' THEN 0
            WHEN 'Completed' THEN 1
            WHEN 'Archived' THEN 2
        END;
    "
            );

            migrationBuilder.Sql(
                @"
        ALTER TABLE ""ProjectMembers""
        ALTER COLUMN ""Role"" TYPE integer
        USING CASE ""Role""
            WHEN 'Member' THEN 0
            WHEN 'Admin' THEN 1
            WHEN 'Owner' THEN 2
        END;
    "
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaskPriority",
                table: "TaskItems",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer"
            );

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TaskItems",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer"
            );

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Projects",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer"
            );

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "ProjectMembers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer"
            );
        }
    }
}
