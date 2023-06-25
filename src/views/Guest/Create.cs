using Controllers;
using Models;

namespace Views
{
    public class CreateGuest : Form
    {
        public Label lbName;
        public Label lbBirth;
        public Label lbPayment;
        public Label lbDocument;
        public Label lbMothersName;
        public TextBox TxtName;
        public DateTimePicker DtBirth;
        public TextBox TxtPayment;
        public TextBox TxtDocument;
        public TextBox TxtMothersName;
        public Button btCreate;

        public void btCrt_Click(object sender, EventArgs e)
        {
            try
            {
                int payment = Convert.ToInt32(Convert.ToDouble(TxtPayment.Text));

                Models.Guest guest = new Models.Guest(
                TxtName.Text,
                DtBirth.Value,
                payment,
                Convert.ToInt32(TxtDocument.Text),
                 TxtMothersName.Text
                 );
                

                Controllers.Guest.store(guest);
                MessageBox.Show("Guest created successfully!");
                ClearForm();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void ClearForm()
        {
            TxtName.Clear();
            DtBirth.Value = DateTime.MinValue; 
            TxtPayment.Clear();
            TxtDocument.Clear();
            TxtMothersName.Clear();

        }

        public CreateGuest()
        {
            this.Text = "Register a Guest";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            Color color = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(280, 360);

            lbName = new Label();
            lbName.Text = "Name:";
            lbName.Location = new System.Drawing.Point(10, 40);
            lbName.Size = new System.Drawing.Size(50, 20);
            this.Controls.Add(lbName);

            TxtName = new TextBox();
            TxtName.Location = new System.Drawing.Point(80, 40);
            TxtName.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(TxtName);

            lbBirth = new Label();
            lbBirth.Text = "Birthday:";
            lbBirth.Location = new System.Drawing.Point(10, 70);
            lbBirth.Size = new System.Drawing.Size(50, 20);
            this.Controls.Add(lbBirth);
            
            DtBirth = new DateTimePicker();
            DtBirth.Location = new System.Drawing.Point(80, 70);
            DtBirth.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(DtBirth);

            lbPayment = new Label();
            lbPayment.Text = "Payment:";
            lbPayment.Location = new System.Drawing.Point(10, 100);
            lbPayment.Size = new System.Drawing.Size(50, 20);
            this.Controls.Add(lbPayment);

            TxtPayment = new TextBox();
            TxtPayment.Location = new System.Drawing.Point(80, 100);
            TxtPayment.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(TxtPayment);

            lbDocument = new Label();
            lbDocument.Text = "Document:";
            lbDocument.Location = new System.Drawing.Point(10, 130);
            lbDocument.Size = new System.Drawing.Size(50, 20);
            this.Controls.Add(lbDocument);

            TxtDocument = new TextBox();
            TxtDocument.Location = new System.Drawing.Point(80, 130);
            TxtDocument.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(TxtDocument);

            lbMothersName = new Label();
            lbMothersName.Text = "Mother's Name:";
            lbMothersName.Location = new System.Drawing.Point(10, 160);
            lbMothersName.Size = new System.Drawing.Size(50, 20);
            this.Controls.Add(lbMothersName);

            TxtMothersName = new TextBox();
            TxtMothersName.Location = new System.Drawing.Point(80, 160);
            TxtMothersName.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(TxtMothersName);

            btCreate = new Button();
            btCreate.Text = "Create";
            btCreate.Location = new System.Drawing.Point(80, 200);
            btCreate.Size = new System.Drawing.Size(150, 25);
            btCreate.Click += new EventHandler(btCrt_Click);
            this.Controls.Add(btCreate);
        }
    }
}