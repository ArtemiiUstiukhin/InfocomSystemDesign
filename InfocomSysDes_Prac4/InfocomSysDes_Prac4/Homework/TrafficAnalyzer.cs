using System;
using System.Collections.Generic;
using System.Threading;

namespace Homework {
    public class TrafficAnalyzer {

        readonly int roadsCount;
        readonly int sleepTime;

        DataReaderCollection dataReader;
        TimeSwitchingCalculator calculator;
        Dictionary<int, bool> trafficLights;

        public TrafficAnalyzer(int count, int timeOut) {
            roadsCount = count;
            sleepTime = timeOut;
            calculator = TimeSwitchingCalculator.GetInstance();
        }

        void initSystemComponents(Dictionary<int, bool> trafficLights) {
            dataReader = new DataReaderCollection(roadsCount);
            calculator.CreateTrafficLightsController(trafficLights);
        }

        public void RunSystem(Dictionary<int, bool> trafficLights) {
            initSystemComponents(trafficLights);

            while (true) {
                List<int> actualData = dataReader.getActualData();
                Dictionary<int, int> trafficLightsData = new Dictionary<int, int>();
                int i = 0;
                foreach (int key in trafficLights.Keys) {
                    trafficLightsData.Add(key, actualData[i]);
                    i++;
                }
                calculator.updateTLSwitchTime(trafficLightsData);

                Thread.Sleep(sleepTime);
            }
        }
    }
}
