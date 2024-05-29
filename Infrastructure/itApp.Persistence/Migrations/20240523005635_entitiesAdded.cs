using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace grammerGame.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entitiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnglishLevel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FamilyName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GivenName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GameProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalGamesPlayed = table.Column<int>(type: "int", nullable: false),
                    TotalCorrectAnswers = table.Column<int>(type: "int", nullable: false),
                    TotalIncorrectAnswers = table.Column<int>(type: "int", nullable: false),
                    HighestStreak = table.Column<int>(type: "int", nullable: false),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    LastGameDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameProgress_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Friends = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FriendRequests = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialData_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationPreferences = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Theme = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPreferences_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameProgress_AppUserId",
                table: "GameProgress",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialData_AppUserId",
                table: "SocialData",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_AppUserId",
                table: "UserPreferences",
                column: "AppUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameProgress");

            migrationBuilder.DropTable(
                name: "SocialData");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropColumn(
                name: "EnglishLevel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FamilyName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GivenName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "AspNetUsers");
        }
    }
}
