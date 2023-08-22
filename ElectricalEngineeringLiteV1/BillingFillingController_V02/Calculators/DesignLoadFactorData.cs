using System.Collections.Generic;
using System.Linq;

namespace BillingFillingController.Calculators {
    internal class DesignLoadFactorData {
        private readonly Dictionary<int, Dictionary<double, double>> _data =
            new Dictionary<int, Dictionary<double, double>>() {
                {
                    1, new Dictionary<double, double>() {
                        { 0.1, 8.00 },
                        { 0.15, 5.33 },
                        { 0.2, 4.00 },
                        { 0.3, 2.67 },
                        { 0.4, 2.00 },
                        { 0.5, 1.60 },
                        { 0.6, 1.33 },
                        { 0.7, 1.14 },
                        { 0.8, 1.00 }
                    }
                }, {
                    2, new Dictionary<double, double>() {
                        { 0.1, 6.22 },
                        { 0.15, 4.33 },
                        { 0.2, 3.39 },
                        { 0.3, 2.45 },
                        { 0.4, 1.98 },
                        { 0.5, 1.60 },
                        { 0.6, 1.33 },
                        { 0.7, 1.14 },
                        { 0.8, 1.00 }
                    }
                }, {
                    3, new Dictionary<double, double>() {
                        { 0.1, 4.05 },
                        { 0.15, 2.89 },
                        { 0.2, 2.31 },
                        { 0.3, 1.74 },
                        { 0.4, 1.45 },
                        { 0.5, 1.34 },
                        { 0.6, 1.22 },
                        { 0.7, 1.14 },
                        { 0.8, 1.00 }
                    }
                }, {
                    4, new Dictionary<double, double>() {
                        { 0.1, 3.24 },
                        { 0.15, 2.35 },
                        { 0.2, 1.91 },
                        { 0.3, 1.47 },
                        { 0.4, 1.25 },
                        { 0.5, 1.21 },
                        { 0.6, 1.12 },
                        { 0.7, 1.06 },
                        { 0.8, 1.00 }
                    }
                }, {
                    5, new Dictionary<double, double>() {
                        { 0.1, 2.84 },
                        { 0.15, 2.09 },
                        { 0.2, 1.72 },
                        { 0.3, 1.35 },
                        { 0.4, 1.16 },
                        { 0.5, 1.16 },
                        { 0.6, 1.08 },
                        { 0.7, 1.03 },
                        { 0.8, 1.00 }
                    }
                }, {
                    6, new Dictionary<double, double>() {
                        { 0.1, 2.64 },
                        { 0.15, 2.96 },
                        { 0.2, 1.62 },
                        { 0.3, 1.28 },
                        { 0.4, 1.11 },
                        { 0.5, 1.13 },
                        { 0.6, 1.06 },
                        { 0.7, 1.01 },
                        { 0.8, 1.00 }
                    }
                }, {
                    7, new Dictionary<double, double>() {
                        { 0.1, 2.49 },
                        { 0.15, 1.86 },
                        { 0.2, 1.54 },
                        { 0.3, 1.23 },
                        { 0.4, 1.12 },
                        { 0.5, 1.10 },
                        { 0.6, 1.04 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    8, new Dictionary<double, double>() {
                        { 0.1, 2.37 },
                        { 0.15, 1.78 },
                        { 0.2, 1.48 },
                        { 0.3, 1.19 },
                        { 0.4, 1.10 },
                        { 0.5, 1.08 },
                        { 0.6, 1.02 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    9, new Dictionary<double, double>() {
                        { 0.1, 2.27 },
                        { 0.15, 1.71 },
                        { 0.2, 1.43 },
                        { 0.3, 1.16 },
                        { 0.4, 1.09 },
                        { 0.5, 1.07 },
                        { 0.6, 1.01 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    10, new Dictionary<double, double>() {
                        { 0.1, 2.18 },
                        { 0.15, 1.65 },
                        { 0.2, 1.39 },
                        { 0.3, 1.13 },
                        { 0.4, 1.07 },
                        { 0.5, 1.05 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    11, new Dictionary<double, double>() {
                        { 0.1, 2.11 },
                        { 0.15, 1.61 },
                        { 0.2, 1.35 },
                        { 0.3, 1.1 },
                        { 0.4, 1.06 },
                        { 0.5, 1.04 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    12, new Dictionary<double, double>() {
                        { 0.1, 2.04 },
                        { 0.15, 1.56 },
                        { 0.2, 1.32 },
                        { 0.3, 1.08 },
                        { 0.4, 1.05 },
                        { 0.5, 1.03 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    13, new Dictionary<double, double>() {
                        { 0.1, 1.99 },
                        { 0.15, 1.52 },
                        { 0.2, 1.29 },
                        { 0.3, 1.06 },
                        { 0.4, 1.04 },
                        { 0.5, 1.01 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    14, new Dictionary<double, double>() {
                        { 0.1, 1.94 },
                        { 0.15, 1.49 },
                        { 0.2, 1.27 },
                        { 0.3, 1.05 },
                        { 0.4, 1.02 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    15, new Dictionary<double, double>() {
                        { 0.1, 1.89 },
                        { 0.15, 1.46 },
                        { 0.2, 1.25 },
                        { 0.3, 1.03 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    16, new Dictionary<double, double>() {
                        { 0.1, 1.85 },
                        { 0.15, 1.43 },
                        { 0.2, 1.23 },
                        { 0.3, 1.02 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    17, new Dictionary<double, double>() {
                        { 0.1, 1.81 },
                        { 0.15, 1.41 },
                        { 0.2, 1.21 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    18, new Dictionary<double, double>() {
                        { 0.1, 1.78 },
                        { 0.15, 1.39 },
                        { 0.2, 1.19 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    19, new Dictionary<double, double>() {
                        { 0.1, 1.75 },
                        { 0.15, 1.36 },
                        { 0.2, 1.17 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    20, new Dictionary<double, double>() {
                        { 0.1, 1.72 },
                        { 0.15, 1.35 },
                        { 0.2, 1.16 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    21, new Dictionary<double, double>() {
                        { 0.1, 1.69 },
                        { 0.15, 1.33 },
                        { 0.2, 1.15 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    22, new Dictionary<double, double>() {
                        { 0.1, 1.67 },
                        { 0.15, 1.31 },
                        { 0.2, 1.13 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    23, new Dictionary<double, double>() {
                        { 0.1, 1.64 },
                        { 0.15, 1.30 },
                        { 0.2, 1.12 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    24, new Dictionary<double, double>() {
                        { 0.1, 1.62 },
                        { 0.15, 1.28 },
                        { 0.2, 1.11 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    25, new Dictionary<double, double>() {
                        { 0.1, 1.6 },
                        { 0.15, 1.27 },
                        { 0.2, 1.1 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    30, new Dictionary<double, double>() {
                        { 0.1, 1.51 },
                        { 0.15, 1.21 },
                        { 0.2, 1.05 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    35, new Dictionary<double, double>() {
                        { 0.1, 1.44 },
                        { 0.15, 1.16 },
                        { 0.2, 1.00 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    40, new Dictionary<double, double>() {
                        { 0.1, 1.4 },
                        { 0.15, 1.13 },
                        { 0.2, 1.00 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    45, new Dictionary<double, double>() {
                        { 0.1, 1.35 },
                        { 0.15, 1.1 },
                        { 0.2, 1.00 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    50, new Dictionary<double, double>() {
                        { 0.1, 1.3 },
                        { 0.15, 1.07 },
                        { 0.2, 1.00 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    60, new Dictionary<double, double>() {
                        { 0.1, 1.25 },
                        { 0.15, 1.03 },
                        { 0.2, 1.00 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    70, new Dictionary<double, double>() {
                        { 0.1, 1.20 },
                        { 0.15, 1.00 },
                        { 0.2, 1.00 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    80, new Dictionary<double, double>() {
                        { 0.1, 1.16 },
                        { 0.15, 1.00 },
                        { 0.2, 1.00 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    90, new Dictionary<double, double>() {
                        { 0.1, 1.13 },
                        { 0.15, 1.00 },
                        { 0.2, 1.00 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                }, {
                    100, new Dictionary<double, double>() {
                        { 0.1, 1.1 },
                        { 0.15, 1.00 },
                        { 0.2, 1.00 },
                        { 0.3, 1.00 },
                        { 0.4, 1.00 },
                        { 0.5, 1.00 },
                        { 0.6, 1.00 },
                        { 0.7, 1.00 },
                        { 0.8, 1.00 }
                    }
                },
            };


        public double GetData(int equivalentNumberOfElectricalReceivers, double busUtilizationFactor) {
            List<int> foreignKeys = _data.Keys.ToList();
            int desiredForeignKey = 0;
            for (int i = 0; i < foreignKeys.Count; i++) {
                if (equivalentNumberOfElectricalReceivers > foreignKeys[i] &&
                    equivalentNumberOfElectricalReceivers < foreignKeys[i + 1]) {
                    desiredForeignKey = foreignKeys[i];
                    break;
                }

                if (equivalentNumberOfElectricalReceivers != foreignKeys[i]) continue;
                desiredForeignKey = foreignKeys[i];
                break;
            }

            List<double> internalKeys = _data[desiredForeignKey].Keys.ToList();
            double desiredInternalKey = 0;
            for (int i = 1; i < internalKeys.Count; i++) {
                if (busUtilizationFactor > internalKeys[i-1] &&
                    busUtilizationFactor < internalKeys[i]) {
                    desiredInternalKey = internalKeys[i];
                    break;
                }
            }

            if (desiredInternalKey == 0)
                desiredInternalKey = internalKeys[internalKeys.Count - 1];

            var temp = _data[desiredForeignKey][desiredInternalKey];
            return temp;
        }
    }
}