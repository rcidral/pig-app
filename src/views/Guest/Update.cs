using Models;
using Controllers;

namespace Views
{
    public class UpdateGuest : Form
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
        public Button btCancel;

        public Models.Guest guest;

        private void btUpd_Click(object sender, EventArgs e)
        {
            Models.Guest guestToUpdate = this.guest;
            guestToUpdate.Name = TxtName.Text;
            guestToUpdate.Birth = DtBirth.Value;
            guestToUpdate.Payment = Convert.ToInt32(Convert.ToDouble(TxtPayment.Text));
            guestToUpdate.Document = Convert.ToInt32(TxtDocument.Text);
            guestToUpdate.MothersName = TxtMothersName.Text;

            Controllers.Guest.update(guestToUpdate.Id, guestToUpdate);

            List Guest = Application.OpenForms.OfType<List>().FirstOrDefault();
            if (Guest != null)
            {
                Guest.RefreshList();
            }
            this.Close();



        }

        public UpdateGuest(Models.Guest guest)
        {
            this.guest = guest;

            this.Text = "Register a Guest";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            Color color = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(280, 360);
            this.Font = new System.Drawing.Font("Arial", 25, System.Drawing.FontStyle.Bold);

            lbName = new Label();
            lbName.Text = "Name:";
            lbName.Location = new System.Drawing.Point(20, 20);
            lbName.Size = new System.Drawing.Size(60, 20);
            this.Controls.Add(lbName);

            lbBirth = new Label();
            lbBirth.Text = "Birthdate:";
            lbBirth.Location = new System.Drawing.Point(20, 60);
            lbBirth.Size = new System.Drawing.Size(60, 20);
            this.Controls.Add(lbBirth);

            lbPayment = new Label();
            lbPayment.Text = "Payment:";
            lbPayment.Location = new System.Drawing.Point(20, 100);
            lbPayment.Size = new System.Drawing.Size(60, 20);
            this.Controls.Add(lbPayment);

            lbDocument = new Label();
            lbDocument.Text = "Document:";
            lbDocument.Location = new System.Drawing.Point(20, 140);
            lbDocument.Size = new System.Drawing.Size(60, 20);
            this.Controls.Add(lbDocument);

            lbMothersName = new Label();
            lbMothersName.Text = "Mother's Name:";
            lbMothersName.Location = new System.Drawing.Point(20, 180);
            lbMothersName.Size = new System.Drawing.Size(90, 20);
            this.Controls.Add(lbMothersName);

            TxtName = new TextBox();
            TxtName.Location = new System.Drawing.Point(120, 20);
            TxtName.Size = new System.Drawing.Size(120, 20);
            this.Controls.Add(TxtName);

            DtBirth = new DateTimePicker();
            DtBirth.Location = new System.Drawing.Point(120, 60);
            DtBirth.Size = new System.Drawing.Size(120, 20);
            this.Controls.Add(DtBirth);

            TxtPayment = new TextBox();
            TxtPayment.Location = new System.Drawing.Point(120, 100);
            TxtPayment.Size = new System.Drawing.Size(120, 20);
            this.Controls.Add(TxtPayment);

            TxtDocument = new TextBox();
            TxtDocument.Location = new System.Drawing.Point(120, 140);
            TxtDocument.Size = new System.Drawing.Size(120, 20);
            this.Controls.Add(TxtDocument);

            TxtMothersName = new TextBox();
            TxtMothersName.Location = new System.Drawing.Point(120, 180);
            TxtMothersName.Size = new System.Drawing.Size(120, 20);
            this.Controls.Add(TxtMothersName);

            btCreate = new Button();
            btCreate.Text = "Create";
            btCreate.Location = new System.Drawing.Point(20, 220);
            btCreate.Size = new System.Drawing.Size(80, 30);
            btCreate.Click += new EventHandler(btUpd_Click);
            this.Controls.Add(btCreate);

            btCancel = new Button();
            btCancel.Text = "Cancel";
            btCancel.Location = new System.Drawing.Point(120, 220);
            btCancel.Size = new System.Drawing.Size(80, 30);
            this.Controls.Add(btCancel);
        }

    }
}