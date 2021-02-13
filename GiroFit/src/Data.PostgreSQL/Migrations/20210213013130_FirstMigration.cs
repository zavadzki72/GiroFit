using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.PostgreSQL.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    time = table.Column<string>(type: "text", nullable: false),
                    break_time = table.Column<string>(type: "text", nullable: false),
                    sets = table.Column<int>(type: "integer", nullable: false),
                    frequecy = table.Column<int>(type: "integer", nullable: false),
                    dta_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dta_updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    dta_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dta_updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Train",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cover_page = table.Column<string>(type: "text", nullable: false),
                    dta_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dta_updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train", x => x.id);
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
                    dta_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dta_updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTrain",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdExercise = table.Column<int>(type: "integer", nullable: false),
                    IdTrain = table.Column<int>(type: "integer", nullable: false),
                    dta_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dta_updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTrain", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExerciseTrain_Exercise_IdExercise",
                        column: x => x.IdExercise,
                        principalTable: "Exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseTrain_Train_IdTrain",
                        column: x => x.IdTrain,
                        principalTable: "Train",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainModule",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdTrain = table.Column<int>(type: "integer", nullable: false),
                    IdModule = table.Column<int>(type: "integer", nullable: false),
                    dta_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dta_updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainModule", x => x.id);
                    table.ForeignKey(
                        name: "FK_TrainModule_Module_IdModule",
                        column: x => x.IdModule,
                        principalTable: "Module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainModule_Train_IdTrain",
                        column: x => x.IdTrain,
                        principalTable: "Train",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserModule",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dta_start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dta_end = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    is_locked = table.Column<bool>(type: "boolean", nullable: false),
                    IdModule = table.Column<int>(type: "integer", nullable: false),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    dta_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dta_updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModule", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserModule_Module_IdModule",
                        column: x => x.IdModule,
                        principalTable: "Module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserModule_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTrain",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    last_acess = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    is_finished = table.Column<bool>(type: "boolean", nullable: false),
                    IdTrain = table.Column<int>(type: "integer", nullable: false),
                    IdUserModule = table.Column<int>(type: "integer", nullable: false),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    dta_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dta_updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrain", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserTrain_Train_IdTrain",
                        column: x => x.IdTrain,
                        principalTable: "Train",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTrain_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTrain_UserModule_IdUserModule",
                        column: x => x.IdUserModule,
                        principalTable: "UserModule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserExercise",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dta_start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dta_end = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    watched = table.Column<bool>(type: "boolean", nullable: false),
                    IdExercise = table.Column<int>(type: "integer", nullable: false),
                    IdUserTrain = table.Column<int>(type: "integer", nullable: false),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    dta_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dta_updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExercise", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserExercise_Exercise_IdExercise",
                        column: x => x.IdExercise,
                        principalTable: "Exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserExercise_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserExercise_UserTrain_IdUserTrain",
                        column: x => x.IdUserTrain,
                        principalTable: "UserTrain",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTrain_IdExercise",
                table: "ExerciseTrain",
                column: "IdExercise");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTrain_IdTrain",
                table: "ExerciseTrain",
                column: "IdTrain");

            migrationBuilder.CreateIndex(
                name: "IX_TrainModule_IdModule",
                table: "TrainModule",
                column: "IdModule");

            migrationBuilder.CreateIndex(
                name: "IX_TrainModule_IdTrain",
                table: "TrainModule",
                column: "IdTrain");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercise_IdExercise",
                table: "UserExercise",
                column: "IdExercise");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercise_IdUser",
                table: "UserExercise",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercise_IdUserTrain",
                table: "UserExercise",
                column: "IdUserTrain");

            migrationBuilder.CreateIndex(
                name: "IX_UserModule_IdModule",
                table: "UserModule",
                column: "IdModule");

            migrationBuilder.CreateIndex(
                name: "IX_UserModule_IdUser",
                table: "UserModule",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrain_IdTrain",
                table: "UserTrain",
                column: "IdTrain");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrain_IdUser",
                table: "UserTrain",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrain_IdUserModule",
                table: "UserTrain",
                column: "IdUserModule");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseTrain");

            migrationBuilder.DropTable(
                name: "TrainModule");

            migrationBuilder.DropTable(
                name: "UserExercise");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "UserTrain");

            migrationBuilder.DropTable(
                name: "Train");

            migrationBuilder.DropTable(
                name: "UserModule");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
