using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using fitness_home.Helpers;

namespace fitness_home.Views.Member.Components.Views
{
    public partial class Payments : UserControl
    {
        // List to store the list of transactions retrieved
        List<Transaction> Transactions = new List<Transaction>();

        // Lists of labels for storing transaction data
        List<Label> ReferenceLabels, DateLabels, AmountLabels, RemarksLabels, StatusLabels;

        // Initialize an instance of the helper class "TransactionInfo"
        TransactionInfo TransactionInfo = new TransactionInfo();

        public Payments()
        {
            InitializeComponent();

            // Retrieve the list of transactions from the database and store them in the "Transactions" list
            Transactions = TransactionInfo.RetrieveTransactions();

            // Initialize the lists of labels (reference, date, amount, remarks, and status)
            InitializeLabelLists();
        }

        // ** Initialize lists of labels
        private void InitializeLabelLists()
        {
            // List to store all labels used for displaying transaction references
            ReferenceLabels = new List<Label> { label_ref_1, label_ref_2, label_ref_3, label_ref_4, label_ref_5, label_ref_6, label_ref_7, label_ref_8, label_ref_9, label_ref_10, label_ref_11, label_ref_12 };

            // List to store all labels used for displaying transaction dates
            DateLabels = new List<Label> { label_date_1, label_date_2, label_date_3, label_date_4, label_date_5, label_date_6, label_date_7, label_date_8, label_date_9, label_date_10, label_date_11, label_date_12 };

            // List to store all labels used for displaying transaction amounts
            AmountLabels = new List<Label> { label_amount_1, label_amount_2, label_amount_3, label_amount_4, label_amount_5, label_amount_6, label_amount_7, label_amount_8, label_amount_9, label_amount_10, label_amount_11, label_amount_12 };

            // List to store all labels used for displaying transaction remarks
            RemarksLabels = new List<Label> { label_remarks_1, label_remarks_2, label_remarks_3, label_remarks_4, label_remarks_5, label_remarks_6, label_remarks_7, label_remarks_8, label_remarks_9, label_remarks_10, label_remarks_11, label_remarks_12 };

            // List to store all labels used for displaying transaction statuses
            StatusLabels = new List<Label> { label_status_1, label_status_2, label_status_3, label_status_4, label_status_5, label_status_6, label_status_7, label_status_8, label_status_9, label_status_10, label_status_11, label_status_12 };
        }

        // ** Event: When the control has loaded to the member area
        private void Payments_Load(object sender, EventArgs e)
        {
            // Show the first page of transactions (first 12 transactions from the retrieved list of transactions)
            TransactionInfo.PaginateMemberTransactions(
                    page: Page.First,
                    transactions: Transactions,
                    ReferenceLabels: ReferenceLabels,
                    DateLabels: DateLabels,
                    AmountLabels: AmountLabels,
                    RemarksLabels: RemarksLabels,
                    StatusLabels: StatusLabels,
                    dateRangeLabel: date_range);

            // Apply rounded rectangle corners to the main panel
            panel_content.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_content.Width, panel_content.Height, 12, 12));
        }

        // ** Show the next 12 transactions **
        private void button_next_transactions_Click(object sender, EventArgs e)
        {
            // Show the next 12 transactions (if available)
            TransactionInfo.PaginateMemberTransactions(
                    page: Page.Next,
                    transactions: Transactions,
                    ReferenceLabels: ReferenceLabels,
                    DateLabels: DateLabels,
                    AmountLabels: AmountLabels,
                    RemarksLabels: RemarksLabels,
                    StatusLabels: StatusLabels,
                    dateRangeLabel: date_range);
        }

        // ** Show the previous 12 transactions **
        private void button_previous_transactions_Click(object sender, EventArgs e)
        {
            // Show the previous 12 transactions (if available)
            TransactionInfo.PaginateMemberTransactions(
                    page: Page.Previous,
                    transactions: Transactions,
                    ReferenceLabels: ReferenceLabels,
                    DateLabels: DateLabels,
                    AmountLabels: AmountLabels,
                    RemarksLabels: RemarksLabels,
                    StatusLabels: StatusLabels,
                    dateRangeLabel: date_range);
        }

        // ** Event: Redraw rounded rectangle corners of the main panel when the control is being resized
        private void PaymentsView_Resize(object sender, EventArgs e) => panel_content.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_content.Width, panel_content.Height, 12, 12));

        // Code required to apply rounded rectangle corners to the main panel
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }
}
