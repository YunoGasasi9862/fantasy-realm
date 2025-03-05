﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.FantasyRealm.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FantasyUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    profilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verbiage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FantsayUserPersonalityAssociations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FantasyUserId = table.Column<int>(type: "int", nullable: false),
                    PersonalityTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantsayUserPersonalityAssociations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FantsayUserPersonalityAssociations_FantasyUsers_FantasyUserId",
                        column: x => x.FantasyUserId,
                        principalTable: "FantasyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FantsayUserPersonalityAssociations_PersonalityTypes_PersonalityTypeId",
                        column: x => x.PersonalityTypeId,
                        principalTable: "PersonalityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionChoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Choice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionChoices_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personalityAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalityTypeId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ChoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personalityAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personalityAnswers_PersonalityTypes_PersonalityTypeId",
                        column: x => x.PersonalityTypeId,
                        principalTable: "PersonalityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personalityAnswers_QuestionChoices_ChoiceId",
                        column: x => x.ChoiceId,
                        principalTable: "QuestionChoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personalityAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FantsayUserPersonalityAssociations_FantasyUserId",
                table: "FantsayUserPersonalityAssociations",
                column: "FantasyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FantsayUserPersonalityAssociations_PersonalityTypeId",
                table: "FantsayUserPersonalityAssociations",
                column: "PersonalityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_personalityAnswers_ChoiceId",
                table: "personalityAnswers",
                column: "ChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_personalityAnswers_PersonalityTypeId",
                table: "personalityAnswers",
                column: "PersonalityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_personalityAnswers_QuestionId",
                table: "personalityAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionChoices_QuestionId",
                table: "QuestionChoices",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FantsayUserPersonalityAssociations");

            migrationBuilder.DropTable(
                name: "personalityAnswers");

            migrationBuilder.DropTable(
                name: "FantasyUsers");

            migrationBuilder.DropTable(
                name: "PersonalityTypes");

            migrationBuilder.DropTable(
                name: "QuestionChoices");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
