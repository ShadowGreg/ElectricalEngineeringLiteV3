using System.Collections.Generic;
using System.Collections.ObjectModel;
using CoreV01.Feeder;
using CoreV01.Properties;

namespace ElectricalEngineeringLiteV1.View.CenterFrame.DistributionNetworkTable {
    public class Node {
        public DBDependence BaseNode { get; }
        public ObservableCollection<Node> Children { get; }
        public string Description { get; } = "";

        public Node(BaseConsumer consumer) {
            BaseNode = consumer;
            Description = "электроприёмник: " + consumer.TechnologicalNumber;
            Children = null;
        }

        public Node(BaseCircuitBreaker breaker) {
            BaseNode = breaker;
            Description = "автомат: " + breaker.NameOnBus;
            Children = null;
        }

        public Node(BaseCable cable) {
            BaseNode = cable;
            Description = "кабель: " + cable.CableName;
            Children = null;
        }

        public Node(BaseFeeder feeder) {
            BaseNode = feeder;
            Description = "фидер: " + feeder.CircuitBreaker.NameOnBus;
            Children = new ObservableCollection<Node> {
                new Node(feeder.CircuitBreaker),
                new Node(feeder.Cable),
                new Node(feeder.Consumer)
            };
        }

        public Node(BaseBusbar busbar) {
            BaseNode = busbar;
            Description = busbar.BusbarName;
            List<BaseFeeder> tempFeeders = busbar.Feeders;
            Children = new ObservableCollection<Node>();
            foreach (BaseFeeder feeder in tempFeeders) {
                Children.Add(new Node(feeder));
            }
        }

        public Node(BaseElectricalPanel panel) {
            BaseNode = panel;
            Description = panel.TechnologicalNumber;
            Children = new ObservableCollection<Node>();
            foreach (var busBar in panel.BusBars) {
                Children.Add(new Node(busBar));
            }
        }
    }
}