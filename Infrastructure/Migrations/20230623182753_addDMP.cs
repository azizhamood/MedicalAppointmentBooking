using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDMP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctorMedicalPeriodModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    MedicalId = table.Column<int>(type: "int", nullable: false),
                    Periode = table.Column<int>(type: "int", nullable: false),
                    PeroidId = table.Column<int>(type: "int", nullable: false),
                    CountBook = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctorMedicalPeriodModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_doctorMedicalPeriodModels_doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doctorMedicalPeriodModels_medical_MedicalId",
                        column: x => x.MedicalId,
                        principalTable: "medical",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doctorMedicalPeriodModels_periode_PeroidId",
                        column: x => x.PeroidId,
                        principalTable: "periode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_doctorMedicalPeriodModels_DoctorId",
                table: "doctorMedicalPeriodModels",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_doctorMedicalPeriodModels_MedicalId",
                table: "doctorMedicalPeriodModels",
                column: "MedicalId");

            migrationBuilder.CreateIndex(
                name: "IX_doctorMedicalPeriodModels_PeroidId",
                table: "doctorMedicalPeriodModels",
                column: "PeroidId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doctorMedicalPeriodModels");
        }
    }
}
