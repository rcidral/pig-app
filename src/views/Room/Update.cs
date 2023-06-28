using Models;
using Controllers;

namespace Views
{
    public class RoomUpdate : Form
    {
       public Label lblTitle;
       public Label lblNumber;
       public Label lblFloor;
       public Label lblDescription;
       public Label lblValue;
       public Label lblColor;
       public ComboBox comboBoxNumber;
       public ComboBox comboBoxFloor;
       public ComboBox comboBoxDescription;
       public TextBox txtValue;
       public TextBox txtColor;
       public TableLayoutPanel tableLayoutPanel;
       public Button btUpdate;
       public Button btClose;

       public Models.Room room;

       public void btUpdate_Click(object sender, EventArgs e)
       {
            try
            {
                int numberRoom = Convert.ToInt32(comboBoxNumber.Text);
                int floor = Convert.ToInt32(((KeyValuePair<string, string>)comboBoxFloor.SelectedItem).Key);
                string description = comboBoxDescription.Text;
                double value = Convert.ToDouble(txtValue.Text);
                string color = txtColor.Text;
            
                Models.Room room = new Models.Room(
                    floor,
                    numberRoom,
                    description,
                    value,
                    color
                );

                Controllers.Room.update(room.Number, room);

                MessageBox.Show("Room updated successfully!");
                ClearForm();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            ListRoom RoomList = Application.OpenForms.OfType<ListRoom>().FirstOrDefault();
            if (RoomList != null)
            {
                RoomList.RefreshList();
            }
            this.Close();
        }
        private void ClearForm()
        {
                txtValue.Clear();
                txtColor.Clear();
        }

        private List<KeyValuePair<int, string>> GetFloorsToComboBox()
        {
            List<KeyValuePair<int, string>> floors = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "1° Andar"),
                new KeyValuePair<int, string>(2, "2° Andar"),
                new KeyValuePair<int, string>(3, "3° Andar"),
            };

            return floors;
        }

        private List<string> GetNumbersRooms()
        {
            List<string> numbersRoomsList = new List<string>();
            int[,] numbersRooms = new int[3, 6];
            int startingNumber = 101;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                        numbersRooms[i, j] = startingNumber + (i * 100) + j;
                        numbersRoomsList.Add(numbersRooms[i, j].ToString());
                }
            }

            return numbersRoomsList;
        }

       public RoomUpdate(Models.Room room)
       {
            this.room = room;

            this.Text = "Editar quarto";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            Color color = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            this.BackColor = color;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(300, 580);

            this.lblTitle = new Label();
            this.lblTitle.Text = "Editar quarto";
            this.lblTitle.Font = new Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(40, 30);
            this.lblTitle.Size = new Size(250, 40);

            this.lblFloor = new Label();
            this.lblFloor.Text = "Andar";
            this.lblFloor.Location = new Point(33, lblTitle.Bottom + 10);            
            this.lblFloor.Size = new Size(70, 20);

            this.comboBoxFloor = new ComboBox();
            this.comboBoxFloor.Location = new Point(33, lblFloor.Bottom + 5);
            this.comboBoxFloor.Size = new Size(220, 20);
            this.comboBoxFloor.Items.Add("Selecione um Andar");
            this.comboBoxFloor.ValueMember = "Key";
            this.comboBoxFloor.DisplayMember = "Value";
            this.comboBoxFloor.DataSource = GetFloorsToComboBox();
            if (comboBoxFloor.Items.Count > 0)
            {
                comboBoxFloor.SelectedIndex = 0;
            }

            this.lblNumber = new Label();
            this.lblNumber.Text = "Número";
            this.lblNumber.Location = new Point(33, comboBoxFloor.Bottom + 10);
            this.lblNumber.Size = new Size(70, 20);

            this.comboBoxNumber = new ComboBox();
            this.comboBoxNumber.Location = new Point(33, lblNumber.Bottom + 5);
            this.comboBoxNumber.Size = new Size(220, 20);
            this.comboBoxNumber.Items.Add("Selecione um numero");
            this.comboBoxNumber.Items.AddRange(GetNumbersRooms().ToArray());

            this.lblDescription = new Label();
            this.lblDescription.Text = "Descrição";
            this.lblDescription.Location = new Point(33, comboBoxNumber.Bottom + 10);
            this.lblDescription.Size = new Size(70, 20);

            this.comboBoxDescription = new ComboBox();
            this.comboBoxDescription.Location = new Point(33, lblDescription.Bottom + 5);
            this.comboBoxDescription.Size = new Size(220, 20);
            this.comboBoxDescription.Items.Add("Solteiro");
            this.comboBoxDescription.Items.Add("Casal");
            this.comboBoxDescription.Items.Add("Dormitório");

            this.lblValue = new Label();
            this.lblValue.Text = "Valor";
            this.lblValue.Location = new Point(33, comboBoxDescription.Bottom + 10);
            this.lblValue.Size = new Size(70, 20);

            this.txtValue = new TextBox();
            this.txtValue.Location = new Point(33, lblValue.Bottom + 5);
            this.txtValue.Size = new Size(220, 20);
            this.txtValue.BorderStyle = BorderStyle.FixedSingle;

            this.lblColor = new Label();
            this.lblColor.Text = "Cor";
            this.lblColor.Location = new Point(33, txtValue.Bottom + 10);
            this.lblColor.Size = new Size(70, 20);

            this.txtColor = new TextBox();
            this.txtColor.Location = new Point(33, lblColor.Bottom + 5);
            this.txtColor.Size = new Size(220, 20);
            this.txtColor.BorderStyle = BorderStyle.FixedSingle;

            this.tableLayoutPanel = new TableLayoutPanel();
            this.tableLayoutPanel.Dock = DockStyle.Bottom;
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.Padding = new Padding(10, 10, 10, 10);
            this.tableLayoutPanel.BackColor = ColorTranslator.FromHtml("#3C4858");
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.ColumnStyles.Clear();

            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }

            this.btUpdate = new Button();
            this.btUpdate.Text = "Adicionar";
            // this.btUpdate.Location = new Point(80, cboType.Bottom + 10);
            this.btUpdate.Size = new Size(110, 35);
            this.btUpdate.Font = new Font("Roboto", 8, FontStyle.Regular);
            this.btUpdate.FlatStyle = FlatStyle.Flat;
            this.btUpdate.FlatAppearance.BorderSize = 0;
            this.btUpdate.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.btUpdate.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            this.btUpdate.Dock = DockStyle.Fill;
            this.btUpdate.Click += new EventHandler(this.btUpdate_Click);

            this.btClose = new Button();
            this.btClose.Text = "Sair";
            // this.btClose.Location = new Point(80, btUpdate.Bottom + 10);
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

            this.tableLayoutPanel.Controls.Add(btUpdate, 2, 0); 
            this.tableLayoutPanel.Controls.Add(btClose, 3, 0);

            this.Controls.Add(this.tableLayoutPanel);

            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblFloor);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.comboBoxNumber);
            this.Controls.Add(this.comboBoxFloor);
            this.Controls.Add(this.comboBoxDescription);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.btUpdate);
       }
    }
}