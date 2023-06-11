using Models;
using Controllers;

namespace Views
{
    public class List : Form
    {
        public enum Option {Update, Delete}
        ListView listProduct;

        private void AddListView(Models.Product product)
        {
            string[]row = {
                product.Id.ToString(),
                product.Name,
                product.Value.ToString()
            };

            ListViewItem item = new ListViewItem(row);
            listProduct.Items.Add(item);
        }

        public void RefreshList()
        {
            listProduct.Items.Clear();

            List<Models.Product> list = Controllers.Product.index();

            foreach (Models.Product product in list)
            {
                AddListView(product);
            }
        }

        private void btCrt_Click(object sender, EventArgs e)
        {
            var Create = new Views.Create();
            Create.Show();
        }

        private void btUpd_Click(object sender, EventArgs e)
        {
            try{
                
                Models.Product product = GetSelectedProduct(Option.Update);
                RefreshList();
                var ProductUpdateView = new Views.Update(product);
                if(ProductUpdateView.ShowDialog() == DialogResult.OK);
                {
                    RefreshList();
                    MessageBox.Show("Product edited successfully.");
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try{
                Models.Product product = GetSelectedProduct(Option.Delete);
                DialogResult result = MessageBox.Show("Do you really want to delete this product?", "Confirm deletion", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    Controllers.Product.destroy(product);
                    RefreshList();
                }
            }
            catch(Exception err)
            {
                if(err.InnerException != null)
                {
                    MessageBox.Show(err.InnerException.Message);
                }
                else
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        public Models.Product GetSelectedProduct(Option option)
        {
            if(listProduct.SelectedItems.Count > 0)
            {
                int selectedProductId = int.Parse(listProduct.SelectedItems[0].Text);
                return Controllers.Product.show(selectedProductId);
            }
            else{
                throw new Exception($"Select a Product for {(option == Option.Update ? "udpate" : "delete")}");
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public List()
        {
            this.Text = "Products";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            listProduct = new ListView();
            listProduct.Size = new Size(680, 260);
            listProduct.Location = new Point(50, 50);
            listProduct.View = View.Details;
            listProduct.Columns.Add("Id");
            listProduct.Columns.Add("Name");
            listProduct.Columns.Add("Value");
            listProduct.FullRowSelect = true;
            this.Controls.Add(listProduct);

            RefreshList();

            Button btCrt = new Button();
            btCrt.Text = "Add";
            btCrt.Size = new Size(100, 30);
            btCrt.Location = new Point(50, 330);
            btCrt.Click += new EventHandler(btCrt_Click);
            this.Controls.Add(btCrt);

            Button btUpd = new Button();
            btUpd.Text = "Update";
            btUpd.Size = new Size(100, 30);
            btUpd.Location = new Point(170, 330);
            btUpd.Click += new EventHandler(btUpd_Click);
            this.Controls.Add(btUpd);

            Button btDelete = new Button();
            btDelete.Text = "Delete";
            btDelete.Size = new Size(100, 30);
            btDelete.Location = new Point(290, 330);
            btDelete.Click += new EventHandler(btDelete_Click);
            this.Controls.Add(btDelete);

            Button btClose = new Button();
            btClose.Text = "Return";
            btClose.Size = new Size(100, 30);
            btClose.Location = new Point(290, 330);
            btClose.Click += new EventHandler(btClose_Click);
            this.Controls.Add(btClose);
        }
    }
}