using Models;
using Controllers;

namespace Views
{
    public class Update : Form
    {
        public Label lblName;
        public TextBox txtName;
        public Label lblValue;
        public TextBox txtValue;
        public Button btUpd;

        public Models.Product product;

        private void btUpd_Click(object sender, EventArgs e)
        {
            Models.Product productToUpdate = this.product;
            productToUpdate.Name = this.txtName.Text;
            productToUpdate.Value = Convert.ToInt32(this.txtValue.Text);

            Controllers.Product.update(productToUpdate.Id, productToUpdate);

            List Product = Application.OpenForms.OfType<List>().FirstOrDefault();
            if (Product != null)
            {
                Product.RefreshList();
            }
            this.Close();
        }

        public Update(Models.Product product)
        {
            this.product = product;

            this.Text = "Register a product";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(280, 360);

            this.lblName = new Label();
            this.lblName.Text = "Name";
            this.lblName.Location = new Point(10, 70);
            this.lblName.Size = new Size(50, 20);

            this.txtName = new TextBox();
            this.txtName.Text = product.Name;
            this.txtName.Location = new Point(80, 70);
            this.txtName.Size = new Size(150, 20);

            this.lblValue = new Label();
            this.lblValue.Text = "Value";
            this.lblValue.Location = new Point(10, 100);
            this.lblValue.Size = new Size(50, 20);

            this.txtValue = new TextBox();
            this.txtValue.Text = product.Value.ToString();
            this.txtValue.Location = new Point(80, 100);
            this.txtValue.Size = new Size(150, 20);

            this.btUpd = new Button();
            this.btUpd.Text = "Add";
            this.btUpd.Location = new Point(10, 150);
            this.btUpd.Size = new Size(50, 20);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btUpd);
        }
    }
}