using System;
namespace Adapter {
    public class ControlTask {
        interface ITethermometer {
            double GetTemperaruteInСelsius();
        }

        class Tethermometer {
            Random r;

            public Tethermometer() {
                r = new Random();
            }

            public int GetTemperaruteInFahrenheit() {
                return r.Next(200);
            }

        }

        class TemperatureAdapter : ITethermometer {
            Tethermometer tethermometer;

            public TemperatureAdapter(Tethermometer term) {
                tethermometer = term;
            }
            double convertFahrenheitTemperuteToСelsius(int temperaruteInСelsius) {
                return (temperaruteInСelsius - 32) / 1.8;
            }
            public double GetTemperaruteInСelsius() {
                return convertFahrenheitTemperuteToСelsius(tethermometer.GetTemperaruteInFahrenheit());
            }
        }

        public void Execute() {
            Tethermometer tethermometer = new Tethermometer();
            ITethermometer adapter = new TemperatureAdapter(tethermometer);
            Console.WriteLine("Температура в градусах Цельсия = {0:#.##}", adapter.GetTemperaruteInСelsius());
        }
    }
}
