using System;

namespace Decorator {
    public abstract class AutoBase {
        public string Name { get; set; }
        public string Description { get; set; }
        public double CostBase { get; set; }
        public abstract double GetCost();
        public override string ToString() {
            string s = String.Format("Ваш автомобиль: \n{0} \nОписание: {1} \nСтоимость {2}\n",
            Name, Description, GetCost());
            return s;
        }
    }

    class Renault : AutoBase {
        public Renault(string name, string info, double costbase) {
            Name = name;
            Description = info;
            CostBase = costbase;
        }
        public override double GetCost() {
            return CostBase * 1.18;
        }
    }

    class Audi : AutoBase {
        public Audi(string name, string info, double costbase) {
            Name = name;
            Description = info;
            CostBase = costbase;
        }
        public override double GetCost() {
            return CostBase * 2;
        }
    }

    abstract class DecoratorOptions : AutoBase {
        public AutoBase AutoProperty { protected get; set; }
        public string Title { get; set; }
        public DecoratorOptions(AutoBase au, string tit) {
            AutoProperty = au;
            Title = tit;
        }
    }

    class MediaNAV : DecoratorOptions {
        public MediaNAV(AutoBase p, string t) : base(p, t) {
            AutoProperty = p;
            Name = p.Name + ". Современный";
            Description = p.Description + ". " + this.Title + ". Обновленная мультимедийная навигационная система";
        }
        public override double GetCost() {
            return AutoProperty.GetCost() + 15.99;
        }
    }

    class SystemSecurity : DecoratorOptions {
        public SystemSecurity(AutoBase p, string t) : base(p, t) {
            AutoProperty = p;
            Name = p.Name + ". Повышенной безопасности";
            Description = p.Description + ". " + this.Title + ". Передние боковые подушки безопасности, ESP -система динамической стабилизации автомобиля";
        }
        public override double GetCost() {
            return AutoProperty.GetCost() + 20.99;
        }
    }

    class HeatedSeats : DecoratorOptions {
        public HeatedSeats(AutoBase p, string t) : base(p, t) {
            AutoProperty = p;
            Name = p.Name + ". С подогревом сидений";
            Description = p.Description + ". " + this.Title + ". Передние сидения подогревается, есть 3 температурных режима";
        }
        public override double GetCost() {
            return AutoProperty.GetCost() + 50;
        }
    }

    class RemoteStart : DecoratorOptions {
        public RemoteStart(AutoBase p, string t) : base(p, t) {
            AutoProperty = p;
            Name = p.Name + ". С возможностью дистанционного запуска двигателя";
            Description = p.Description + ". " + this.Title + ". Двигатель можно запустить дистанционно";
        }
        public override double GetCost() {
            return AutoProperty.GetCost() + 80;
        }
    }

    class Program {
        static void Main(string[] args) {
            Renault reno = new Renault("Рено", "Renault LOGAN Active", 499.0);
            Print(reno);
            AutoBase myreno = new MediaNAV(reno, "Навигация");
            Print(myreno);
            AutoBase newmyReno = new SystemSecurity(new MediaNAV(reno, "Навигация"), "Безопасность");
            Print(newmyReno);

            Audi audi = new Audi("Ауди", "Audi A6", 800.0);
            Print(audi);
            AutoBase warmAudi = new HeatedSeats(audi, "Подогрев сидений");
            Print(warmAudi);
            AutoBase remoteControlAudi = new RemoteStart(warmAudi, "Дистанционный запуск");
            Print(remoteControlAudi);
        }

        private static void Print(AutoBase av) {
            Console.WriteLine(av.ToString());
        }
    }
}
