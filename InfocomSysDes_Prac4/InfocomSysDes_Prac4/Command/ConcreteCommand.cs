using System;
namespace Command {
    class Subtract : Command {
        public Subtract(ArithmeticUnit unit, double operand) {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute() {
            unit.Run('-', operand);
        }
        public override void UnExecute() {
            unit.Run('+', operand);
        }
    }

    class Multiply : Command {
        public Multiply(ArithmeticUnit unit, double operand) {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute() {
            unit.Run('*', operand);
        }
        public override void UnExecute() {
            unit.Run('/', operand);
        }
    }

    class Divide : Command {
        public Divide(ArithmeticUnit unit, double operand) {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute() {
            unit.Run('/', operand);
        }
        public override void UnExecute() {
            unit.Run('*', operand);
        }
    }


    public class ConcreteCommand {
        public ConcreteCommand() {
        }
    }
}
