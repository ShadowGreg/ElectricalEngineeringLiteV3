using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ElectricalEngineering.Domain.Feeder;

namespace BillingFillingController.Contrlollers.Cable {
    public class CableData {
        private readonly Dictionary<double, double> _aluminumCrossSectionCurrent = new Dictionary<double, double> {
            { 2.5, 21 },
            { 4, 29 },
            { 6, 37 },
            { 10, 50 },
            { 16, 67 },
            { 25, 87 },
            { 35, 106 },
            { 50, 126 },
            { 70, 161 },
            { 95, 197 },
            { 120, 229 },
            { 150, 261 },
            { 185, 302 },
            { 240, 359 }
        };

        private readonly Dictionary<double, double> _copperCrossSectionCurrent = new Dictionary<double, double> {
            { 1.5, 21 },
            { 2.5, 27 },
            { 4, 36 },
            { 6, 46 },
            { 10, 63 },
            { 16, 84 },
            { 25, 112 },
            { 35, 137 },
            { 50, 167 },
            { 70, 211 },
            { 95, 261 },
            { 120, 302 },
            { 150, 346 },
            { 185, 397 },
            { 240, 472 }
        };

        private readonly Dictionary<double, CableResistanceCharacteristics> _copperResistanceCharacteristics =
            new Dictionary<double, CableResistanceCharacteristics> {
                {
                    1.5, new CableResistanceCharacteristics {
                        R0 = 12.1, X03 = 0.126, X04 = 0.134, R0Loop = 28.4789784
                    }
                }, {
                    2.5, new CableResistanceCharacteristics {
                        R0 = 7.41, X03 = 0.113, X04 = 0.1, R0Loop = 17.4043222
                    }
                }, {
                    4, new CableResistanceCharacteristics {
                        R0 = 4.61, X03 = 0.092, X04 = 0.098, R0Loop = 10.8502554
                    }
                }, {
                    6, new CableResistanceCharacteristics {
                        R0 = 3.08, X03 = 0.087, X04 = 0.094, R0Loop = 7.249194499
                    }
                }, {
                    10, new CableResistanceCharacteristics {
                        R0 = 1.83, X03 = 0.082, X04 = 0.088, R0Loop = 4.307151277
                    }
                }, {
                    16, new CableResistanceCharacteristics {
                        R0 = 1.15, X03 = 0.078, X04 = 0.084, R0Loop = 2.706679764
                    }
                }, {
                    25, new CableResistanceCharacteristics {
                        R0 = 0.727, X03 = 0.062, X04 = 0.072, R0Loop = 1.711092338
                    }
                }, {
                    35, new CableResistanceCharacteristics {
                        R0 = 0.524, X03 = 0.061, X04 = 0.068, R0Loop = 1.233304519
                    }
                }, {
                    50, new CableResistanceCharacteristics {
                        R0 = 0.387, X03 = 0.06, X04 = 0.066, R0Loop = 0.910856582
                    }
                }, {
                    70, new CableResistanceCharacteristics {
                        R0 = 0.268, X03 = 0.059, X04 = 0.065, R0Loop = 0.630774067
                    }
                }, {
                    95, new CableResistanceCharacteristics {
                        R0 = 0.193, X03 = 0.057, X04 = 0.064, R0Loop = 0.454251473
                    }
                }, {
                    120, new CableResistanceCharacteristics {
                        R0 = 0.153, X03 = 0.057, X04 = 0.064, R0Loop = 0.36010609
                    }
                }, {
                    150, new CableResistanceCharacteristics {
                        R0 = 0.124, X03 = 0.056, X04 = 0.063, R0Loop = 0.291850688
                    }
                }, {
                    185, new CableResistanceCharacteristics {
                        R0 = 0.0991, X03 = 0.056, X04 = 0.063, R0Loop = 0.233245187
                    }
                }, {
                    240, new CableResistanceCharacteristics {
                        R0 = 0.0754, X03 = 0.055, X04 = 0.063, R0Loop = 0.177464047
                    }
                }
            };

        private Dictionary<double, CableResistanceCharacteristics> _aluminumFResistanceCharacteristics =
            new Dictionary<double, CableResistanceCharacteristics> {
                {
                    2.5, new CableResistanceCharacteristics {
                        R0 = 12.1, X03 = 0.113, X04 = 0.1, R0Loop = 28.59112903
                    }
                }, {
                    4, new CableResistanceCharacteristics {
                        R0 = 7.41, X03 = 0.092, X04 = 0.098, R0Loop = 17.5091129
                    }
                }, {
                    6, new CableResistanceCharacteristics {
                        R0 = 5.11, X03 = 0.087, X04 = 0.094, R0Loop = 12.07443548
                    }
                }, {
                    10, new CableResistanceCharacteristics {
                        R0 = 3.08, X03 = 0.082, X04 = 0.088, R0Loop = 7.277741935
                    }
                }, {
                    16, new CableResistanceCharacteristics {
                        R0 = 1.91, X03 = 0.078, X04 = 0.084, R0Loop = 4.513145161
                    }
                }, {
                    25, new CableResistanceCharacteristics {
                        R0 = 1.2, X03 = 0.062, X04 = 0.072, R0Loop = 2.835483871
                    }
                }, {
                    35, new CableResistanceCharacteristics {
                        R0 = 0.868, X03 = 0.061, X04 = 0.068, R0Loop = 2.051
                    }
                }, {
                    50, new CableResistanceCharacteristics {
                        R0 = 0.641, X03 = 0.06, X04 = 0.066, R0Loop = 1.514620968
                    }
                }, {
                    70, new CableResistanceCharacteristics {
                        R0 = 0.443, X03 = 0.059, X04 = 0.065, R0Loop = 1.046766129
                    }
                }, {
                    95, new CableResistanceCharacteristics {
                        R0 = 0.32, X03 = 0.057, X04 = 0.064, R0Loop = 0.756129032
                    }
                }, {
                    120, new CableResistanceCharacteristics {
                        R0 = 0.253, X03 = 0.057, X04 = 0.064, R0Loop = 0.597814516
                    }
                }, {
                    150, new CableResistanceCharacteristics {
                        R0 = 0.206, X03 = 0.056, X04 = 0.063, R0Loop = 0.486758065
                    }
                }, {
                    185, new CableResistanceCharacteristics {
                        R0 = 0.164, X03 = 0.056, X04 = 0.063, R0Loop = 0.387516129
                    }
                }, {
                    240, new CableResistanceCharacteristics {
                        R0 = 0.125, X03 = 0.055, X04 = 0.063, R0Loop = 0.295362903
                    }
                }
            };
    }

    public class CableFillController {
        private readonly double _cableLength;
        private readonly BaseConsumer _consumer;
        private BaseCable _cable;
        private double _maxCableCurrent;

        public CableFillController(BaseConsumer consumer, double cableLength) {
            _consumer = consumer;
            _cableLength = cableLength;
            _cable = new BaseCable();
            _cableData = new CableData();
        }

        public BaseCable GetCableValue(double maxVoltageDrop) {
            _cable = new BaseCable {
                SequentialNumber = _consumer.SequentialNumber,
                CableMaterial = Material.Copper,
                CableLength = _cableLength,
                CableName = _consumer.TechnologicalNumber + "-H1",
                CableBrand = "ВВГнг-",
                CoresNumber = GetCoresNumber(_consumer.Voltage),
                CableCrossSection = GetCableCrossSection(_consumer, maxVoltageDrop),
                CableCurrent = _consumer.RatedCurrent,
                NumberInFeeder = _consumer.SequentialNumber,
                MaxCableCurrent = _maxCableCurrent
            };
            return _cable;
        }

        private double GetCableCrossSection(BaseConsumer consumer, double maxVoltageDrop) {
            double crossSectionKey = GetCrossSectionKey(consumer.RatedCurrent, _cable.CableMaterial);
            if (VoltageDropCheck(crossSectionKey, maxVoltageDrop))
                return crossSectionKey;
            return GetNextCrossSectionKey(crossSectionKey);

            double GetNextCrossSectionKey(double sectionKey) {
                double nextKey = double.MinValue;
                List<double> keys = _copperCrossSectionCurrent.Keys.ToList();
                int index = keys.IndexOf(sectionKey);
                if (index < keys.Count - 1) return keys[index + 1];

                throw new DataException("GetNextCrossSectionKey вышли за пределы данных");
            }
        }

        private bool VoltageDropCheck(double crossSectionKey, double maxVoltageDrop) {
            double deltaVoltage = double.MaxValue;
            switch (_cable.CableMaterial) {
                case Material.Aluminum:
                    deltaVoltage = AluminiumDropCheck(crossSectionKey);
                    _cable.CableVoltageLoss = deltaVoltage;
                    break;
                case Material.Copper:
                    deltaVoltage = CopperDropCheck(crossSectionKey);
                    _cable.CableVoltageLoss = deltaVoltage;
                    break;
            }

            double AluminiumDropCheck(double sectionKey) {
                return VoltageDependence(_aluminumFResistanceCharacteristics[sectionKey]);
            }

            double CopperDropCheck(double sectionKey) {
                return VoltageDependence(_aluminumFResistanceCharacteristics[sectionKey]);
            }

            double VoltageDependence(CableResistanceCharacteristics resistanceCharacteristic) {
                if (_consumer.Voltage < 380)
                    return _consumer.RatedCurrent * 2 * (resistanceCharacteristic.R0 + resistanceCharacteristic.X03);

                if (_consumer.Voltage >= 380)
                    return Math.Sqrt(3) * _consumer.RatedCurrent *
                        (resistanceCharacteristic.R0 + resistanceCharacteristic.X04) / _consumer.Voltage;

                throw new DataException("Ошибка в методе GetCrossSectionKey Выход за рамеки парметров");
            }

            if (deltaVoltage > maxVoltageDrop) return false;

            return true;
        }


        private double GetCrossSectionKey(double consumerRatedCurrent, Material cableCableMaterial) {
            if (cableCableMaterial == Material.Copper) return GetCopperCoresKey(consumerRatedCurrent);

            if (cableCableMaterial == Material.Aluminum) return GetAluminumCoresKey(consumerRatedCurrent);

            throw new DataException("Ошибка в методе GetCrossSectionKey Выход за рамеки парметров");
        }

        private double GetAluminumCoresKey(double consumerRatedCurrent) {
            return GetKey(consumerRatedCurrent, _aluminumCrossSectionCurrent);
        }

        private double GetCopperCoresKey(double consumerRatedCurrent) {
            return GetKey(consumerRatedCurrent, _copperCrossSectionCurrent);
        }

        private double GetKey(double consumerRatedCurrent, Dictionary<double, double> dictionary) {
            double MaxKey(double key, double value) {
                double d;
                double maxValue1;
                d = key;
                maxValue1 = value;
                _maxCableCurrent = maxValue1;
                return d;
            }

            double maxKey = 0;
            double maxValue = double.MaxValue;
            List<double> keys = new List<double>(dictionary.Keys);
            for (int i = 1; i < keys.Count; i++) {
                double key = keys[i];
                double value = dictionary[key];
                if (value > consumerRatedCurrent && i < 3) return MaxKey(key, value);

                if (value > consumerRatedCurrent && consumerRatedCurrent > dictionary[keys[i - 1]])
                    return MaxKey(key, value);
            }

            throw new DataException("Ошибка в методе GetKey");
        }


        private int GetCoresNumber(double consumerVoltage) {
            return consumerVoltage < 380 ? 3 : 5;
        }

        #region BaseData

        private readonly Dictionary<double, double> _copperCrossSectionCurrent = new Dictionary<double, double> {
            { 1.5, 21 },
            { 2.5, 27 },
            { 4, 36 },
            { 6, 46 },
            { 10, 63 },
            { 16, 84 },
            { 25, 112 },
            { 35, 137 },
            { 50, 167 },
            { 70, 211 },
            { 95, 261 },
            { 120, 302 },
            { 150, 346 },
            { 185, 397 },
            { 240, 472 }
        };

        private readonly Dictionary<double, double> _aluminumCrossSectionCurrent = new Dictionary<double, double> {
            { 2.5, 21 },
            { 4, 29 },
            { 6, 37 },
            { 10, 50 },
            { 16, 67 },
            { 25, 87 },
            { 35, 106 },
            { 50, 126 },
            { 70, 161 },
            { 95, 197 },
            { 120, 229 },
            { 150, 261 },
            { 185, 302 },
            { 240, 359 }
        };

        private readonly Dictionary<double, CableResistanceCharacteristics> _copperResistanceCharacteristics =
            new Dictionary<double, CableResistanceCharacteristics> {
                {
                    1.5, new CableResistanceCharacteristics {
                        R0 = 12.1, X03 = 0.126, X04 = 0.134, R0Loop = 28.4789784
                    }
                }, {
                    2.5, new CableResistanceCharacteristics {
                        R0 = 7.41, X03 = 0.113, X04 = 0.1, R0Loop = 17.4043222
                    }
                }, {
                    4, new CableResistanceCharacteristics {
                        R0 = 4.61, X03 = 0.092, X04 = 0.098, R0Loop = 10.8502554
                    }
                }, {
                    6, new CableResistanceCharacteristics {
                        R0 = 3.08, X03 = 0.087, X04 = 0.094, R0Loop = 7.249194499
                    }
                }, {
                    10, new CableResistanceCharacteristics {
                        R0 = 1.83, X03 = 0.082, X04 = 0.088, R0Loop = 4.307151277
                    }
                }, {
                    16, new CableResistanceCharacteristics {
                        R0 = 1.15, X03 = 0.078, X04 = 0.084, R0Loop = 2.706679764
                    }
                }, {
                    25, new CableResistanceCharacteristics {
                        R0 = 0.727, X03 = 0.062, X04 = 0.072, R0Loop = 1.711092338
                    }
                }, {
                    35, new CableResistanceCharacteristics {
                        R0 = 0.524, X03 = 0.061, X04 = 0.068, R0Loop = 1.233304519
                    }
                }, {
                    50, new CableResistanceCharacteristics {
                        R0 = 0.387, X03 = 0.06, X04 = 0.066, R0Loop = 0.910856582
                    }
                }, {
                    70, new CableResistanceCharacteristics {
                        R0 = 0.268, X03 = 0.059, X04 = 0.065, R0Loop = 0.630774067
                    }
                }, {
                    95, new CableResistanceCharacteristics {
                        R0 = 0.193, X03 = 0.057, X04 = 0.064, R0Loop = 0.454251473
                    }
                }, {
                    120, new CableResistanceCharacteristics {
                        R0 = 0.153, X03 = 0.057, X04 = 0.064, R0Loop = 0.36010609
                    }
                }, {
                    150, new CableResistanceCharacteristics {
                        R0 = 0.124, X03 = 0.056, X04 = 0.063, R0Loop = 0.291850688
                    }
                }, {
                    185, new CableResistanceCharacteristics {
                        R0 = 0.0991, X03 = 0.056, X04 = 0.063, R0Loop = 0.233245187
                    }
                }, {
                    240, new CableResistanceCharacteristics {
                        R0 = 0.0754, X03 = 0.055, X04 = 0.063, R0Loop = 0.177464047
                    }
                }
            };

        private readonly Dictionary<double, CableResistanceCharacteristics> _aluminumFResistanceCharacteristics =
            new Dictionary<double, CableResistanceCharacteristics> {
                {
                    2.5, new CableResistanceCharacteristics {
                        R0 = 12.1, X03 = 0.113, X04 = 0.1, R0Loop = 28.59112903
                    }
                }, {
                    4, new CableResistanceCharacteristics {
                        R0 = 7.41, X03 = 0.092, X04 = 0.098, R0Loop = 17.5091129
                    }
                }, {
                    6, new CableResistanceCharacteristics {
                        R0 = 5.11, X03 = 0.087, X04 = 0.094, R0Loop = 12.07443548
                    }
                }, {
                    10, new CableResistanceCharacteristics {
                        R0 = 3.08, X03 = 0.082, X04 = 0.088, R0Loop = 7.277741935
                    }
                }, {
                    16, new CableResistanceCharacteristics {
                        R0 = 1.91, X03 = 0.078, X04 = 0.084, R0Loop = 4.513145161
                    }
                }, {
                    25, new CableResistanceCharacteristics {
                        R0 = 1.2, X03 = 0.062, X04 = 0.072, R0Loop = 2.835483871
                    }
                }, {
                    35, new CableResistanceCharacteristics {
                        R0 = 0.868, X03 = 0.061, X04 = 0.068, R0Loop = 2.051
                    }
                }, {
                    50, new CableResistanceCharacteristics {
                        R0 = 0.641, X03 = 0.06, X04 = 0.066, R0Loop = 1.514620968
                    }
                }, {
                    70, new CableResistanceCharacteristics {
                        R0 = 0.443, X03 = 0.059, X04 = 0.065, R0Loop = 1.046766129
                    }
                }, {
                    95, new CableResistanceCharacteristics {
                        R0 = 0.32, X03 = 0.057, X04 = 0.064, R0Loop = 0.756129032
                    }
                }, {
                    120, new CableResistanceCharacteristics {
                        R0 = 0.253, X03 = 0.057, X04 = 0.064, R0Loop = 0.597814516
                    }
                }, {
                    150, new CableResistanceCharacteristics {
                        R0 = 0.206, X03 = 0.056, X04 = 0.063, R0Loop = 0.486758065
                    }
                }, {
                    185, new CableResistanceCharacteristics {
                        R0 = 0.164, X03 = 0.056, X04 = 0.063, R0Loop = 0.387516129
                    }
                }, {
                    240, new CableResistanceCharacteristics {
                        R0 = 0.125, X03 = 0.055, X04 = 0.063, R0Loop = 0.295362903
                    }
                }
            };

        private readonly CableData _cableData;

        #endregion
    }
}