using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Generator.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Abbreviation = table.Column<string>(maxLength: 2, nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceKey = table.Column<string>(maxLength: 100, nullable: false),
                    Url = table.Column<string>(maxLength: 500, nullable: true),
                    Icon = table.Column<string>(maxLength: 50, nullable: true),
                    Order = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forms_Forms_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScallingMatrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScallingMatrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    AuthenticationMode = table.Column<int>(nullable: true),
                    IsSuperuser = table.Column<bool>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orchestrations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orchestrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orchestrations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    FormId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormActions_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserScalingMatrix",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(nullable: false),
                    Tolerance = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ScalingMatrixId = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserScalingMatrix", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserScalingMatrix_ScallingMatrices_ScalingMatrixId",
                        column: x => x.ScalingMatrixId,
                        principalTable: "ScallingMatrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserScalingMatrix_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    OrchestrationId = table.Column<int>(nullable: false),
                    IsCurrent = table.Column<bool>(nullable: false),
                    OrchestrationDetails = table.Column<string>(type: "xml", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Versions_Orchestrations_OrchestrationId",
                        column: x => x.OrchestrationId,
                        principalTable: "Orchestrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    FormActionId = table.Column<int>(nullable: false),
                    FormId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessRoles_FormActions_FormActionId",
                        column: x => x.FormActionId,
                        principalTable: "FormActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessRoles_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccessRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Abbreviation", "Name", "State" },
                values: new object[,]
                {
                    { 1, "AR", "ARGENTINA", 1 },
                    { 15, "VE", "VENEZUELA", 1 },
                    { 14, "EU", "UNITED STATES", 1 },
                    { 13, "DO", "REPUBLICA DOMINICANA", 1 },
                    { 12, "PR", "PUERTO RICO", 1 },
                    { 11, "PE", "PERU", 1 },
                    { 10, "PA", "PANAMA", 1 },
                    { 9, "MX", "MEXICO", 1 },
                    { 7, "SV", "EL SALVADOR", 1 },
                    { 6, "EC", "ECUADOR", 1 },
                    { 5, "CR", "COSTA RICA", 1 },
                    { 4, "CO", "COLOMBIA", 1 },
                    { 3, "CL", "CHILE", 1 },
                    { 2, "BO", "BOLIVIA", 1 },
                    { 8, "GT", "GUATEMALA", 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "State" },
                values: new object[] { 1, "Perfil con el acceso total al sistema", "Administrador", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticationMode", "FirstName", "IsSuperuser", "LastName", "Password", "State", "Username" },
                values: new object[] { 1, 1, "admin", true, "admin", "Qm6u5yaNAZnx2wwYrGpyFw==", 1, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AccessRoles_FormActionId",
                table: "AccessRoles",
                column: "FormActionId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessRoles_FormId",
                table: "AccessRoles",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessRoles_RoleId",
                table: "AccessRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_FormActions_FormId",
                table: "FormActions",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_ParentId",
                table: "Forms",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orchestrations_CountryId",
                table: "Orchestrations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserScalingMatrix_ScalingMatrixId",
                table: "UserScalingMatrix",
                column: "ScalingMatrixId");

            migrationBuilder.CreateIndex(
                name: "IX_UserScalingMatrix_UserId",
                table: "UserScalingMatrix",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Versions_OrchestrationId",
                table: "Versions",
                column: "OrchestrationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessRoles");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserScalingMatrix");

            migrationBuilder.DropTable(
                name: "Versions");

            migrationBuilder.DropTable(
                name: "FormActions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ScallingMatrices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orchestrations");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
