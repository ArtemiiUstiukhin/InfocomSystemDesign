using System;

namespace ChainofResponsibility {
    class Receiver {
        // банковские переводы
        public bool BankTransfer { get; set; }
        // денежные переводы - WesternUnion, Unistream
        public bool MoneyTransfer { get; set; }
        // перевод через PayPal
        public bool PayPalTransfer { get; set; }
        public Receiver(bool bt, bool mt, bool ppt) {
            BankTransfer = bt;
            MoneyTransfer = mt;
            PayPalTransfer = ppt;
        }
    }

    abstract class PaymentHandler {
        public PaymentHandler Successor { get; set; }
        public abstract void Handle(Receiver receiver);
    }



    class Program {
        static void Main(string[] args) {
            Receiver receiver = new Receiver(false, false, true);

            PaymentHandler bankPaymentHandler = new BankPaymentHandler();
            PaymentHandler moneyPaymentHandler = new MoneyPaymentHandler();
            PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();

            bankPaymentHandler.Successor = moneyPaymentHandler;
            moneyPaymentHandler.Successor = paypalPaymentHandler;
            bankPaymentHandler.Handle(receiver);
        }
    }
}
