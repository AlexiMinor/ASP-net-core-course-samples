using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsAggregator.DAL.Core.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_RssSources_RssSourceId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_RssSourceId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "RssSourceId",
                table: "News");

            migrationBuilder.AddColumn<string>(
                name: "Body2",
                table: "News",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_RssSourseId",
                table: "News",
                column: "RssSourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_RssSources_RssSourseId",
                table: "News",
                column: "RssSourseId",
                principalTable: "RssSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_RssSources_RssSourseId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_RssSourseId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Body2",
                table: "News");

            migrationBuilder.AddColumn<Guid>(
                name: "RssSourceId",
                table: "News",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_RssSourceId",
                table: "News",
                column: "RssSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_RssSources_RssSourceId",
                table: "News",
                column: "RssSourceId",
                principalTable: "RssSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
