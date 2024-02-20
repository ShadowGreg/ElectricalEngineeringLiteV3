using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectricalEngineering.Data.Entities
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseCables",
                columns: table => new
                {
                    SelfId = table.Column<string>(type: "TEXT", nullable: false),
                    CableMaterial = table.Column<int>(type: "INTEGER", nullable: false),
                    SequentialNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    CableName = table.Column<string>(type: "TEXT", nullable: true),
                    CableBrand = table.Column<string>(type: "TEXT", nullable: true),
                    CoresNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    CableCrossSection = table.Column<double>(type: "REAL", nullable: false),
                    NumberInFeeder = table.Column<int>(type: "INTEGER", nullable: false),
                    CableLength = table.Column<double>(type: "REAL", nullable: false),
                    CableVoltageLoss = table.Column<double>(type: "REAL", nullable: false),
                    CableCurrent = table.Column<double>(type: "REAL", nullable: false),
                    MaxCableCurrent = table.Column<double>(type: "REAL", nullable: false),
                    ShortCircuitCurrent = table.Column<double>(type: "REAL", nullable: false),
                    OwnerId = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseCables", x => x.SelfId);
                });

            migrationBuilder.CreateTable(
                name: "CircuitBreakers",
                columns: table => new
                {
                    SelfId = table.Column<string>(type: "TEXT", nullable: false),
                    NameOnBus = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Dimensions = table.Column<string>(type: "TEXT", nullable: true),
                    ResponseCurve = table.Column<string>(type: "TEXT", nullable: true),
                    RatedCurrent = table.Column<double>(type: "REAL", nullable: false),
                    NumberPoles = table.Column<int>(type: "INTEGER", nullable: false),
                    SwitchingCapacity = table.Column<double>(type: "REAL", nullable: false),
                    OwnerId = table.Column<string>(type: "TEXT", nullable: true),
                    SequentialNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircuitBreakers", x => x.SelfId);
                });

            migrationBuilder.CreateTable(
                name: "Consumers",
                columns: table => new
                {
                    SelfId = table.Column<string>(type: "TEXT", nullable: false),
                    TechnologicalNumber = table.Column<string>(type: "TEXT", nullable: true),
                    MechanismName = table.Column<string>(type: "TEXT", nullable: true),
                    LoadType = table.Column<int>(type: "INTEGER", nullable: false),
                    StartingCurrentMultiplicity = table.Column<double>(type: "REAL", nullable: false),
                    RatedElectricPower = table.Column<double>(type: "REAL", nullable: false),
                    UsageFactor = table.Column<double>(type: "REAL", nullable: false),
                    PowerFactor = table.Column<double>(type: "REAL", nullable: false),
                    TanPowerFactor = table.Column<double>(type: "REAL", nullable: false),
                    EfficiencyFactor = table.Column<double>(type: "REAL", nullable: false),
                    TypeGroundingSystem = table.Column<string>(type: "TEXT", nullable: true),
                    Voltage = table.Column<double>(type: "REAL", nullable: false),
                    PhaseNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberElectricalReceivers = table.Column<int>(type: "INTEGER", nullable: false),
                    HoursWorkedPerYear = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationEquipmentInstallation = table.Column<string>(type: "TEXT", nullable: true),
                    ClassificationEquipmentInstallation = table.Column<string>(type: "TEXT", nullable: true),
                    RatedPowerSquared = table.Column<double>(type: "REAL", nullable: false),
                    ReactivePower = table.Column<double>(type: "REAL", nullable: false),
                    RatedCurrent = table.Column<double>(type: "REAL", nullable: false),
                    StartingCurrent = table.Column<double>(type: "REAL", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false),
                    NumberOfElectricalReceiversInstalledInTheSwitchboard = table.Column<double>(type: "REAL", nullable: true),
                    InstalledElectricalPowerOfTheSwitchboard = table.Column<double>(type: "REAL", nullable: true),
                    ShieldUtilizationFactor = table.Column<double>(type: "REAL", nullable: true),
                    ShieldPowerFactor = table.Column<double>(type: "REAL", nullable: true),
                    AverageRatedActivePower = table.Column<double>(type: "REAL", nullable: true),
                    AverageDesignReactivePower = table.Column<double>(type: "REAL", nullable: true),
                    SquareOfTheRatedPowerOfThePanel = table.Column<double>(type: "REAL", nullable: true),
                    EquivalentNumberOfElectricalReceiversOfTheShield = table.Column<double>(type: "REAL", nullable: true),
                    DesignLoadFactor = table.Column<double>(type: "REAL", nullable: true),
                    ShieldActivePower = table.Column<double>(type: "REAL", nullable: true),
                    ReactivePowerOfThePanel = table.Column<double>(type: "REAL", nullable: true),
                    TotalPower = table.Column<double>(type: "REAL", nullable: true),
                    OwnerId = table.Column<string>(type: "TEXT", nullable: true),
                    SequentialNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumers", x => x.SelfId);
                });

            migrationBuilder.CreateTable(
                name: "BaseBusbars",
                columns: table => new
                {
                    SelfId = table.Column<string>(type: "TEXT", nullable: false),
                    BusbarName = table.Column<string>(type: "TEXT", nullable: true),
                    InstalledCapacity = table.Column<double>(type: "REAL", nullable: false),
                    RatedCapacity = table.Column<double>(type: "REAL", nullable: false),
                    PowerFactor = table.Column<double>(type: "REAL", nullable: false),
                    RatedCurrent = table.Column<double>(type: "REAL", nullable: false),
                    ShortCircuitCurrent = table.Column<double>(type: "REAL", nullable: false),
                    InputSwitchSelfId = table.Column<string>(type: "TEXT", nullable: true),
                    EmergencyСurrentInputSwitch = table.Column<double>(type: "REAL", nullable: false),
                    SectionalCircuitBreakerSelfId = table.Column<string>(type: "TEXT", nullable: true),
                    EmergencyСurrentSectionalSwitch = table.Column<double>(type: "REAL", nullable: false),
                    BaseElectricalPanelSelfId = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerId = table.Column<string>(type: "TEXT", nullable: true),
                    SequentialNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseBusbars", x => x.SelfId);
                    table.ForeignKey(
                        name: "FK_BaseBusbars_CircuitBreakers_InputSwitchSelfId",
                        column: x => x.InputSwitchSelfId,
                        principalTable: "CircuitBreakers",
                        principalColumn: "SelfId");
                    table.ForeignKey(
                        name: "FK_BaseBusbars_CircuitBreakers_SectionalCircuitBreakerSelfId",
                        column: x => x.SectionalCircuitBreakerSelfId,
                        principalTable: "CircuitBreakers",
                        principalColumn: "SelfId");
                    table.ForeignKey(
                        name: "FK_BaseBusbars_Consumers_BaseElectricalPanelSelfId",
                        column: x => x.BaseElectricalPanelSelfId,
                        principalTable: "Consumers",
                        principalColumn: "SelfId");
                });

            migrationBuilder.CreateTable(
                name: "BaseFeeders",
                columns: table => new
                {
                    SelfId = table.Column<string>(type: "TEXT", nullable: false),
                    CircuitBreakerSelfId = table.Column<string>(type: "TEXT", nullable: true),
                    CableSelfId = table.Column<string>(type: "TEXT", nullable: true),
                    ConsumerSelfId = table.Column<string>(type: "TEXT", nullable: true),
                    BaseBusbarSelfId = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerId = table.Column<string>(type: "TEXT", nullable: true),
                    SequentialNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseFeeders", x => x.SelfId);
                    table.ForeignKey(
                        name: "FK_BaseFeeders_BaseBusbars_BaseBusbarSelfId",
                        column: x => x.BaseBusbarSelfId,
                        principalTable: "BaseBusbars",
                        principalColumn: "SelfId");
                    table.ForeignKey(
                        name: "FK_BaseFeeders_BaseCables_CableSelfId",
                        column: x => x.CableSelfId,
                        principalTable: "BaseCables",
                        principalColumn: "SelfId");
                    table.ForeignKey(
                        name: "FK_BaseFeeders_CircuitBreakers_CircuitBreakerSelfId",
                        column: x => x.CircuitBreakerSelfId,
                        principalTable: "CircuitBreakers",
                        principalColumn: "SelfId");
                    table.ForeignKey(
                        name: "FK_BaseFeeders_Consumers_ConsumerSelfId",
                        column: x => x.ConsumerSelfId,
                        principalTable: "Consumers",
                        principalColumn: "SelfId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseBusbars_BaseElectricalPanelSelfId",
                table: "BaseBusbars",
                column: "BaseElectricalPanelSelfId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseBusbars_InputSwitchSelfId",
                table: "BaseBusbars",
                column: "InputSwitchSelfId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseBusbars_SectionalCircuitBreakerSelfId",
                table: "BaseBusbars",
                column: "SectionalCircuitBreakerSelfId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseFeeders_BaseBusbarSelfId",
                table: "BaseFeeders",
                column: "BaseBusbarSelfId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseFeeders_CableSelfId",
                table: "BaseFeeders",
                column: "CableSelfId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseFeeders_CircuitBreakerSelfId",
                table: "BaseFeeders",
                column: "CircuitBreakerSelfId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseFeeders_ConsumerSelfId",
                table: "BaseFeeders",
                column: "ConsumerSelfId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseFeeders");

            migrationBuilder.DropTable(
                name: "BaseBusbars");

            migrationBuilder.DropTable(
                name: "BaseCables");

            migrationBuilder.DropTable(
                name: "CircuitBreakers");

            migrationBuilder.DropTable(
                name: "Consumers");
        }
    }
}
