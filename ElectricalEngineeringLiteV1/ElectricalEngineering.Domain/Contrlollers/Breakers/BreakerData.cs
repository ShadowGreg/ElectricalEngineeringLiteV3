using ElectricalEngineering.Domain.Feeder;

namespace ElectricalEngineering.Domain.Contrlollers.Breakers {
    public class BreakerData {
        public readonly Dictionary<double, BaseCircuitBreaker> _singlePolesBreakerData =
            new Dictionary<double, BaseCircuitBreaker> {
                { 6, new BaseCircuitBreaker { RatedCurrent = 6, NumberPoles = 1 } },
                { 8, new BaseCircuitBreaker { RatedCurrent = 8, NumberPoles = 1 } },
                { 10, new BaseCircuitBreaker { RatedCurrent = 10, NumberPoles = 1 } },
                { 13, new BaseCircuitBreaker { RatedCurrent = 13, NumberPoles = 1 } },
                { 16, new BaseCircuitBreaker { RatedCurrent = 16, NumberPoles = 1 } },
                { 20, new BaseCircuitBreaker { RatedCurrent = 20, NumberPoles = 1 } },
                { 25, new BaseCircuitBreaker { RatedCurrent = 25, NumberPoles = 1 } },
                { 32, new BaseCircuitBreaker { RatedCurrent = 32, NumberPoles = 1 } },
                { 40, new BaseCircuitBreaker { RatedCurrent = 40, NumberPoles = 1 } },
                { 50, new BaseCircuitBreaker { RatedCurrent = 50, NumberPoles = 1 } },
                { 63, new BaseCircuitBreaker { RatedCurrent = 63, NumberPoles = 1 } },
                { 80, new BaseCircuitBreaker { RatedCurrent = 80, NumberPoles = 1 } },
                { 100, new BaseCircuitBreaker { RatedCurrent = 100, NumberPoles = 1 } },
                { 125, new BaseCircuitBreaker { RatedCurrent = 125, NumberPoles = 1 } }
            };

        public readonly Dictionary<double, BaseCircuitBreaker> _theePolesBreakerData =
            new Dictionary<double, BaseCircuitBreaker> {
                { 6, new BaseCircuitBreaker { RatedCurrent = 6 } },
                { 8, new BaseCircuitBreaker { RatedCurrent = 8 } },
                { 10, new BaseCircuitBreaker { RatedCurrent = 10 } },
                { 13, new BaseCircuitBreaker { RatedCurrent = 13 } },
                { 16, new BaseCircuitBreaker { RatedCurrent = 16 } },
                { 20, new BaseCircuitBreaker { RatedCurrent = 20 } },
                { 25, new BaseCircuitBreaker { RatedCurrent = 25 } },
                { 32, new BaseCircuitBreaker { RatedCurrent = 32 } },
                { 40, new BaseCircuitBreaker { RatedCurrent = 40 } },
                { 50, new BaseCircuitBreaker { RatedCurrent = 50 } },
                { 63, new BaseCircuitBreaker { RatedCurrent = 63 } },
                { 80, new BaseCircuitBreaker { RatedCurrent = 80 } },
                { 100, new BaseCircuitBreaker { RatedCurrent = 100 } },
                { 125, new BaseCircuitBreaker { RatedCurrent = 125 } },
                { 160, new BaseCircuitBreaker { RatedCurrent = 160 } },
                { 200, new BaseCircuitBreaker { RatedCurrent = 200 } },
                { 250, new BaseCircuitBreaker { RatedCurrent = 250 } },
                { 630, new BaseCircuitBreaker { RatedCurrent = 630 } },
                { 800, new BaseCircuitBreaker { RatedCurrent = 800 } },
                { 1250, new BaseCircuitBreaker { RatedCurrent = 1250 } }
            };
    }
}