using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gs_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eletrodomesticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Voltagem = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Marca = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Modelo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    EficienciaEnergetica = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    Cor = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Peso = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    LinkCompra = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eletrodomesticos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cafeteiras",
                columns: table => new
                {
                    IdCafeteira = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CapacidadeAgua = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Pressao = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    CapsulasCompativeis = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Tecnologia = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    EletrodomesticoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafeteiras", x => x.IdCafeteira);
                    table.ForeignKey(
                        name: "FK_Cafeteiras_Eletrodomesticos_EletrodomesticoId",
                        column: x => x.EletrodomesticoId,
                        principalTable: "Eletrodomesticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Geladeiras",
                columns: table => new
                {
                    IdGeladeira = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CapacidadeFreezerLitros = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ConsumoKwh = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    QuantidadePortas = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TipoDisplay = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    TemPortaLatas = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EletrodomesticoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geladeiras", x => x.IdGeladeira);
                    table.ForeignKey(
                        name: "FK_Geladeiras_Eletrodomesticos_EletrodomesticoId",
                        column: x => x.EletrodomesticoId,
                        principalTable: "Eletrodomesticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lavadoras",
                columns: table => new
                {
                    IdMaquina = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CapacidadeKg = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    ConsumoAgua = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    SistemaLavagem = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    VelocidadeCentrifugacaoRpm = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TemAguaQuente = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EletrodomesticoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lavadoras", x => x.IdMaquina);
                    table.ForeignKey(
                        name: "FK_Lavadoras_Eletrodomesticos_EletrodomesticoId",
                        column: x => x.EletrodomesticoId,
                        principalTable: "Eletrodomesticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Microondas",
                columns: table => new
                {
                    IdMicroondas = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PotenciaWatts = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    QuantidadeProgramas = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DiametroPrato = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Frequencia = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TemDescongelamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EletrodomesticoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Microondas", x => x.IdMicroondas);
                    table.ForeignKey(
                        name: "FK_Microondas_Eletrodomesticos_EletrodomesticoId",
                        column: x => x.EletrodomesticoId,
                        principalTable: "Eletrodomesticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventiladores",
                columns: table => new
                {
                    IdVentilador = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    QuantidadePas = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    QuantidadeVelocidades = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TipoVentilador = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    TemInclinacaoRegulavel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EletrodomesticoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventiladores", x => x.IdVentilador);
                    table.ForeignKey(
                        name: "FK_Ventiladores_Eletrodomesticos_EletrodomesticoId",
                        column: x => x.EletrodomesticoId,
                        principalTable: "Eletrodomesticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cafeteiras_EletrodomesticoId",
                table: "Cafeteiras",
                column: "EletrodomesticoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Geladeiras_EletrodomesticoId",
                table: "Geladeiras",
                column: "EletrodomesticoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lavadoras_EletrodomesticoId",
                table: "Lavadoras",
                column: "EletrodomesticoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Microondas_EletrodomesticoId",
                table: "Microondas",
                column: "EletrodomesticoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ventiladores_EletrodomesticoId",
                table: "Ventiladores",
                column: "EletrodomesticoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cafeteiras");

            migrationBuilder.DropTable(
                name: "Geladeiras");

            migrationBuilder.DropTable(
                name: "Lavadoras");

            migrationBuilder.DropTable(
                name: "Microondas");

            migrationBuilder.DropTable(
                name: "Ventiladores");

            migrationBuilder.DropTable(
                name: "Eletrodomesticos");
        }
    }
}
