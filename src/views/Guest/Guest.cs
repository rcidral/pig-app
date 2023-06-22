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
            var Create = new Views.Create();
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
            this.Size = new Size (680, 260);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = true;
            this.ShowInTaskbar = false;

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