using Controllers;
using Models;

namespace Views
{
    public class Create : Form
    {
        public Label lblId;
        public TextBox txtId;
        public Label lblName;
        public TextBox txtName;
        public Label lblValue;
        public TextBox txtValue;
        public Button btCrt;

        public void btCrt_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Product product = new Models.Product
                (
                    txtName.Text,
                    Convert.ToDouble(txtValue.Text)
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
            txtId.Clear();
            txtName.Clear();
            txtValue.Clear();
        }

        public Create()
        {
            this.Text = "Register a product";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(280, 360);

            this.lblId = new Label();
            this.lblId.Text = "Id";
            this.lblId.Location = new Point(10, 40);
            this.lblId.Size = new Size(50, 20);

            this.txtId = new TextBox();
            this.txtId.Location = new Point(80, 40);
            this.txtId.Size = new Size(150, 20);

            this.lblName = new Label();
            this.lblName.Text = "Name";
            this.lblName.Location = new Point(10, 70);
            this.lblName.Size = new Size(50, 20);

            this.txtName = new TextBox();
            this.txtName.Location = new Point(80, 70);
            this.txtName.Size = new Size(150, 20);

            this.lblValue = new Label();
            this.lblValue.Text = "Value";
            this.lblValue.Location = new Point(10, 100);
            this.lblValue.Size = new Size(50, 20);

            this.txtValue = new TextBox();
            this.txtValue.Location = new Point(80, 100);
            this.txtValue.Size = new Size(150, 20);

            this.btCrt = new Button();
            this.btCrt.Text = "Add";
            this.btCrt.Location = new Point(10, 150);
            this.btCrt.Size = new Size(50, 20);

            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btCrt);
        }
    }
}