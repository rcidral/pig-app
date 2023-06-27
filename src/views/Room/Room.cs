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

        private void btUpdateate_Click(object sender, EventArgs e)
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

            Button btCrt = new Button();
            btCrt.Text = "Add";
            btCrt.Size = new Size(100, 30);
            btCrt.Location = new Point(50, 330);
            btCrt.Click += new EventHandler(btCrt_Click);
            this.Controls.Add(btCrt);

            Button btUpdate = new Button();
            btUpdate.Text = "Update";
            btUpdate.Size = new Size(100, 30);
            btUpdate.Location = new Point(170, 330);
            btUpdate.Click += new EventHandler(btUpdateate_Click);
            this.Controls.Add(btUpdate);

            Button btDelete = new Button();
            btDelete.Text = "Delete";
            btDelete.Size = new Size(100, 30);
            btDelete.Location = new Point(290, 330);
            btDelete.Click += new EventHandler(btDelete_Click);
            this.Controls.Add(btDelete);

            Button btClose = new Button();
            btClose.Text = "Return";
            btClose.Size = new Size(100, 30);
            btClose.Location = new Point(410, 330);
            btClose.Click += new EventHandler(btClose_Click);
            this.Controls.Add(btClose);
        }
    }
}