using System;
namespace TemplateMethod {
    abstract class HairCut {
        public string Name;

        public HairCut(string name) {
            Name = name;
        }

        public void TemplateMethod() {
            WashHair();
            CutHair();
            DryHair();
        }

        public abstract void CutHair();

        void WashHair() {
            Console.WriteLine("Wash Hair");
        }

        void DryHair() {
            Console.WriteLine("Dry Hair");
        }
    }

    class LongHairCut : HairCut {
        public LongHairCut(string name) : base(name) { }

        public override void CutHair() {
            Console.WriteLine("Make long haircut - {0}", Name);
        }
    }

    class ShortHairCut : HairCut {
        public ShortHairCut(string name) : base(name) { }

        public override void CutHair() {
            Console.WriteLine("Make short haircut - {0}", Name);
        }
    }


    public class ControlTask {
        public ControlTask() {
        }

        public void Execute() {
            HairCut longHC = new LongHairCut("Rock and Roll");
            longHC.TemplateMethod();

            HairCut shortHC = new ShortHairCut("Hedgehog");
            shortHC.TemplateMethod();
        }
    }
}
