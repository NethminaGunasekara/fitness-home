using fitness_home.Services;
using fitness_home.Views.Messages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace fitness_home.Helpers
{
    internal class PaymentProcessor
    {
        // Validates a card payment by checking if the provided card details match any of the valid cards.
        // Returns "true" if the card details match any valid card, otherwise returns "false"
        public static bool CardPayment(string cardHolder, string cardNumber, string cvc, string expiryMonth, string expiryYear)
        {
            // Initialize a list of valid cards (sample data for validation).
            List<Card> ValidCards = new List<Card> {
                // VISA Cards
                new Card(cardHolder: "Shehan Anushka", cardNumber: "4135-4100-1270-8174", cvc: "328", expiryMonth: "05", expiryYear: "26"),
                new Card(cardHolder: "Chamod Dhananjaya", cardNumber: "4135-4100-1227-7442", cvc: "388", expiryMonth: "02", expiryYear: "27"),
                new Card(cardHolder: "Chanuka Dilhara", cardNumber: "4135-4100-1233-2159", cvc: "262", expiryMonth: "07", expiryYear: "26"),
                new Card(cardHolder: "Sachi Anurad", cardNumber: "4135-4100-1280-5334", cvc: "274", expiryMonth: "08", expiryYear: "26"),

                // Mastercard Cards
                new Card(cardHolder: "Heshan Adithya", cardNumber: "5391-5720-1533-1421", cvc: "804", expiryMonth: "02", expiryYear: "27"),
                new Card(cardHolder: "Nethmina Gunasekara", cardNumber: "5391-5720-1270-8174", cvc: "722", expiryMonth: "02", expiryYear: "28"),
                new Card(cardHolder: "Dulanja Nimesh", cardNumber: "5391-5720-1233-1184", cvc: "744", expiryMonth: "07", expiryYear: "28"),
            };

            // Check if any card in the list matches the provided card details
            if (ValidCards.Any(card =>
                card.CardHolder == cardHolder &&
                card.CardNumber == cardNumber &&
                card.Cvc == cvc &&
                card.ExpiryMonth == expiryMonth &&
                card.ExpiryYear == expiryYear))
            {
                // If a matching card is found, return true (payment is successful)
                return true;
            }

            // If no matching card is found, return false (payment is unsuccessful)
            return false;
        }

        // Stores transaction information in the database and returns the generated transaction ID.
        public static int StoreTransactionInfo(DateTime transactionDate, string paymentMethod, decimal amount, string remarks, PaymentStatus status, int? memberId = null)
        {
            // Initialize the transaction ID
            int transactionId = 0;

            // Query to store transaction information in the database
            string query = @"INSERT INTO [transaction] (transaction_date, payment_method, amount, remarks, status, member_id)
                                OUTPUT INSERTED.transaction_id
                                VALUES (@TransactionDate, @PaymentMethod, @Amount, @Remarks, @Status, @MemberId)";

            // Create a db connection by reusing the connection string from the "Authentication" class
            using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
            {
                try
                {
                    conn.Open(); // Open the connection

                    // Create a SQL command using the query
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to the query
                        cmd.Parameters.AddWithValue("@TransactionDate", transactionDate);
                        cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@Remarks", remarks);
                        cmd.Parameters.AddWithValue("@Status", status.ToString());

                        // If memberId is null, pass DBNull to the query
                        cmd.Parameters.AddWithValue("@MemberId", (object)memberId ?? DBNull.Value);

                        // Execute the command and retrieve the transaction ID
                        transactionId = (int)cmd.ExecuteScalar();
                    }
                }

                // Handle sql related errors
                catch (SqlException)
                {
                    // Display database error message
                    new ApplicationError(ErrorType.DatabaseError).ShowDialog();
                }

                finally
                {
                    conn.Close(); // Close the connection
                }
            }

            // Return the generated transaction ID
            return transactionId;
        }
    }

    public enum PaymentStatus
    {
        Pending,
        Success,
        Failed,
    }

    public class Card
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
