using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace fitness_home.Views.Onboarding.Register.Services
{
    internal class PaymentProcessor
    {
       // Initialize a list of valid cards
        List<Card> ValidCards = new List<Card> {
            // VISA
            new Card(cardHolder: "Shehan Anushka", cardNumber: "4135-4100-1270-8174", cvc: "328", expiryMonth: "05", expiryYear: "26"),
            new Card(cardHolder: "Chamod Dhananjaya", cardNumber: "4135-4100-1227-7442", cvc: "388", expiryMonth: "02", expiryYear: "27"),
            new Card(cardHolder: "Chanuka Dilhara", cardNumber: "4135-4100-1233-2159", cvc: "262", expiryMonth: "07", expiryYear: "26"),
            new Card(cardHolder: "Sachi Anurad", cardNumber: "4135-4100-1280-5334", cvc: "274", expiryMonth: "08", expiryYear: "26"),
        
            // Mastercard
            new Card(cardHolder: "Heshan Adithya", cardNumber: "5391-5720-1533-1421", cvc: "804", expiryMonth: "02", expiryYear: "27"),
            new Card(cardHolder: "Nethmina Gunasekara", cardNumber: "5391-5720-1270-8174", cvc: "722", expiryMonth: "02", expiryYear: "28"),
            new Card(cardHolder: "Dulanja Nimesh", cardNumber: "5391-5720-1233-1184", cvc: "744", expiryMonth: "07", expiryYear: "28"),

        };

        public PaymentStatus CardPayment(string amount, string cardHolder, string cardNumber, string cvc, string expiryMonth, string expiryYear, Form paymentForm)
        {
            if(ValidCards.Any(card => card.CardHolder == cardHolder && card.CardNumber == cardNumber && card.Cvc == cvc && card.ExpiryMonth == expiryMonth && card.ExpiryYear == expiryYear)) {
                return PaymentStatus.Success;
            }

            return PaymentStatus.Failed;
        }

        public enum PaymentStatus
        {
            Pending,
            Success,
            Failed,
        }

        private class Card
        {
            public string CardHolder;
            public string CardNumber;
            public string Cvc;
            public string ExpiryMonth;
            public string ExpiryYear;

            public Card(string cardHolder, string cardNumber, string cvc, string expiryMonth, string expiryYear)
            {
                CardHolder = cardHolder;
                CardNumber = cardNumber;
                Cvc = cvc;
                ExpiryMonth = expiryMonth;
                ExpiryYear = expiryYear;
            }
        }
    }
}
