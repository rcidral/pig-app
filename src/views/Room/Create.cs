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
               Color color = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
               this.BackColor = color;
               this.ShowIcon = false;
               this.ShowInTaskbar = false;
               this.Size = new System.Drawing.Size(300, 300);

               this.lblFloor = new Label();
               this.lblFloor.Text = "Floor";
               this.lblFloor.Location = new Point(10, 70);            
               this.lblFloor.Size = new Size(50, 20);

               this.comboBoxFloor = new ComboBox();
               this.comboBoxFloor.Location = new Point(80, 70);
               this.comboBoxFloor.Size = new Size(150, 20);
               this.comboBoxFloor.Items.Add("Selecione um Andar");
               this.comboBoxFloor.ValueMember = "Key";
               this.comboBoxFloor.DisplayMember = "Value";
               this.comboBoxFloor.DataSource = GetFloorsToComboBox();
               if (comboBoxFloor.Items.Count > 0)
               {
                    comboBoxFloor.SelectedIndex = 0;
               }


               this.lblNumber = new Label();
               this.lblNumber.Text = "Numero";
               this.lblNumber.Location = new Point(10, 40);
               this.lblNumber.Size = new Size(50, 20);

               this.comboBoxNumber = new ComboBox();
               this.comboBoxNumber.Location = new Point(80, 40);
               this.comboBoxNumber.Size = new Size(150, 20);
               this.comboBoxNumber.Items.Add("Selecione um numero");
               this.comboBoxNumber.Items.AddRange(GetNumbersRooms().ToArray());

               this.lblDescription = new Label();
               this.lblDescription.Text = "Descrição";
               this.lblDescription.Location = new Point(10, 100);
               this.lblDescription.Size = new Size(50, 20);

               this.comboBoxDescription = new ComboBox();
               this.comboBoxDescription.Location = new Point(80, 100);
               this.comboBoxDescription.Size = new Size(150, 20);
               this.comboBoxDescription.Items.Add("Solteiro");
               this.comboBoxDescription.Items.Add("Casal");
               this.comboBoxDescription.Items.Add("Dormitório");

               this.lblValue = new Label();
               this.lblValue.Text = "Valor";
               this.lblValue.Location = new Point(10, 130);
               this.lblValue.Size = new Size(50, 20);

               this.txtValue = new TextBox();
               this.txtValue.Location = new Point(80, 130);
               this.txtValue.Size = new Size(150, 20);

               this.lblColor = new Label();
               this.lblColor.Text = "Cor";
               this.lblColor.Location = new Point(10, 160);
               this.lblColor.Size = new Size(50, 20);

               this.txtColor = new TextBox();
               this.txtColor.Location = new Point(80, 160);
               this.txtColor.Size = new Size(150, 20);

               this.btCrt = new Button();
               this.btCrt.Text = "Adicionar";
               this.btCrt.Location = new Point(80, 200);
               this.btCrt.Size = new Size(150, 25);
               this.btCrt.Click += new EventHandler(this.btCrt_Click);


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