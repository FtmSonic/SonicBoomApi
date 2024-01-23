﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SonicBoomOrm.Migrations
{
    /// <inheritdoc />
    public partial class UniqueAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Address",
                table: "Accounts",
                column: "Address",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_Address",
                table: "Accounts");
        }
    }
}
