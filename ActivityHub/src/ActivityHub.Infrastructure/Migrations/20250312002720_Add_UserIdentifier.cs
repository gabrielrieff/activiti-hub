﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_UserIdentifier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserIdentifier",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIdentifier",
                table: "Users");
        }
    }
}
