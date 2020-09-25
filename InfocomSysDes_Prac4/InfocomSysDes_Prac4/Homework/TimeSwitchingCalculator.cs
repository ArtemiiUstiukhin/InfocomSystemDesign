using System;
using System.Collections.Generic;

namespace Homework {
    public class TimeSwitchingCalculator {
        TrafficLightsController trafficLightsController;

        private TimeSwitchingCalculator() { }

        private static TimeSwitchingCalculator _instance;

        public static TimeSwitchingCalculator GetInstance() {
            if (_instance == null) {
                _instance = new TimeSwitchingCalculator();
            }
            return _instance;
        }

        public void CreateTrafficLightsController(Dictionary<int, bool> trafficLights) {
            if (trafficLights.Count > 0)
                trafficLightsController = new TrafficLightsController(trafficLights);
        }

        Dictionary<int, int> calculateSwitchingTime(Dictionary<int, int> trafficLightsData) {
            Dictionary<int, int> calculatedData = new Dictionary<int, int>();
            foreach (int key in trafficLightsData.Keys) {
                int factor = key > 100 ? 2 : 3;
                calculatedData.Add(key, trafficLightsData[key] * factor);
            }
            return calculatedData;
        }

        public void updateTLSwitchTime(Dictionary<int, int> trafficLightsData) {
            Dictionary<int, int> calculatedData = calculateSwitchingTime(trafficLightsData);
            trafficLightsController.UpdateTrafficLightsData(calculatedData);
        }
    }
}
