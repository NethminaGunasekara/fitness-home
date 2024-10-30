using fitness_home.Services;
using fitness_home.Views.Messages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace fitness_home.Helpers
{
    internal class TransactionInfo
    {
        // Retrieves all transactions associated with the current user's id from the database
        // Assigns them to the "Transactions" field, so that we can display 12 transactions per page
        public static List<Transaction> RetrieveTransactions()
        {
            // List to store the list of transactions retrieved
            List<Transaction> Transactions = new List<Transaction>();

            try
            {
                // Create a connection to the database by reusing the connection string from the Authentication class
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open();

                    // Query to retrieve all transactions associated with the currently logged in user's id
                    string query = "SELECT transaction_id, transaction_date, payment_method, amount, remarks, status FROM [transaction] WHERE user_id=@UserId";

                    // Create an SQL command to execute the query
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Replace the parameter @UserId with the logged member's id
                        cmd.Parameters.AddWithValue("@UserId", Authentication.LoggedUser.ID);

                        // Initialize an SQL data reader to read all the rows found
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Read each row from the result
                            while (reader.Read())
                            {
                                // Add each row associated with 
                                Transactions.Add(new Transaction(
                                    reader.GetInt32(0),       // transaction_id
                                    reader.GetDateTime(1),    // transaction_date
                                    reader.GetString(2),      // payment_method
                                    reader.GetDecimal(3),     // amount
                                    reader.GetString(4),      // remarks
                                    reader.GetString(5)       // status
                                ));
                            }
                        }
                    }
                }
            }

            // If the query above generates an error
            catch (SqlException)
            {
                // Display the ApplicationError dialog indicating a database error
                ApplicationError databaseError = new ApplicationError(ErrorType.DatabaseError);

                databaseError.ShowDialog();
            }


            // Return the list of transactions retrieved (an empty list if no transactions are found)
            return Transactions;
        }

        // ** Helper Method: Clear the text content of a given set of labels
        private void ClearTextContent(List<Label> labels)
        {
            // Clear the text content of each label from the list and reset its background color
            labels.ForEach(label =>
            {
                // Set an empty text
                label.Text = "";

                // Set the background color to transparent
                label.BackColor = Color.Transparent;
            });
        }

        // Page number to display the list of transactions
        private int PageNumber = 0;

        // Index of the last transaction for the page
        private int LastTransaction = 11;

        public void PaginateMemberTransactions(Page page, List<Transaction> transactions, List<Label> ReferenceLabels, List<Label> DateLabels, List<Label> AmountLabels, List<Label> RemarksLabels, List<Label> StatusLabels, Label dateRangeLabel)
        {
            // Clear previous transaction information on all provided labels
            ClearTextContent(ReferenceLabels);
            ClearTextContent(DateLabels);
            ClearTextContent(AmountLabels);
            ClearTextContent(RemarksLabels);
            ClearTextContent(StatusLabels);

            // Determine the page based on the requested direction
            switch (page)
            {
                case Page.First:
                    // Set to the first page
                    PageNumber = 0;
                    break;

                case Page.Previous:
                    // Decrement page number if not already at the first page
                    if (PageNumber > 0)
                    {
                        PageNumber--;
                    }
                    break;

                case Page.Next:
                    // Increment page number if more transactions are available for the next page
                    if ((PageNumber + 1) * 12 < transactions.Count)
                    {
                        PageNumber++;
                    }
                    break;
            }

            // Calculate starting and ending index for transactions on the current page
            int startIdx = PageNumber * 12;
            int endIdx = Math.Min(startIdx + 12, transactions.Count);

            // Update the date range label with the date range of transactions on the current page
            if (endIdx > startIdx)
            {
                DateTime firstDate = DateTime.Parse(transactions[startIdx].Date);
                DateTime lastDate = DateTime.Parse(transactions[endIdx - 1].Date);
                string dateRange = $"{firstDate:dd MMMM, yyyy} - {lastDate:dd MMMM, yyyy}";
                dateRangeLabel.Text = dateRange;
            }

            else
            {
                dateRangeLabel.Text = "No transactions";
            }

            // Loop over transactions in the current page range and display their information
            for (int i = startIdx, labelIdx = 0; i < endIdx; i++, labelIdx++)
            {
                // Retrieve the transaction for the current index
                Transaction transaction = transactions[i];

                // Display transaction details on corresponding labels
                ReferenceLabels[labelIdx].Text = transaction.Reference;
                DateLabels[labelIdx].Text = transaction.Date;
                AmountLabels[labelIdx].Text = transaction.Amount;
                RemarksLabels[labelIdx].Text = transaction.Remarks;

                // Set label properties based on the transaction status
                switch (transaction.Status)
                {
                    case "Success":
                        // Set properties for a successful transaction
                        StatusLabels[labelIdx].Text = "Success";
                        StatusLabels[labelIdx].BackColor = Color.FromArgb(35, 51, 48);
                        StatusLabels[labelIdx].ForeColor = Color.FromArgb(21, 179, 146);
                        break;

                    case "Failed":
                        // Set properties for a failed transaction
                        StatusLabels[labelIdx].Text = "Failed";
                        StatusLabels[labelIdx].BackColor = Color.FromArgb(57, 44, 44);
                        StatusLabels[labelIdx].ForeColor = Color.FromArgb(255, 87, 87);
                        break;

                    default:
                        // Set properties for a pending transaction
                        StatusLabels[labelIdx].Text = "Pending";
                        StatusLabels[labelIdx].BackColor = Color.FromArgb(46, 44, 57);
                        StatusLabels[labelIdx].ForeColor = Color.FromArgb(118, 87, 255);
                        break;
                }
            }
        }

        /// <summary>
        /// Calculates the total amount of transactions for the current month.
        /// </summary>
        /// <returns>A string representing the total amount in the format "273,000 LKR", omitting cents if they are ".00".</returns>
        public static string CalculateMonthlyTransactionTotal()
        {
            decimal totalAmount = 0m; // Initialize total amount

            // SQL query to sum the transaction amounts for the current month
            string query = @"
        SELECT SUM(amount)
        FROM [transaction]
        WHERE MONTH(transaction_date) = MONTH(GETDATE()) 
          AND YEAR(transaction_date) = YEAR(GETDATE())";

            try
            {
                // Open a connection to the database using the connection string from the Authentication class
                using (SqlConnection conn = new SqlConnection(Authentication.Instance.ConnectionString))
                {
                    conn.Open();

                    // Execute the query
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        totalAmount = result != DBNull.Value ? (decimal)result : 0m;
                    }
                }
            }
            catch (SqlException)
            {
                // Handle database connection errors by showing an error dialog
                ApplicationError databaseError = new ApplicationError(ErrorType.DatabaseError);
                databaseError.ShowDialog();
            }

            // Format the total amount with comma separators, and add "LKR" at the end
            return totalAmount % 1 == 0
                ? $"{(int)totalAmount:N0} LKR" // Format without decimals if whole number
                : $"{totalAmount:0,0.00} LKR"; // Format with decimals if there are cents
        }
    }

    // ** Transaction data structure
    class Transaction
    {
        public string Reference { get; }
        public string Date { get; }
        public string Amount { get; }
        public string Remarks { get; }
        public string Status { get; }

        public Transaction(int transactionId, DateTime date, string paymentMethod, decimal amount, string remarks, string status)
        {
            Reference = $"{paymentMethod.ToUpper()}_{transactionId}";
            Date = date.ToString("yyyy-MM-dd");
            Amount = $"LKR {amount:0.00}";
            Remarks = remarks;
            Status = status;

            // Payment status can be any of the following values:
            //  ** Pending
            //  ** Success
            //  ** Failed
        }
    }

    // Enumeration representing the page to display
    enum Page
    {
        First,
        Next,
        Previous,
    }
}