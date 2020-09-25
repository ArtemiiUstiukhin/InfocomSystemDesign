using System;
using System.Collections.Generic;

namespace Homework {
    public class TrafficLightsController {
        Dictionary<int, TrafficLightFabric> trafficLightBridges;

        public TrafficLightsController(Dictionary<int, bool> trafficLights) {
            trafficLightBridges = new Dictionary<int, TrafficLightFabric>();
            foreach (var trafficLight in trafficLights) {
                TrafficLightFabric trafficLightBridge = createTrafficLightBridge(trafficLight);
                trafficLightBridges.Add(trafficLight.Key, trafficLightBridge);
            }
        }

        TrafficLightFabric createTrafficLightBridge(KeyValuePair<int, bool> trafficLight) {
            if (trafficLight.Value)
                return new TrafficLight2Bridge(trafficLight.Key);
            else
                return new TrafficLight3Bridge(trafficLight.Key);
        }

        public void UpdateTrafficLightsData(Dictionary<int, int> trafficLightsData) {
            Console.WriteLine("----StartUpdate-----");
            foreach (var data in trafficLightsData) {
                if (trafficLightBridges.TryGetValue(data.Key, out TrafficLightFabric bridge))
                    bridge.SendTimeoutDataToTraficLight(data.Value);
            }
            Console.WriteLine("----EndUpdate-----");
        }
    }

    abstract class TrafficLightFabric {
        protected readonly DataConverterBase DataConverter;
        public int Number { get; set; }
        public TrafficLightFabric(int n) {
            Number = n;
            DataConverter = CreateDataConverter();
        }
        public abstract void SendTimeoutDataToTraficLight(int timeoutData);
        // фабричный метод
        protected abstract DataConverterBase CreateDataConverter();
    }

    class TrafficLight2Bridge : TrafficLightFabric {
        public TrafficLight2Bridge(int n) : base(n) {
        }
        public override void SendTimeoutDataToTraficLight(int timeoutData) {
            Console.WriteLine(String.Format("Send value {0} to TrafficLight2 № {1} converterd by {2}", DataConverter.convertTimeoutData(timeoutData), Number, DataConverter.Name));
        }
        protected override DataConverterBase CreateDataConverter() {
            return new SimpleDataConverter("SimpleDataConverter");
        }
    }

    class TrafficLight3Bridge : TrafficLightFabric {
        public TrafficLight3Bridge(int n) : base(n) {
        }
        public override void SendTimeoutDataToTraficLight(int timeoutData) {
            Console.WriteLine(String.Format("Send value {0} to TrafficLight3 № {1} converterd by {2}", DataConverter.convertTimeoutData(timeoutData), Number, DataConverter.Name));
        }
        protected override DataConverterBase CreateDataConverter() {
            return new ComplexDataConverter("ComplexDataConverter");
        }
    }

    abstract class DataConverterBase {
        public string Name { get; set; }
        public DataConverterBase(string n) {
            Name = n;
        }
        abstract public double convertTimeoutData(int data);
    }

    class SimpleDataConverter : DataConverterBase {
        public SimpleDataConverter(string n) : base(n) { }
        public override double convertTimeoutData(int data) {
            return data * 2;
        }
    }

    class ComplexDataConverter : DataConverterBase {
        public ComplexDataConverter(string n) : base(n) { }
        public override double convertTimeoutData(int data) {
            return data * 3;
        }
    }
}
