using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using CoreV01.Feeder;

namespace ElectricalEngineeringLiteV1.ViewModel {
    public partial class ViewModel {
        private static Selected _actual;
        private ObservableCollection<BaseConsumer> _consumers;

        public ObservableCollection<BaseConsumer> Consumers
        {
            get => _consumers;
            set
            {
                _consumers = value;
                OnPropertyChanged(nameof(Consumers));
            }
        }

        public BaseConsumer SelectedConsumer
        {
            get
            {
                var obj = _actual.Obj as BaseConsumer;
                if (obj != null)
                    return obj;
                throw new FileFormatException("Нет возможности скастить до BaseConsumer ошибка ");
            }
        }

        public object SelectedObject
        {
            get => _actual;
            set
            {
                _actual = new Selected(value);
                OnPropertyChanged("SelectedObject");
            }
        }


        public void AddConsumer(BaseConsumer consumer) {
            _consumers.Add(consumer);
            OnPropertyChanged(nameof(AddConsumer));
        }
    }


    public class Selected: ViewModelBase {
        private static readonly Dictionary<string, string> russianDictionary = new Dictionary<string, string> {
            { "BusbarName", "Наименование шины" },
            { "Cable", "Кабель" },
            { "CableBrand", "Шифр конструкции кабеля" },
            { "CableCrossSection", "Сечение жил кабеля" },
            { "CableCurrent", "Док в кабеле" },
            { "CableLength", "Длина кабеля" },
            { "CableMaterial", "Материал кабеля" },
            { "CableName", "Имя кабеля" },
            { "CableVoltageLoss", "Потеря напряжения кабеля" },
            { "CircuitBreaker", "Автоматический выключатель" },
            { "ClassificationEquipmentInstallation", "Взрывао/Пожароопасность помещения" },
            { "Consumer", "Потребитель" },
            { "CoresNumber", "Количество жил" },
            { "Dimensions", "Размеры" },
            { "EfficiencyFactor", "Коэффициент эффективности" },
            { "EmergencyСurrentInputSwitch", "Ток в аварийном режиме на вводном выключателе" },
            { "EmergencyСurrentSectionalSwitch", "Аварийный ток автоматического секционного выключателя" },
            { "Feeders", "Фидеры" },
            { "HoursWorkedPerYear", "Количество часов работы в году " },
            { "InputSwitch", "Ток короткого замыкания на секции шин" },
            { "InstalledCapacity", "Установленная мощность об., кВт" },
            { "LoadType", "Тип нагрузки" },
            { "LocationEquipmentInstallation", "Место установки оборудвоания по экспликации" },
            { "MaxCableCurrent", "Максимльно допустимый длительный ток в кабеле" },
            { "MechanismName", "Наименование механизма" },
            { "NameOnBus", "Имя на шине" },
            { "NumberElectricalReceivers", "Количество электроприёмников" },
            { "NumberInFeeder", "Количество кабелей в фидере" },
            { "NumberPoles", "Количество полюсов" },
            { "PhaseNumber", "Количество фаз" },
            { "PowerFactor", "Коэффициент мощности cosf" },
            { "RatedCapacity", "Расчётная мощность об., кВт" },
            { "RatedCurrent", "Номинальный ток" },
            { "RatedElectricPower", "Номинальная электрическая мощность кВт" },
            { "RatedPowerSquared", "Кваднат номинальной мощности " },
            { "ReactivePower", "Реактивная мощность" },
            { "ResponseCurve", "Кривая ответа" },
            { "SectionalCircuitBreaker", "Секционный выключатель" },
            { "SequentialNumber", "Порядковый номер" },
            { "ShortCircuitCurrent", "Ток короткого замыкания" },
            { "StartingCurrent", "Стартовый ток" },
            { "StartingCurrentMultiplicity", "Коэффициент пускового тока" },
            { "SwitchingCapacity", "Коммутационная емкость" },
            { "TanPowerFactor", "Тангенс коэффициента мощности " },
            { "TechnologicalNumber", "Технологический номер" },
            { "Type", "Тип" },
            { "TypeGroundingSystem", "Тип системы заземления" },
            { "UsageFactor", "Коэффициент использования" },
            { "Voltage", "Напряжение" }
        };

        public Selected(object obj) {
            Obj = obj;
            Prop = GetValues(obj);
            OnPropertyChanged(nameof(Selected));
        }

        public Dictionary<string, object> Prop { get; }

        public object Obj { get; }

        private static Dictionary<string, object> GetValues(object obj) {
            Dictionary<string, object> values = new Dictionary<string, object>();
            var type = obj.GetType();
            PropertyInfo[] fields = type.GetProperties();
            foreach (var field in fields) {
                if (field.Name == "SelfId" || field.Name == "OwnerId") break;

                string russianKey = russianDictionary.ContainsKey(field.Name)
                    ? russianDictionary[field.Name]
                    : field.Name;
                values[russianKey] = field.GetValue(obj);
            }

            return values;
        }
    }
}