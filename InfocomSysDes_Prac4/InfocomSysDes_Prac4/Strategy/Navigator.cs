using System;
namespace Strategy {
    public class Navigator {
        abstract class NavigatorStrategy {
            public string Title { get; set; }
            public abstract void ShowMap();
            public abstract void CreatRoadRoute(int pointA, int pointB);
            public abstract void CreatePedestrianRoute(int pointA, int pointB);
            public abstract void CreateCycleRoute(int pointA, int pointB);
            public abstract void CreatePublicTransportRoute(int pointA, int pointB);
            public abstract void CreateSightsRoute(int pointA, int pointB);
        }

        class GoogleNavigator : NavigatorStrategy {
            public GoogleNavigator() {
                Title = "Google Navigator";
            }
            public override void CreateCycleRoute(int pointA, int pointB) {
                throw new NotImplementedException();
            }

            public override void CreatePedestrianRoute(int pointA, int pointB) {
                throw new NotImplementedException();
            }

            public override void CreatePublicTransportRoute(int pointA, int pointB) {
                throw new NotImplementedException();
            }

            public override void CreateSightsRoute(int pointA, int pointB) {
                throw new NotImplementedException();
            }

            public override void CreatRoadRoute(int pointA, int pointB) {
                throw new NotImplementedException();
            }

            public override void ShowMap() {
                Console.WriteLine("Map was shown by {0}", Title);
            }
        }

        class YandexNavigator : NavigatorStrategy {
            public YandexNavigator() {
                Title = "Yandex Navigator";
            }
            public override void CreateCycleRoute(int pointA, int pointB) {
                throw new NotImplementedException();
            }

            public override void CreatePedestrianRoute(int pointA, int pointB) {
                throw new NotImplementedException();
            }

            public override void CreatePublicTransportRoute(int pointA, int pointB) {
                throw new NotImplementedException();
            }

            public override void CreateSightsRoute(int pointA, int pointB) {
                throw new NotImplementedException();
            }

            public override void CreatRoadRoute(int pointA, int pointB) {
                throw new NotImplementedException();
            }

            public override void ShowMap() {
                Console.WriteLine("Map was shown by {0}", Title);
            }
        }

        class NavigatorUser {
            NavigatorStrategy strategy;

            public NavigatorUser(NavigatorStrategy strategy) {
                this.strategy = strategy;
            }

            public void OpenMap() {
                strategy.ShowMap();
            }
        }

        public Navigator() {
        }

        public void Execute() {
            NavigatorUser u1 = new NavigatorUser(new GoogleNavigator());
            u1.OpenMap();

            NavigatorUser u2 = new NavigatorUser(new YandexNavigator());
            u2.OpenMap();
        }
    }
}
