using System;
using System.Collections.Generic;

namespace TemplateMethod {
    abstract class Progression {
        public int First { get; set; }
        public int Last { get; set; }
        public int H { get; set; }
        public List<int> progList;

        public Progression(int first, int last, int h) {
            First = first;
            Last = last;
            H = h;
            progList = new List<int>();
        }

        public void TemplateMethod() {
            InitializeProgression(First, Last, H);
            Progress();
            Print(progList);
        }

        public abstract void Progress();

        private void Print(List<int> progList) {
            Console.WriteLine("Последовательность:");
            foreach (var item in progList) {
                Console.Write(" " + item);
            }
            Console.WriteLine();
        }
        private void InitializeProgression(int a, int b, int h) {
            First = a;
            Last = b;
            H = h;
        }
    }

    class ArithmeticProgression : Progression {
        public ArithmeticProgression(int f, int l, int h) : base(f, l, h) { }
        public override void Progress() {
            int fF = First;
            do {
                progList.Add(fF);
                fF += H;
            }
            while (fF < Last);
        }
    }

    class GeometricProgression : Progression {
        public GeometricProgression(int f, int l, int h) : base(f, l, h) { }
        public override void Progress() {
            int fF = First;
            do {
                progList.Add(fF);
                fF *= H;
            }
            while (fF < Last);
        }
    }

    class Program {
        static void Main(string[] args) {
            //Console.Write("Введите первый член прогрессии: ");
            //int f = int.Parse(Console.ReadLine());
            //Console.WriteLine();

            //Console.Write("Введите последний член прогрессии: ");
            //int l = int.Parse(Console.ReadLine());
            //Console.WriteLine();

            //Console.Write("Введите шаг прогрессии: ");
            //int h = int.Parse(Console.ReadLine());
            //Console.WriteLine();

            //Progression val1 = new ArithmeticProgression(f, l, h);
            //val1.TemplateMethod();

            //Progression val2 = new GeometricProgression(f, l, h);
            //val2.TemplateMethod();

            ControlTask ct = new ControlTask();
            ct.Execute();
        }
    }
}
