using Models;
using Controllers;

namespace Views
{
    public class ListRoom : Form
    {
        public enum Option { Update, Delete }
        ListView listRoom;

        private void AddListView(Models.Room room)
        {
            string[] row = {
                room.Floor.ToString(),
                room.Number.ToString(),
                room.Description,
                room.Value.ToString(),
                room.Color
            };

            ListViewItem item = new ListViewItem(row);
            listRoom.Items.Add(item);
        }

        public void RefreshList()
        {
            listRoom.Items.Clear();

            List<Models.Room> list = Controllers.Room.index();

            foreach (Models.Room room in list)
            {
                AddListView(room);
            }
        }

        public Models.Room GetSelectedRoom(Option option)
        {
            if (listRoom.SelectedItems.Count > 0)
            {
                int selectedRoomId = int.Parse(listRoom.SelectedItems[0].Text);
                List<Models.Room> rooms = Controllers.Room.show(selectedRoomId);
                return rooms.FirstOrDefault();
            }
            else
            {
                throw new Exception($"Select a Room for {(option == Option.Update? "Update" : "Delete")}");
            }
        }

        private void btCrt_Click(object sender, EventArgs e)
        {
            var RoomCreate = new Views.RoomCreate();
            RoomCreate.Show();
        }

        private void btUpd_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Room room = GetSelectedRoom(Option.Update);
                RefreshList();
                var RoomUpdateView = new Views.RoomUpdate(room);
                if (RoomUpdateView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("Room updated successfully.");
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
                Models.Room room = GetSelectedRoom(Option.Delete);
                DialogResult result = MessageBox.Show("Do you want to delete this room?", "Confirm deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Controllers.Room.destroy(room.Floor);
                    RefreshList();
                }
            }
            catch (Exception err)
            {
               if (err.InnerException != null)
                {
                    MessageBox.Show(err.InnerException.Message);
                }
                else
                {
                    MessageBox.Show(err.Message);
                } 
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ListRoom()
        {
            this.Icon = new Icon("Assets/logoUm.ico", 52, 52);

            this.Text = "Rooms";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            Color color = System.Drawing.ColorTranslator.FromHtml("#E7E7E7");
            this.ShowIcon = true;
            this.ShowInTaskbar = false;
            this.BackColor = color;

            listRoom = new ListView();
            listRoom.Size = new Size(680, 260);
            listRoom.Location = new Point(50, 50);
            listRoom.View = View.Details;
            listRoom.Columns.Add("Floor", -2, HorizontalAlignment.Left);
            listRoom.Columns.Add("Number", -2, HorizontalAlignment.Left);
            listRoom.Columns.Add("Description", -2, HorizontalAlignment.Left);
            listRoom.Columns.Add("Value", -2, HorizontalAlignment.Left);
            listRoom.Columns.Add("Color", -2, HorizontalAlignment.Left);
            listRoom.Columns[0].Width = 60;
            listRoom.Columns[1].Width = 80;
            listRoom.Columns[2].Width = 100;
            listRoom.Columns[3].Width = 60;
            listRoom.Columns[4].Width = 60;
            listRoom.FullRowSelect = true;
            this.Controls.Add(listRoom);

            Panel panelList = new Panel();
            panelList.Size = new Size(100, 30);
            panelList.Location = new Point(50, 330);
            Color color2 = System.Drawing.ColorTranslator.FromHtml("#00000");
            panelList.BackColor = color2;

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