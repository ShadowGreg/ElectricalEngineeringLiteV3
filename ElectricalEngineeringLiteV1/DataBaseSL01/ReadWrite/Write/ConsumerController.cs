using System;
using System.Data.SQLite;
using CoreV01.Feeder;

namespace DataBaseSL01.ReadWrite.Write {
    public class ConsumerController {
        private readonly SqLiteHelper _dbHelper;
        private readonly string _databaseFile;
        private readonly string _connectionString;

        public ConsumerController(string databaseFile) {
            _databaseFile = databaseFile;
            _connectionString = $"Data Source={databaseFile};Version=3;";
            _dbHelper = new SqLiteHelper(databaseFile);
            _dbHelper.CreateDatabase<BaseConsumer>();
        }

        private bool ConsumerExists(string selfId) {
            using (var connection = new SQLiteConnection(_connectionString)) {
                connection.Open();

                string selectQuery = $"SELECT COUNT(*) FROM {nameof(BaseConsumer)} WHERE SelfId = '{selfId}'";

                using (var command = new SQLiteCommand(selectQuery, connection)) {
                    command.Parameters.AddWithValue("@SelfId", selfId);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        public void UpdateConsumer(BaseConsumer consumer) {
            using (var connection = new SQLiteConnection(_connectionString)) {
                connection.Open();

                string updateQuery =
                    $"UPDATE {nameof(BaseConsumer)} SET " +
                    $"TechnologicalNumber = @TechnologicalNumber, " +
                    $"MechanismName = @MechanismName, " +
                    $"LoadType = @LoadType, " +
                    $"StartingCurrentMultiplicity = @StartingCurrentMultiplicity, " +
                    $"OwnerId = @OwnerId, " +
                    $"RatedElectricPower = @RatedElectricPower, " +
                    $"UsageFactor = @UsageFactor, " +
                    $"PowerFactor = @PowerFactor, " +
                    $"TanPowerFactor = @TanPowerFactor, " +
                    $"EfficiencyFactor = @EfficiencyFactor, " +
                    $"TypeGroundingSystem = @TypeGroundingSystem, " +
                    $"Voltage = @Voltage, " +
                    $"PhaseNumber = @PhaseNumber, " +
                    $"NumberElectricalReceivers = @NumberElectricalReceivers, " +
                    $"HoursWorkedPerYear = @HoursWorkedPerYear, " +
                    $"LocationEquipmentInstallation = @LocationEquipmentInstallation, " +
                    $"ClassificationEquipmentInstallation = @ClassificationEquipmentInstallation, " +
                    $"RatedPowerSquared = @RatedPowerSquared, " +
                    $"ReactivePower = @ReactivePower, " +
                    $"RatedCurrent = @RatedCurrent, " +
                    $"StartingCurrent = @StartingCurrent " +
                    $"WHERE SelfId = @SelfId";

                using (var command = new SQLiteCommand(updateQuery, connection)) {
                    command.Parameters.AddWithValue("@TechnologicalNumber", consumer.TechnologicalNumber);
                    command.Parameters.AddWithValue("@MechanismName", consumer.MechanismName);
                    command.Parameters.AddWithValue("@LoadType", consumer.LoadType.ToString());
                    command.Parameters.AddWithValue("@StartingCurrentMultiplicity",
                        consumer.StartingCurrentMultiplicity);
                    command.Parameters.AddWithValue("@SelfId", consumer.SelfId);
                    command.Parameters.AddWithValue("@OwnerId", consumer.OwnerId);
                    command.Parameters.AddWithValue("@RatedElectricPower", consumer.RatedElectricPower);
                    command.Parameters.AddWithValue("@UsageFactor", consumer.UsageFactor);
                    command.Parameters.AddWithValue("@PowerFactor", consumer.PowerFactor);
                    command.Parameters.AddWithValue("@TanPowerFactor", consumer.TanPowerFactor);
                    command.Parameters.AddWithValue("@EfficiencyFactor", consumer.EfficiencyFactor);
                    command.Parameters.AddWithValue("@TypeGroundingSystem", consumer.TypeGroundingSystem);
                    command.Parameters.AddWithValue("@Voltage", consumer.Voltage);
                    command.Parameters.AddWithValue("@PhaseNumber", consumer.PhaseNumber);
                    command.Parameters.AddWithValue("@NumberElectricalReceivers", consumer.NumberElectricalReceivers);
                    command.Parameters.AddWithValue("@HoursWorkedPerYear", consumer.HoursWorkedPerYear);
                    command.Parameters.AddWithValue("@LocationEquipmentInstallation",
                        consumer.LocationEquipmentInstallation);
                    command.Parameters.AddWithValue("@ClassificationEquipmentInstallation",
                        consumer.ClassificationEquipmentInstallation);
                    command.Parameters.AddWithValue("@RatedPowerSquared", consumer.RatedPowerSquared);
                    command.Parameters.AddWithValue("@ReactivePower", consumer.ReactivePower);
                    command.Parameters.AddWithValue("@RatedCurrent", consumer.RatedCurrent);
                    command.Parameters.AddWithValue("@StartingCurrent", consumer.StartingCurrent);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void WriteConsumer(BaseConsumer consumer) {
            if (!ConsumerExists(consumer.SelfId)) {
                using (var connection = new SQLiteConnection(_connectionString)) {
                    connection.Open();

                    string insertQuery =
                        $"INSERT INTO {nameof(BaseConsumer)} (" +
                        $"SelfId, OwnerId, TechnologicalNumber, MechanismName, LoadType, StartingCurrentMultiplicity," +
                        $" RatedElectricPower, UsageFactor, PowerFactor, TanPowerFactor, EfficiencyFactor, " +
                        $"TypeGroundingSystem, Voltage, PhaseNumber, NumberElectricalReceivers, HoursWorkedPerYear, " +
                        $"LocationEquipmentInstallation, ClassificationEquipmentInstallation, RatedPowerSquared, " +
                        $"ReactivePower, RatedCurrent, StartingCurrent) " +
                        $"VALUES (" +
                        $"@SelfId, @OwnerId,  @TechnologicalNumber, @MechanismName, @LoadType, " +
                        $"@StartingCurrentMultiplicity, @RatedElectricPower, @UsageFactor, @PowerFactor, @TanPowerFactor," +
                        $" @EfficiencyFactor, @TypeGroundingSystem, @Voltage, @PhaseNumber, @NumberElectricalReceivers, " +
                        $"@HoursWorkedPerYear, @LocationEquipmentInstallation, @ClassificationEquipmentInstallation, " +
                        $"@RatedPowerSquared, @ReactivePower, @RatedCurrent, @StartingCurrent)";

                    using (var command = new SQLiteCommand(insertQuery, connection)) {
                        command.Parameters.AddWithValue("@TechnologicalNumber", consumer.TechnologicalNumber);
                        command.Parameters.AddWithValue("@MechanismName", consumer.MechanismName);
                        command.Parameters.AddWithValue("@LoadType", consumer.LoadType.ToString());
                        command.Parameters.AddWithValue("@StartingCurrentMultiplicity",
                            consumer.StartingCurrentMultiplicity);
                        command.Parameters.AddWithValue("@SelfId", consumer.SelfId);
                        command.Parameters.AddWithValue("@OwnerId", consumer.OwnerId);
                        command.Parameters.AddWithValue("@RatedElectricPower", consumer.RatedElectricPower);
                        command.Parameters.AddWithValue("@UsageFactor", consumer.UsageFactor);
                        command.Parameters.AddWithValue("@PowerFactor", consumer.PowerFactor);
                        command.Parameters.AddWithValue("@TanPowerFactor", consumer.TanPowerFactor);
                        command.Parameters.AddWithValue("@EfficiencyFactor", consumer.EfficiencyFactor);
                        command.Parameters.AddWithValue("@TypeGroundingSystem", consumer.TypeGroundingSystem);
                        command.Parameters.AddWithValue("@Voltage", consumer.Voltage);
                        command.Parameters.AddWithValue("@PhaseNumber", consumer.PhaseNumber);
                        command.Parameters.AddWithValue("@NumberElectricalReceivers",
                            consumer.NumberElectricalReceivers);
                        command.Parameters.AddWithValue("@HoursWorkedPerYear", consumer.HoursWorkedPerYear);
                        command.Parameters.AddWithValue("@LocationEquipmentInstallation",
                            consumer.LocationEquipmentInstallation);
                        command.Parameters.AddWithValue("@ClassificationEquipmentInstallation",
                            consumer.ClassificationEquipmentInstallation);
                        command.Parameters.AddWithValue("@RatedPowerSquared", consumer.RatedPowerSquared);
                        command.Parameters.AddWithValue("@ReactivePower", consumer.ReactivePower);
                        command.Parameters.AddWithValue("@RatedCurrent", consumer.RatedCurrent);
                        command.Parameters.AddWithValue("@StartingCurrent", consumer.StartingCurrent);

                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            else {
                UpdateConsumer(consumer);
            }
        }

        public BaseConsumer ReadConsumer(string id) {
            using (var connection = new SQLiteConnection(_connectionString)) {
                connection.Open();


                string selectQuery = $"SELECT * FROM {nameof(BaseConsumer)} WHERE SelfId = '{id}'";

                using (var command = new SQLiteCommand(selectQuery, connection)) {
                    using (var reader = command.ExecuteReader()) {
                        if (reader.FieldCount != 0) {
                            reader.Read();
                            BaseConsumer consumer = new BaseConsumer();
                            consumer.SelfId = reader.GetString(reader.GetOrdinal("SelfId"));
                            consumer.TechnologicalNumber = reader.GetString(reader.GetOrdinal("TechnologicalNumber"));
                            consumer.MechanismName = reader.GetString(reader.GetOrdinal("MechanismName"));
                            consumer.LoadType = (ConsumerType)Enum.Parse(typeof(ConsumerType),
                                reader.GetString(reader.GetOrdinal("LoadType")));
                            consumer.StartingCurrentMultiplicity =
                                reader.GetDouble(reader.GetOrdinal("StartingCurrentMultiplicity"));
                            consumer.RatedElectricPower = reader.GetDouble(reader.GetOrdinal("RatedElectricPower"));
                            consumer.UsageFactor = reader.GetDouble(reader.GetOrdinal("UsageFactor"));
                            consumer.PowerFactor = reader.GetDouble(reader.GetOrdinal("PowerFactor"));
                            consumer.TanPowerFactor = reader.GetDouble(reader.GetOrdinal("TanPowerFactor"));
                            consumer.EfficiencyFactor = reader.GetDouble(reader.GetOrdinal("EfficiencyFactor"));
                            consumer.TypeGroundingSystem = reader.GetString(reader.GetOrdinal("TypeGroundingSystem"));
                            consumer.Voltage = reader.GetDouble(reader.GetOrdinal("Voltage"));
                            consumer.PhaseNumber = reader.GetInt32(reader.GetOrdinal("PhaseNumber"));
                            consumer.NumberElectricalReceivers =
                                reader.GetInt32(reader.GetOrdinal("NumberElectricalReceivers"));
                            consumer.HoursWorkedPerYear =
                                (int)reader.GetDouble(reader.GetOrdinal("HoursWorkedPerYear"));
                            consumer.LocationEquipmentInstallation =
                                reader.GetString(reader.GetOrdinal("LocationEquipmentInstallation"));
                            consumer.ClassificationEquipmentInstallation =
                                reader.GetString(reader.GetOrdinal("ClassificationEquipmentInstallation"));
                            consumer.RatedPowerSquared = reader.GetDouble(reader.GetOrdinal("RatedPowerSquared"));
                            consumer.ReactivePower = reader.GetDouble(reader.GetOrdinal("ReactivePower"));
                            consumer.RatedCurrent = reader.GetDouble(reader.GetOrdinal("RatedCurrent"));
                            consumer.StartingCurrent = reader.GetDouble(reader.GetOrdinal("StartingCurrent"));

                            return consumer;
                        }
                    }
                }

                connection.Close();
            }

            return null;
        }
    }
}