using Models;
using Controllers;

namespace Views
{
    public class RoomCreate : Form
    {
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
       public Button btCrt;

          public void btCrt_Click(object sender, EventArgs e)
          {
               try
               {
                    int numberRoom = Convert.ToInt32(comboBoxNumber.Text);
                    int floor = Convert.ToInt32(((KeyValuePair<int, string>)comboBoxFloor.SelectedItem).Key);
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

                    Controllers.Room.store(room);

                    MessageBox.Show("Room resgistered successfully.");
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


               
          public RoomCreate()
          {
               this.Text = "Register room";
               this.StartPosition = FormStartPosition.CenterScreen;
               this.FormBorderStyle = FormBorderStyle.FixedSingle;
               this.MaximizeBox = false;
               this.MinimizeBox = false;
               this.ShowIcon = false;
               this.ShowInTaskbar = false;
               this.Size = new System.Drawing.Size(350, 400);
               this.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");

               this.lblFloor = new Label();
               this.lblFloor.Text = "Floor";
               this.lblFloor.Location = new Point(40, 40);            
               this.lblFloor.AutoSize = true;

               this.comboBoxFloor = new ComboBox();
               this.comboBoxFloor.Location = new Point(100, 40);
               this.comboBoxFloor.AutoSize = true;
               this.comboBoxFloor.Items.Add("Selecione um Andar");
               this.comboBoxFloor.BackColor = ColorTranslator.FromHtml("#f7f7f7");
               this.comboBoxFloor.ValueMember = "Key";
               this.comboBoxFloor.DisplayMember = "Value";
               this.comboBoxFloor.DataSource = GetFloorsToComboBox();
               if (comboBoxFloor.Items.Count > 0)
               {
                    comboBoxFloor.SelectedIndex = 0;
               }

               this.lblNumber = new Label();
               this.lblNumber.Text = "Número";
               this.lblNumber.Location = new Point(40, 70);
               this.lblNumber.AutoSize = true;

               this.comboBoxNumber = new ComboBox();
               this.comboBoxNumber.Location = new Point(100, 70);
               this.comboBoxNumber.AutoSize = true;
               this.comboBoxNumber.Items.Add("Selecione um numero");
               this.comboBoxNumber.Items.AddRange(GetNumbersRooms().ToArray());

               this.lblDescription = new Label();
               this.lblDescription.Text = "Descrição";
               this.lblDescription.Location = new Point(40, 100);
               this.lblDescription.AutoSize = true;

               this.comboBoxDescription = new ComboBox();
               this.comboBoxDescription.Location = new Point(100, 100);
               this.comboBoxDescription.AutoSize = true;
               this.comboBoxDescription.Items.Add("Solteiro");
               this.comboBoxDescription.Items.Add("Casal");
               this.comboBoxDescription.Items.Add("Dormitório");


               this.lblValue = new Label();
               this.lblValue.Text = "Valor";
               this.lblValue.Location = new Point(40, 130);
               this.lblValue.AutoSize = true;

               this.txtValue = new TextBox();
               this.txtValue.Location = new Point(100, 130);
               this.txtValue.AutoSize = true;

               this.lblColor = new Label();
               this.lblColor.Text = "Cor";
               this.lblColor.Location = new Point(40, 160);
               this.lblColor.AutoSize = true;

               this.txtColor = new TextBox();
               this.txtColor.Location = new Point(100, 160);
               this.txtColor.AutoSize = true;

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

               this.btCrt = new Button();
               this.btCrt.Text = "Adicionar";
               this.btCrt.BackColor = ColorTranslator.FromHtml("#E0E6ED");
               this.btCrt.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
               this.btCrt.Font = new Font("Roboto", 8, FontStyle.Regular);
               this.btCrt.FlatStyle = FlatStyle.Flat;
               this.btCrt.Location = new Point(100, 280);
               this.btCrt.AutoSize = true;
               this.btCrt.Click += new EventHandler(this.btCrt_Click);

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
               this.Controls.Add(this.btCrt);
          }
    }
}