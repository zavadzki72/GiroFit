using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.PostgreSQL.Migrations
{
    public partial class UpDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseType",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    url_video = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateModule",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    is_locked = table.Column<bool>(type: "boolean", nullable: false),
                    user_sexo = table.Column<int>(type: "integer", nullable: false),
                    user_level = table.Column<int>(type: "integer", nullable: false),
                    user_objective = table.Column<int>(type: "integer", nullable: false),
                    user_frenquency = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateModule", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    height = table.Column<decimal>(type: "numeric", nullable: false),
                    weight = table.Column<decimal>(type: "numeric", nullable: false),
                    objective = table.Column<int>(type: "integer", nullable: false),
                    nickname = table.Column<string>(type: "text", nullable: false),
                    sexo = table.Column<int>(type: "integer", nullable: false),
                    frequency = table.Column<int>(type: "integer", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    flg_inativo = table.Column<bool>(type: "boolean", nullable: false),
                    dta_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dta_updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateTrain",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cover_page = table.Column<string>(type: "text", nullable: false),
                    IdTemplateModule = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateTrain", x => x.id);
                    table.ForeignKey(
                        name: "FK_TemplateTrain_TemplateModule_IdTemplateModule",
                        column: x => x.IdTemplateModule,
                        principalTable: "TemplateModule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dta_start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    dta_end = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    IdTemplateModule = table.Column<int>(type: "integer", nullable: false),
                    dta_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dta_updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.id);
                    table.ForeignKey(
                        name: "FK_Module_TemplateModule_IdTemplateModule",
                        column: x => x.IdTemplateModule,
                        principalTable: "TemplateModule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Module_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemplateExercise",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    frequency = table.Column<int>(type: "integer", nullable: false),
                    sets = table.Column<int>(type: "integer", nullable: false),
                    time = table.Column<int>(type: "integer", nullable: false),
                    break_time = table.Column<int>(type: "integer", nullable: false),
                    IdTemplateTrain = table.Column<int>(type: "integer", nullable: false),
                    IdExerciseType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateExercise", x => x.id);
                    table.ForeignKey(
                        name: "FK_TemplateExercise_ExerciseType_IdExerciseType",
                        column: x => x.IdExerciseType,
                        principalTable: "ExerciseType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemplateExercise_TemplateTrain_IdTemplateTrain",
                        column: x => x.IdTemplateTrain,
                        principalTable: "TemplateTrain",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Train",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dta_start = table.Column<bool>(type: "boolean", nullable: false),
                    dta_finished = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IdModule = table.Column<int>(type: "integer", nullable: false),
                    IdTemplateTrain = table.Column<int>(type: "integer", nullable: false),
                    dta_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dta_updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train", x => x.id);
                    table.ForeignKey(
                        name: "FK_Train_Module_IdModule",
                        column: x => x.IdModule,
                        principalTable: "Module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Train_TemplateTrain_IdTemplateTrain",
                        column: x => x.IdTemplateTrain,
                        principalTable: "TemplateTrain",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_watched = table.Column<bool>(type: "boolean", nullable: false),
                    IdTrain = table.Column<int>(type: "integer", nullable: false),
                    IdTemplateExercise = table.Column<int>(type: "integer", nullable: false),
                    dta_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dta_updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.id);
                    table.ForeignKey(
                        name: "FK_Exercise_TemplateExercise_IdTemplateExercise",
                        column: x => x.IdTemplateExercise,
                        principalTable: "TemplateExercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercise_Train_IdTrain",
                        column: x => x.IdTrain,
                        principalTable: "Train",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_IdTemplateExercise",
                table: "Exercise",
                column: "IdTemplateExercise");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_IdTrain",
                table: "Exercise",
                column: "IdTrain");

            migrationBuilder.CreateIndex(
                name: "IX_Module_IdTemplateModule",
                table: "Module",
                column: "IdTemplateModule");

            migrationBuilder.CreateIndex(
                name: "IX_Module_IdUser",
                table: "Module",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateExercise_IdExerciseType",
                table: "TemplateExercise",
                column: "IdExerciseType");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateExercise_IdTemplateTrain",
                table: "TemplateExercise",
                column: "IdTemplateTrain");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTrain_IdTemplateModule",
                table: "TemplateTrain",
                column: "IdTemplateModule");

            migrationBuilder.CreateIndex(
                name: "IX_Train_IdModule",
                table: "Train",
                column: "IdModule");

            migrationBuilder.CreateIndex(
                name: "IX_Train_IdTemplateTrain",
                table: "Train",
                column: "IdTemplateTrain");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "TemplateExercise");

            migrationBuilder.DropTable(
                name: "Train");

            migrationBuilder.DropTable(
                name: "ExerciseType");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "TemplateTrain");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TemplateModule");
        }
    }
}
