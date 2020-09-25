using System;
using System.Collections.Generic;

namespace Homework {
    class Program {
        static int getNewRandom() {
            Random r = new Random();
            int tlNumber = r.Next(100) + 50;
            return tlNumber;
        }
        static void Main(string[] args) {
            Console.Clear();

            int tlCount = 4;
            int timeOut = 5 * 1000;
            Dictionary<int, bool> trafficLights = new Dictionary<int, bool>();
            TrafficAnalyzer trafficAnalyzer = new TrafficAnalyzer(tlCount, timeOut);
            for (int i = 0; i < tlCount; i++) {
                int tlNumber = getNewRandom();
                while (trafficLights.ContainsKey(tlNumber))
                    tlNumber = getNewRandom();

                trafficLights.Add(tlNumber, tlNumber > 100);
            }
            trafficAnalyzer.RunSystem(trafficLights);
        }
    }
}
