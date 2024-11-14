using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gs_DotNet.Migrations
{
    public partial class UpdatedBooleanToString2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GS_Eletrodomesticos",
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
                    table.PrimaryKey("PK_GS_Eletrodomesticos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_Cafeteiras",
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
                    table.PrimaryKey("PK_GS_Cafeteiras", x => x.IdCafeteira);
                    table.ForeignKey(
                        name: "FK_GS_Cafeteiras_GS_Eletrodomesticos_GS_EletrodomesticoId",
                        column: x => x.EletrodomesticoId,
                        principalTable: "GS_Eletrodomesticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GS_Geladeiras",
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
                    table.PrimaryKey("PK_GS_Geladeiras", x => x.IdGeladeira);
                    table.ForeignKey(
                        name: "FK_GS_Geladeiras_GS_Eletrodomesticos_GS_EletrodomesticoId",
                        column: x => x.EletrodomesticoId,
                        principalTable: "GS_Eletrodomesticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GS_Lavadoras",
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
                    table.PrimaryKey("PK_GS_Lavadoras", x => x.IdMaquina);
                    table.ForeignKey(
                        name: "FK_GS_Lavadoras_GS_Eletrodomesticos_GS_EletrodomesticoId",
                        column: x => x.EletrodomesticoId,
                        principalTable: "GS_Eletrodomesticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GS_Microondas",
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
                    table.PrimaryKey("PK_GS_Microondas", x => x.IdMicroondas);
                    table.ForeignKey(
                        name: "FK_GS_Microondas_GS_Eletrodomesticos_GS_EletrodomesticoId",
                        column: x => x.EletrodomesticoId,
                        principalTable: "GS_Eletrodomesticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GS_Ventiladores",
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
                    table.PrimaryKey("PK_GS_Ventiladores", x => x.IdVentilador);
                    table.ForeignKey(
                        name: "FK_GS_Ventiladores_GS_Eletrodomesticos_GS_EletrodomesticoId",
                        column: x => x.EletrodomesticoId,
                        principalTable: "GS_Eletrodomesticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Atualizando os índices para refletir o nome correto das tabelas
            migrationBuilder.CreateIndex(
                name: "IX_GS_Cafeteiras_EletrodomesticoId",
                table: "GS_Cafeteiras",
                column: "EletrodomesticoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GS_Geladeiras_EletrodomesticoId",
                table: "GS_Geladeiras",
                column: "EletrodomesticoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GS_Lavadoras_EletrodomesticoId",
                table: "GS_Lavadoras",
                column: "EletrodomesticoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GS_Microondas_EletrodomesticoId",
                table: "GS_Microondas",
                column: "EletrodomesticoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GS_Ventiladores_EletrodomesticoId",
                table: "GS_Ventiladores",
                column: "EletrodomesticoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GS_Cafeteiras");

            migrationBuilder.DropTable(
                name: "GS_Geladeiras");

            migrationBuilder.DropTable(
                name: "GS_Lavadoras");

            migrationBuilder.DropTable(
                name: "GS_Microondas");

            migrationBuilder.DropTable(
                name: "GS_Ventiladores");

            migrationBuilder.DropTable(
                name: "GS_Eletrodomesticos");
        }
    }
}
