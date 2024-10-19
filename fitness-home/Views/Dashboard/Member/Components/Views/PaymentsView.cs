using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using fitness_home.Services;
using System.Data.SqlClient;
using fitness_home.Views.Messages;

namespace fitness_home.Views.Dashboard.Member.Components.Views
{
    public partial class PaymentsView : UserControl
    {
        // Code for rounded rectangle panels (omitted for brevity)
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void ApplyRoundedCorners()
        {
            List<Panel> panelsToDraw = new List<Panel> { panel_content };
            SuspendLayout();
            panelsToDraw.ForEach(panel => panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 12, 12)));
            ResumeLayout();
        }

        // Fields to store transaction data and pagination state
        List<Transaction> Transactions = new List<Transaction>();
        int currentPage = 0; // Current page (0 = first set of 12 transactions)
        const int pageSize = 12; // Number of transactions to display per page

        // Label lists for transaction data
        List<Label> ReferenceLabels, DateLabels, AmountLabels, RemarksLabels, StatusLabels;

        public PaymentsView()
        {
            InitializeComponent();
            RetrieveTransactions(); // Retrieve transactions from the database
            InitializeLabelLists(); // Initialize label lists
            ShowTransactions();     // Show the first page of transactions
        }

        // ** Initialize lists of labels **
        private void InitializeLabelLists()
        {
            ReferenceLabels = new List<Label> { label_ref_1, label_ref_2, label_ref_3, label_ref_4, label_ref_5, label_ref_6, label_ref_7, label_ref_8, label_ref_9, label_ref_10, label_ref_11, label_ref_12 };
            DateLabels = new List<Label> { label_date_1, label_date_2, label_date_3, label_date_4, label_date_5, label_date_6, label_date_7, label_date_8, label_date_9, label_date_10, label_date_11, label_date_12 };
            AmountLabels = new List<Label> { label_amount_1, label_amount_2, label_amount_3, label_amount_4, label_amount_5, label_amount_6, label_amount_7, label_amount_8, label_amount_9, label_amount_10, label_amount_11, label_amount_12 };
            RemarksLabels = new List<Label> { label_remarks_1, label_remarks_2, label_remarks_3, label_remarks_4, label_remarks_5, label_remarks_6, label_remarks_7, label_remarks_8, label_remarks_9, label_remarks_10, label_remarks_11, label_remarks_12 };
            StatusLabels = new List<Label> { label_status_1, label_status_2, label_status_3, label_status_4, label_status_5, label_status_6, label_status_7, label_status_8, label_status_9, label_status_10, label_status_11, label_status_12 };
        }

        // ** Retrieve transactions from the database **
        private void RetrieveTransactions()
        {
            string connectionString = Authentication.Instance.ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT transaction_id, transaction_date, payment_method, amount, remarks, status FROM [transaction]";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
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
            catch (SqlException)
            {
                new ApplicationError(ErrorType.DatabaseError);
            }
        }

        // ** Display transactions for the current page **
        private void ShowTransactions()
        {
            // Make all labels visible before setting new data
            SetLabelsVisibility(true);

            // Get the subset of transactions for the current page
            int startIndex = currentPage * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, Transactions.Count);

            for (int i = 0; i < pageSize; i++)
            {
                if (i + startIndex < endIndex)
                {
                    // Set label values for visible transactions
                    Transaction transaction = Transactions[i + startIndex];
                    ReferenceLabels[i].Text = transaction.Reference;
                    DateLabels[i].Text = transaction.Date;
                    AmountLabels[i].Text = transaction.Amount;
                    RemarksLabels[i].Text = transaction.Remarks;
                    StatusLabels[i].Text = transaction.Status;

                    // Set the text, background color and foreground color of the payment status message
                    if (transaction.Status == "Success")
                    {
                        StatusLabels[i].Text = "Success";
                        StatusLabels[i].BackColor = Color.FromArgb(35, 51, 48);
                        StatusLabels[i].ForeColor = Color.FromArgb(21, 179, 146);
                    }

                    // If the trainer has marked the user's attendence as "Ansent"
                    else if (transaction.Status == "Failed")
                    {
                        StatusLabels[i].Text = "Failed";
                        StatusLabels[i].BackColor = Color.FromArgb(57, 44, 44);
                        StatusLabels[i].ForeColor = Color.FromArgb(255, 87, 87);
                    }

                    // If either the trainer hasn't marked the user's attendence or the class hasn't started yet
                    else
                    {
                        StatusLabels[i].Text = "Pending";
                        StatusLabels[i].BackColor = Color.FromArgb(46, 44, 57);
                        StatusLabels[i].ForeColor = Color.FromArgb(118, 87, 255);
                    }
                }

                else
                {
                    // Hide unused labels if there are fewer than 12 transactions on the page
                    ReferenceLabels[i].Visible = false;
                    DateLabels[i].Visible = false;
                    AmountLabels[i].Visible = false;
                    RemarksLabels[i].Visible = false;
                    StatusLabels[i].Visible = false;
                }
            }
        }

        // ** Set visibility for all labels in the lists **
        private void SetLabelsVisibility(bool isVisible)
        {
            ReferenceLabels.ForEach(label => label.Visible = isVisible);
            DateLabels.ForEach(label => label.Visible = isVisible);
            AmountLabels.ForEach(label => label.Visible = isVisible);
            RemarksLabels.ForEach(label => label.Visible = isVisible);
            StatusLabels.ForEach(label => label.Visible = isVisible);
        }

        // ** Show the previous 12 transactions **
        private void button_previous_transactions_Click(object sender, EventArgs e)
        {
            if (currentPage == 0) return; // No previous page to show
            currentPage--;
            ShowTransactions();
        }

        // ** Show the next 12 transactions **
        private void button_next_transactions_Click(object sender, EventArgs e)
        {
            if ((currentPage + 1) * pageSize >= Transactions.Count) return; // No next page to show
            currentPage++;
            ShowTransactions();
        }

        // ** Transaction data structure **
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

        private void PaymentsView_Load(object sender, EventArgs e) => ApplyRoundedCorners();
        private void PaymentsView_Resize(object sender, EventArgs e) => ApplyRoundedCorners();
    }
}
