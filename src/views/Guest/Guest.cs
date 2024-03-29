using System;
using Models;
using Controllers;

namespace Views
{
    public class ListGuest : Form
    {
        public enum Options {Update, Delete}

        ListView listGuest;

        private void AddListView(Models.Guest guest)
        {
            string[] row = {
                guest.Id.ToString(),
                guest.Name,
                guest.Birth.ToString(),
                guest.Payment.ToString(),
                guest.Document.ToString(),
                guest.MothersName

            };

            ListViewItem item = new ListViewItem(row);
            listGuest.Items.Add(item);
        }

        public void RefreshList()
        {
            listGuest.Items.Clear();

            List<Models.Guest> list = Controllers.Guest.index();

            foreach(Models.Guest guest in list)
            {
                AddListView(guest);
            }
        }

        private void btCrt_Click(object sender, EventArgs e)
        {
            var Create = new Views.CreateGuest();
            Create.Show();
        }

        private void btUpd_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Guest guest = GetSelectedGuest(Options.Update);
                RefreshList();
                var GuestUpdateView =  new Views.UpdateGuest(guest);
                if (GuestUpdateView.ShowDialog() == DialogResult.OK) 
                {
                    
                    RefreshList();
                    MessageBox.Show("Guest updated successfully!");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Guest guest = GetSelectedGuest(Options.Delete);
                DialogResult result = MessageBox.Show("Do you really want to delete this guest?", "Confirm deletion", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    Controllers.Guest.destroy(guest.Id);
                    RefreshList();
                }
                
            }
            catch (Exception err)
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

        public Models.Guest GetSelectedGuest(Options options)
        {
            if(listGuest.SelectedItems.Count > 0)
            {
                int selectedGuestId = int.Parse(listGuest.SelectedItems[0].Text);
                List<Models.Guest> guest = Controllers.Guest.show(selectedGuestId);
                return guest.FirstOrDefault();

            }
            else
            {
                throw new Exception($"Select a guest for {(options == Options.Update ? "udpate" : "delete")}");
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ListGuest()
        {
            this.Icon = new Icon("Assets/logoUm.ico", 52, 52);

            this.Text = "Guest";
            this.Size = new Size (800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = true;
            this.ShowInTaskbar = false;

            listGuest = new ListView();
            listGuest.Size = new Size(680, 260);
            listGuest.Location = new Point(50,50);
            listGuest.View = View.Details;
            listGuest.Columns.Add("Id");
            listGuest.Columns.Add("Name");
            listGuest.Columns.Add("Birth");
            listGuest.Columns.Add("Payment");
            listGuest.Columns.Add("Document");
            listGuest.Columns.Add("Mother's Name");
            listGuest.Columns[0].Width = 30;
            listGuest.Columns[1].Width = 60;
            listGuest.Columns[2].Width = 60;
            listGuest.Columns[3].Width = 80;
            listGuest.Columns[4].Width = 80;
            listGuest.Columns[5].Width = 120;
            listGuest.FullRowSelect = true;
            this.Controls.Add(listGuest);

            RefreshList();

            TableLayoutPanel layoutPanel = new TableLayoutPanel();
            layoutPanel.Dock = DockStyle.Bottom;
            layoutPanel.AutoSize = true;
            layoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutPanel.Padding = new Padding(10, 10, 10, 10);
            layoutPanel.BackColor = ColorTranslator.FromHtml("#3C4858");
            layoutPanel.ColumnCount = 4;
            layoutPanel.RowCount = 1;
            layoutPanel.ColumnStyles.Clear();

            for (int i = 0; i < layoutPanel.ColumnCount; i++)
            {
                layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }

            Button btCrt = new Button();
            btCrt.Text = "Adicionar";
            btCrt.Size = new Size(30, 30);
            // btCrt.Location = new Point(50, 330);
            btCrt.Font = new Font("Roboto", 8, FontStyle.Regular);
            btCrt.FlatStyle = FlatStyle.Flat;
            btCrt.FlatAppearance.BorderSize = 0;
            btCrt.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btCrt.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btCrt.Dock = DockStyle.Fill;
            btCrt.Click += new EventHandler(btCrt_Click);
            
            Button btUpd = new Button();
            btUpd.Text = "Editar";
            btUpd.Size = new Size(30, 30);
            //btUpd.Location = new Point(170, 330);
            btUpd.Font = new Font("Roboto", 8, FontStyle.Regular);
            btUpd.FlatStyle = FlatStyle.Flat;
            btUpd.FlatAppearance.BorderSize = 0;
            btUpd.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btUpd.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btUpd.Dock = DockStyle.Fill;
            btUpd.Click += new EventHandler(btUpd_Click);
            this.Controls.Add(btUpd);

            Button btDelete = new Button();
            btDelete.Text = "Deletar";
            btDelete.Size = new Size(30, 30);
            // btDelete.Location = new Point(290, 330);
            btDelete.Font = new Font("Roboto", 8, FontStyle.Regular);
            btDelete.FlatStyle = FlatStyle.Flat;
            btDelete.FlatAppearance.BorderSize = 0;
            btDelete.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btDelete.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btDelete.Dock = DockStyle.Fill;
            btDelete.Click += new EventHandler(btDelete_Click);
            this.Controls.Add(btDelete);

            Button btClose = new Button();
            btClose.Text = "Voltar";
            btClose.Size = new Size(30, 30);
            // btClose.Location = new Point(410, 330);
            btClose.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btClose.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btClose.Font = new Font("Roboto", 8, FontStyle.Regular);
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.FlatAppearance.BorderSize = 0;
            btClose.Dock = DockStyle.Fill;
            btClose.Click += (sender, s) =>
            {
                this.Close();
            };
            
            layoutPanel.Controls.Add(btCrt, 0, 0);
            layoutPanel.Controls.Add(btUpd, 1, 0);
            layoutPanel.Controls.Add(btDelete, 2, 0);
            layoutPanel.Controls.Add(btClose, 3, 0); 
            this.Controls.Add(layoutPanel);

        }
    }
}