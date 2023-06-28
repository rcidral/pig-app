using Models;
using Controllers;

namespace Views
{
    public class Update : Form
    {
        public Label lblTitle;
        public Label lblName;
        public TextBox txtName;
        public Label lblValue;
        public TextBox txtValue;
        public Button btUpd;
        public Button btClose;
        public TableLayoutPanel buttonsLayoutPanel;
        public Models.Product product;

        private void btUpd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                double value = Convert.ToDouble(txtValue.Text);

                Models.Product product = new Models.Product(
                    name,
                    value
                );

                Controllers.Product.Store(product);

                MessageBox.Show("Product registered successfully.");
                ClearForm();
            }catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            List Product = Application.OpenForms.OfType<List>().FirstOrDefault();
            if (Product != null)
            {
                Product.RefreshList();
            }
            this.Close();
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtValue.Clear();
        }
        public Update(Models.Product product)
        {
            this.product = product;

            this.Text = "Register a product";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            Color color = System.Drawing.ColorTranslator.FromHtml("#E7E7E7");
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(300, 250);

            this.lblTitle = new Label();
            this.lblTitle.Text = "Cadastro de produtos";
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

            this.lblValue = new Label();
            this.lblValue.Text = "Valor";
            this.lblValue.Location = new Point(33, txtName.Bottom + 10);
            this.lblValue.Size = new Size(70, 20);

            this.txtValue = new TextBox();
            this.txtValue.Location = new Point(33, lblValue.Bottom + 5);
            this.txtValue.Size = new Size(220, 20);
            this.txtValue.BorderStyle = BorderStyle.FixedSingle;


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

            this.btUpd = new Button();
            this.btUpd.Text = "Add";
            // this.btUpd.Location = new Point(80, cboType.Bottom + 10);
            this.btUpd.Size = new Size(110, 35);
            this.btUpd.Font = new Font("Roboto", 8, FontStyle.Regular);
            this.btUpd.FlatStyle = FlatStyle.Flat;
            this.btUpd.FlatAppearance.BorderSize = 0;
            this.btUpd.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.btUpd.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            this.btUpd.Dock = DockStyle.Fill;
            this.btUpd.Click += new EventHandler(this.btUpd_Click);

            this.btClose = new Button();
            this.btClose.Text = "Close";
            // this.btClose.Location = new Point(80, btUpd.Bottom + 10);
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

            this.buttonsLayoutPanel.Controls.Add(btUpd, 2, 0); // Mudar o segundo parâmetro para 0
            this.buttonsLayoutPanel.Controls.Add(btClose, 3, 0); // Mudar o segundo parâmetro para 0

            this.Controls.Add(buttonsLayoutPanel);

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblValue);
            this.Controls.Add(txtValue);
        }
    }
}