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
                Models.Room room = new Models.Room
                (
                    Convert.ToInt32(comboBoxNumber.Text),
                    Convert.ToInt32(comboBoxFloor.Text),
                    comboBoxDescription.Text,
                    Convert.ToDouble(txtValue.Text),
                    txtColor.Text
                );

                Controllers.Room.store(room);

                MessageBox.Show("Room resgistered successfully.");
                ClearForm();
           }catch (Exception err)
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
            this.Size = new System.Drawing.Size(280, 360);
            this.Font = new System.Drawing.Font("Arial", 25, System.Drawing.FontStyle.Bold);

            this.lblFloor = new Label();
            this.lblFloor.Text = "Floor";
            this.lblFloor.Location = new Point(10, 70);            
            this.lblFloor.Size = new Size(50, 20);
            this.lblFloor.Font = new Font("Arial", 25, System.Drawing.FontStyle.Bold);

            this.comboBoxFloor = new ComboBox();
            this.comboBoxFloor.Location = new Point(80, 70);
            this.comboBoxFloor.Size = new Size(150, 20);
            this.comboBoxFloor.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.comboBoxFloor.Items.Add("1º Floor");
            this.comboBoxFloor.Items.Add("2º Floor");
            this.comboBoxFloor.Items.Add("3º Floor");

            this.lblNumber = new Label();
            this.lblNumber.Text = "Number";
            this.lblNumber.Location = new Point(10, 40);
            this.lblNumber.Size = new Size(50, 20);
            this.lblNumber.Font = new Font("Arial", 12, System.Drawing.FontStyle.Bold);

            this.comboBoxNumber = new ComboBox();
            this.comboBoxNumber.Location = new Point(80, 40);
            this.comboBoxNumber.Size = new Size(150, 20);
            this.comboBoxNumber.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.comboBoxNumber.Items.Add("101");
            this.comboBoxNumber.Items.Add("102");
            this.comboBoxNumber.Items.Add("103");
            this.comboBoxNumber.Items.Add("201");
            this.comboBoxNumber.Items.Add("202");
            this.comboBoxNumber.Items.Add("203");
            this.comboBoxNumber.Items.Add("301");
            this.comboBoxNumber.Items.Add("302");
            this.comboBoxNumber.Items.Add("303");

            this.lblDescription = new Label();
            this.lblDescription.Text = "Description";
            this.lblDescription.Location = new Point(10, 100);
            this.lblDescription.Size = new Size(50, 20);

            this.comboBoxDescription = new ComboBox();
            this.comboBoxDescription.Location = new Point(80, 100);
            this.comboBoxDescription.Size = new Size(150, 20);
            this.comboBoxDescription.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.comboBoxDescription.Items.Add("Single");
            this.comboBoxDescription.Items.Add("Couple");
            this.comboBoxDescription.Items.Add("Dormitory");

            this.lblValue = new Label();
            this.lblValue.Text = "Value";
            this.lblValue.Location = new Point(10, 130);
            this.lblValue.Size = new Size(50, 20);
            this.lblValue.Font = new Font("Arial", 12, System.Drawing.FontStyle.Bold);

            this.txtValue = new TextBox();
            this.txtValue.Location = new Point(80, 130);
            this.txtValue.Size = new Size(150, 20);
            this.txtValue.Font = new Font("Arial", 12, System.Drawing.FontStyle.Bold);

            this.lblColor = new Label();
            this.lblColor.Text = "Color";
            this.lblColor.Location = new Point(10, 160);
            this.lblColor.Size = new Size(50, 20);
            this.lblColor.Font = new Font("Arial", 12, System.Drawing.FontStyle.Bold);

            this.txtColor = new TextBox();
            this.txtColor.Location = new Point(80, 160);
            this.txtColor.Size = new Size(150, 20);
            this.txtColor.Font = new Font("Arial", 12, System.Drawing.FontStyle.Bold);

            this.btCrt = new Button();
            this.btCrt.Text = "Add";
            this.btCrt.Location = new Point(10, 200);
            this.btCrt.Size = new Size(50, 50);
            this.btCrt.Click += new EventHandler(this.btCrt_Click);
            this.btCrt.Font = new Font("Arial", 12, System.Drawing.FontStyle.Bold);

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