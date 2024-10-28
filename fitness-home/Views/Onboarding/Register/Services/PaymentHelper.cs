using fitness_home.Services;
using fitness_home.Views.Messages;
using fitness_home.Views.Onboarding.Register.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace fitness_home.Views.Onboarding.Register.Services
{
    public class PaymentHelper
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

        /// <summary>
        /// Stores transaction information in the database and returns the generated transaction ID.
        /// </summary>
        /// <param name="transactionDate">Date when the transaction occurred</param>
        /// <param name="paymentMethod">Payment method used</param>
        /// <param name="amount">Total amount of the transaction</param>
        /// <param name="remarks">Any additional remarks or notes regarding the transaction (maximum 50 characters)</param>
        /// <param name="status">Status of the transaction.</param>
        /// <param name="memberId">The ID of the member associated with the transaction (optional). Defaults to <c>null</c>.</param>
        /// <returns>
        /// Returns the generated transaction ID as an <see cref="int"/> after the transaction is stored in the database.
        /// </returns>
        public int StoreTransactionInfo(DateTime transactionDate, PaymentMethod paymentMethod, decimal amount, string remarks, PaymentStatus status, int? memberId = null)
        {
            // Initialize the transaction ID
            int transactionId = 0;

            // Query to store transaction information in the database
            string query = @"INSERT INTO [transaction] (transaction_date, payment_method, amount, remarks, status, user_id)
                     OUTPUT INSERTED.transaction_id
                     VALUES (@TransactionDate, @PaymentMethod, @Amount, @Remarks, @Status, @UserId)";

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
                        cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod.ToString());
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@Remarks", remarks);
                        cmd.Parameters.AddWithValue("@Status", status.ToString());

                        // If memberId is null, pass DBNull to the query
                        cmd.Parameters.AddWithValue("@UserId", (object)memberId ?? DBNull.Value);

                        // Execute the command and retrieve the transaction ID
                        transactionId = (int)cmd.ExecuteScalar();
                    }
                }
                
                // Catch SQL errors
                catch (SqlException sqlEx)
                {
                    // Log the error for debugging purposes
                    Console.WriteLine($"SQL Error: ${sqlEx.Message}");

                    // Display database error message
                    new ApplicationError(ErrorType.DatabaseError).ShowDialog();
                }

                // Catch any other errors
                catch (Exception e)
                {
                    // Log the error for debugging purposes
                    Console.WriteLine($"Unexpected Error: ${e.Message}");

                    // Display application error message
                    new ApplicationError(ErrorType.UnexpectedError).ShowDialog();
                }

                finally
                {
                    conn.Close(); // Close the connection
                }
            }

            // Return the generated transaction ID
            return transactionId;
        }

        public PaymentStatus CardPayment(string cardHolder, string cardNumber, string cvc, string expiryMonth, string expiryYear)
        {
            if(ValidCards.Any(card => card.CardHolder == cardHolder && card.CardNumber == cardNumber && card.Cvc == cvc && card.ExpiryMonth == expiryMonth && card.ExpiryYear == expiryYear)) {
                return PaymentStatus.Success;
            }

            return PaymentStatus.Failed;
        }

        public PaymentStatus CashPayment()
        {
            return PaymentStatus.Pending;
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
