using Models;
using Controllers;

namespace Views
{
    public class EmployeeCreate : Form
    {
        public Label lblTitle;
        public Label lblName;
        public TextBox txtName;
        public Label lblBirth;
        public DateTimePicker dtBirth;
        public Label lblPayment;
        public TextBox txtPayment;
        public Label lblDocument;
        public TextBox txtDocument;
        public Label lblMotherName;
        public TextBox txtMotherName;
        public Label lblPassword;
        public TextBox txtPassword;
        public Label lblType;
        public ComboBox cboType;
        public Button btCrt;
        public Button btClose;
        public TableLayoutPanel buttonsLayoutPanel;


        public void btCrt_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                DateTime birth = dtBirth.Value;
                int payment = Convert.ToInt32(Convert.ToDouble(txtPayment.Text));
                int document = Convert.ToInt32(txtDocument.Text);
                string motherName = txtMotherName.Text;
                string password = txtPassword.Text;
                bool type = cboType.Text == "Manager" ? true : false;

                Models.Employee employee = new Models.Employee
                (
                    name,
                    birth,
                    payment,
                    document,
                    motherName,
                    password,
                    type
                );

                Controllers.Employee.store(employee);

                MessageBox.Show("Employee registered successfully.");
                ClearForm();
            }catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
            ListEmployee EmployeeList = Application.OpenForms.OfType<ListEmployee>().FirstOrDefault();
            if (EmployeeList != null)
            {
                EmployeeList.RefreshList();
            } 
            this.Close();
        }

        private void ClearForm()
        {
            txtName.Clear();
        }

        public EmployeeCreate()
        {
            this.Text = "Cadastro funcionário";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            Color color = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            this.BackColor = color;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(300, 630);

            this.lblTitle = new Label();
            this.lblTitle.Text = "Cadastro de funcionário";
            this.lblTitle.Font = new Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(40, 30);
            this.lblTitle.Size = new Size(250, 40);

            this.lblName = new Label();
            this.lblName.Text = "Name";
            this.lblName.Location = new Point(33, lblTitle.Bottom + 10);
            this.lblName.Size = new Size(70, 20);

            this.txtName = new TextBox();
            this.txtName.Location = new Point(33, lblName.Bottom + 5);
            this.txtName.BorderStyle = BorderStyle.FixedSingle;
            this.txtName.Size = new Size(220, 20);

            this.lblBirth = new Label();
            this.lblBirth.Text = "Birth";
            this.lblBirth.Location = new Point(33, txtName.Bottom + 10);
            this.lblBirth.Size = new Size(70, 20);

            this.dtBirth = new DateTimePicker();
            this.dtBirth.Location = new Point(33, lblBirth.Bottom + 5);
            this.dtBirth.Size = new Size(220, 20);
            dtBirth.Format = DateTimePickerFormat.Short;

            this.lblPayment = new Label();
            this.lblPayment.Text = "Pagamento";
            this.lblPayment.Location = new Point(33, dtBirth.Bottom + 10);
            this.lblPayment.Size = new Size(70, 20);

            this.txtPayment = new TextBox();
            this.txtPayment.Location = new Point(33, lblPayment.Bottom + 5);
            this.txtPayment.BorderStyle = BorderStyle.FixedSingle;
            this.txtPayment.Size = new Size(220, 20);

            this.lblDocument = new Label();
            this.lblDocument.Text = "Document";
            this.lblDocument.Location = new Point(33, txtPayment.Bottom + 10);
            this.lblDocument.Size = new Size(70, 20);

            this.txtDocument = new TextBox();
            this.txtDocument.Location = new Point(33, lblDocument.Bottom + 5);
            this.txtDocument.BorderStyle = BorderStyle.FixedSingle;
            this.txtDocument.Size = new Size(220, 20);

            this.lblMotherName = new Label();
            this.lblMotherName.Text = "Mother Name";
            this.lblMotherName.Location = new Point(33, txtDocument.Bottom + 10);
            this.lblMotherName.Size = new Size(70, 20);

            this.txtMotherName = new TextBox();
            this.txtMotherName.Location = new Point(33, lblMotherName.Bottom + 5);
            this.txtMotherName.BorderStyle = BorderStyle.FixedSingle;
            this.txtMotherName.Size = new Size(220, 20);

            this.lblPassword = new Label();
            this.lblPassword.Text = "Password";
            this.lblPassword.Location = new Point(33, txtMotherName.Bottom + 10);
            this.lblPassword.Size = new Size(70, 20);

            this.txtPassword = new TextBox();
            this.txtPassword.Location = new Point(33, lblPassword.Bottom + 5);
            this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtPassword.Size = new Size(220, 20);

            this.lblType = new Label();
            this.lblType.Text = "Type";
            this.lblType.Location = new Point(33, txtPassword.Bottom + 10);
            this.lblType.Size = new Size(70, 20);

            this.cboType = new ComboBox();
            this.cboType.Location = new Point(33, lblType.Bottom + 5);
            this.cboType.Size = new Size(220, 20);
            this.cboType.Items.Add("Manager");
            this.cboType.Items.Add("Employee");
            this.cboType.SelectedIndex = -1;

            this.buttonsLayoutPanel = new TableLayoutPanel();
            this.buttonsLayoutPanel.Dock = DockStyle.Bottom;
            this.buttonsLayoutPanel.AutoSize = true;
            this.buttonsLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.buttonsLayoutPanel.Padding = new Padding(10, 10, 10, 10);
            this.buttonsLayoutPanel.BackColor = ColorTranslator.FromHtml("#3C4858");
            this.buttonsLayoutPanel.ColumnCount = 4;
            this.buttonsLayoutPanel.RowCount = 1;
            this.buttonsLayoutPanel.ColumnStyles.Clear();

            for (int i = 0; i < buttonsLayoutPanel.ColumnCount; i++)
            {
                buttonsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }

            this.btCrt = new Button();
            this.btCrt.Text = "Add";
            // this.btCrt.Location = new Point(80, cboType.Bottom + 10);
            this.btCrt.Size = new Size(110, 35);
            this.btCrt.Font = new Font("Roboto", 8, FontStyle.Regular);
            this.btCrt.FlatStyle = FlatStyle.Flat;
            this.btCrt.FlatAppearance.BorderSize = 0;
            this.btCrt.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.btCrt.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            this.btCrt.Dock = DockStyle.Fill;
            this.btCrt.Click += new EventHandler(this.btCrt_Click);

            this.btClose = new Button();
            this.btClose.Text = "Close";
            // this.btClose.Location = new Point(80, btCrt.Bottom + 10);
            this.btClose.Size = new Size(110, 35);
            this.btClose.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.btClose.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            this.btClose.Font = new Font("Roboto", 8, FontStyle.Regular);
            this.btClose.FlatStyle = FlatStyle.Flat;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.Dock = DockStyle.Fill;
            this.btClose.Click += (sender, s) =>
            {
                this.Close();
            };

            this.buttonsLayoutPanel.Controls.Add(btCrt, 2, 0); // Mudar o segundo parâmetro para 0
            this.buttonsLayoutPanel.Controls.Add(btClose, 3, 0); // Mudar o segundo parâmetro para 0

            this.Controls.Add(buttonsLayoutPanel);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.dtBirth);
            this.Controls.Add(this.lblPayment);
            this.Controls.Add(this.txtPayment);
            this.Controls.Add(this.lblDocument);
            this.Controls.Add(this.txtDocument);
            this.Controls.Add(this.lblMotherName);
            this.Controls.Add(this.txtMotherName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cboType);

 




        }
    }
}