using Controllers;
using Models;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Views
{
    public class CheckIn : Form
    {

        public Label titleLabel;
        public Label clientLabel;
        public ComboBox clientCbo;
        public Label daysStayLabel;
        public ComboBox daysStayCbo;
        public Label checkInLabel;
        public DateTimePicker checkInDTPicker;
        public Label checkOutLabel;
        public DateTimePicker checkOutDTPicker;
        private List<Dictionary<string, object>> quantityDays;
        public Label roomLabel;
        public Label titleMessageBox;
        public Button confirmBtnMessageBox;
        public Button cancelBtnMessageBox;

        // MainScreen mainScreen = new MainScreen();
        public bool statusReservation { get; set; } = false;

        






        public List<KeyValuePair<int, string>> GetDaysStayToComboBox()
        {
            List<KeyValuePair<int, string>> quantityDays = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "1 dia"),
                new KeyValuePair<int, string>(2, "2 dias"),
                new KeyValuePair<int, string>(3, "3 dias"),
                new KeyValuePair<int, string>(4, "4 dias"),
                new KeyValuePair<int, string>(5, "5 dias"),
                new KeyValuePair<int, string>(6, "6 dias"),
                new KeyValuePair<int, string>(7, "7 dias")
            };

            return quantityDays;
        }

        public static List<Models.Guest> GetGuestsToComboBox(){
            List<Models.Guest> guests = new List<Models.Guest>();
            foreach(Models.Guest guest in Controllers.Guest.index()){
                if((guest.Id != 0) && (guest.Name != null)){
                    guests.Add(guest);
                }
            }

            return guests;
        }


        public void SaveCheckIn(int idRoom)
        {
            try
            {
                List<Models.Room> rooms = Controllers.Room.show(idRoom);
                Models.Room room = rooms[0];
                int guestId = Convert.ToInt32(clientCbo.SelectedValue);
                int daysStay = Convert.ToInt32(((KeyValuePair<int, string>)daysStayCbo.SelectedItem).Key);
                DateTime checkIn = checkInDTPicker.Value; 
                    
                double total = room.Value * daysStay;

                Models.Reservation reservation = new Models.Reservation(
                    guestId,
                    room.Number,
                    daysStay,
                    checkIn,
                    total
                );

                Controllers.Reservation.store(reservation);  

                // var mainScreen = new MainScreen(true);
                // mainScreen.Show();         

                this.Close();

                MessageBox.Show("Reserva realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao realizar reserva!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw e;
            }
        }

        public void ConfirmCheckIn(int idRoom)
        {
            // MainScreen mainScreen = new MainScreen(true);

            List<Models.Room> rooms = Controllers.Room.show(idRoom);
            Models.Room room = rooms[0];
            
            Form formConfirmCheckIn = new Form();
            formConfirmCheckIn.Text = "Confirmação de Reserva " + room.Number;
            formConfirmCheckIn.Size = new Size(350, 400);
            formConfirmCheckIn.StartPosition = FormStartPosition.CenterScreen;
            formConfirmCheckIn.FormBorderStyle = FormBorderStyle.FixedSingle;
            formConfirmCheckIn.MaximizeBox = false;
            formConfirmCheckIn.BackColor = ColorTranslator.FromHtml("#E0E6ED");


            DateTime checkIn = checkInDTPicker.Value;

            Label titleMessageBox = new Label();
            titleMessageBox.Text = "Confirmar reserva";
            titleMessageBox.AutoSize = true;
            titleMessageBox.Location = new Point(30, 30);
            titleMessageBox.Location = new Point((this.ClientSize.Width - titleMessageBox.Width) / 6, 40);
            titleMessageBox.Font = new Font("Arial", 16, FontStyle.Bold);
            titleMessageBox.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            formConfirmCheckIn.Controls.Add(titleMessageBox);

            ListBox listBox = new ListBox();
            listBox.Location = new Point(45, 120);
            listBox.Size = new Size(250, 120);
            listBox.Font = new Font("Arial", 11, FontStyle.Regular);
            listBox.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            listBox.BorderStyle = BorderStyle.None;
            listBox.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            listBox.Margin = new Padding(listBox.Margin.Left, listBox.Margin.Top + 10, listBox.Margin.Right, listBox.Margin.Bottom);


            listBox.Items.Add("Hospede: " + clientCbo.SelectedValue.ToString());
            listBox.Items.Add("Quarto: " + idRoom);
            listBox.Items.Add("Dias: " + Convert.ToInt32(((KeyValuePair<int, string>)daysStayCbo.SelectedItem).Key));
            listBox.Items.Add("CheckIn: " + checkIn.Date.ToString("dd/MM"));
            listBox.Items.Add("CheckOut: " + checkInDTPicker.Value.AddDays(Convert.ToInt32(((KeyValuePair<int, string>)daysStayCbo.SelectedItem).Key)));
            listBox.Items.Add("Valor: " + room.Value * Convert.ToInt32(((KeyValuePair<int, string>)daysStayCbo.SelectedItem).Key));

            formConfirmCheckIn.Controls.Add(listBox);

            Button confirmBtnMessageBox = new Button();
            confirmBtnMessageBox.Text = "Confirmar";
            confirmBtnMessageBox.Size = new Size(100, 30);
            confirmBtnMessageBox.Location = new Point(95, 300);
            confirmBtnMessageBox.Font = new Font("Roboto", 8, FontStyle.Regular);
            confirmBtnMessageBox.FlatStyle = FlatStyle.Flat;
            confirmBtnMessageBox.Click += (sender, e) =>
            {
                SaveCheckIn(idRoom);
                formConfirmCheckIn.Close();
            };
            formConfirmCheckIn.Controls.Add(confirmBtnMessageBox);

            Button cancelBtnMessageBox = new Button();
            cancelBtnMessageBox.Text = "Cancelar";
            cancelBtnMessageBox.Size = new Size(100, 30);
            cancelBtnMessageBox.Location = new Point(200, 300);
            cancelBtnMessageBox.FlatStyle = FlatStyle.Flat;
            cancelBtnMessageBox.Click += (sender, e) =>
            {
                formConfirmCheckIn.Close();
            };
            formConfirmCheckIn.Controls.Add(cancelBtnMessageBox);

            formConfirmCheckIn.ShowDialog();
        }

        public CheckIn(int roomId)
        {

            this.Icon = new Icon("Assets/logoUm.ico", 30, 30);
            this.Text = "Reserva";
            this.Size = new Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");

            this.titleLabel = new Label();
            titleLabel.Text = "Reserva" + " - " + roomId;
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point((this.ClientSize.Width - titleLabel.Width) / 6, 40);
            titleLabel.Font = new Font("Arial", 20, FontStyle.Bold);
            titleLabel.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            this.Controls.Add(titleLabel);

            this.clientLabel = new Label();
            clientLabel.Text = "Hospede:";
            clientLabel.AutoSize = true;
            clientLabel.Location = new Point((this.ClientSize.Width - clientLabel.Width) / 6, titleLabel.Bottom + 30);
            this.Controls.Add(clientLabel);

            this.clientCbo = new ComboBox();
            clientCbo.Size = new Size(160, 35);
            clientCbo.BackColor = ColorTranslator.FromHtml("#f7f7f7");
            clientCbo.Location = new Point((this.ClientSize.Width - clientCbo.Width) / 5, clientLabel.Bottom + 3);
            clientCbo.DropDownStyle = ComboBoxStyle.DropDownList;
            clientCbo.FlatStyle = FlatStyle.Flat;
            clientCbo.Font = new Font("Arial", 12, FontStyle.Regular);
            clientCbo.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            clientCbo.Items.Add("Selecione um hospede");
            clientCbo.ValueMember = "Id";
            clientCbo.DisplayMember = "Name";
            clientCbo.DataSource = GetGuestsToComboBox();
            if (clientCbo.Items.Count > 0)
            {
                clientCbo.SelectedIndex = 0;
            }
            this.Controls.Add(clientCbo);

            this.daysStayLabel = new Label();
            daysStayLabel.Text = "Estadia:";
            daysStayLabel.AutoSize = true;
            daysStayLabel.Location = new Point(clientCbo.Right + 40, titleLabel.Bottom + 30);
            this.Controls.Add(daysStayLabel);

            this.daysStayCbo = new ComboBox(); ;
            daysStayCbo.Size = new Size(100, 35);
            daysStayCbo.BackColor = ColorTranslator.FromHtml("#f7f7f7");
            daysStayCbo.Location = new Point(clientCbo.Right + 40, daysStayLabel.Bottom + 3);
            daysStayCbo.DropDownStyle = ComboBoxStyle.DropDownList;
            daysStayCbo.FlatStyle = FlatStyle.Flat;
            daysStayCbo.Font = new Font("Arial", 12, FontStyle.Regular);
            daysStayCbo.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            daysStayCbo.ValueMember = "Key";
            daysStayCbo.DisplayMember = "Value";
            daysStayCbo.DataSource = GetDaysStayToComboBox();
            if (daysStayCbo.Items.Count > 0)
            {
                daysStayCbo.SelectedIndex = 0;
            }

            this.Controls.Add(daysStayCbo);

            this.checkInLabel = new Label();
            checkInLabel.Text = "Check-in:";
            checkInLabel.AutoSize = true;
            checkInLabel.Location = new Point((this.ClientSize.Width - checkInLabel.Width) / 6, daysStayCbo.Bottom + 20);
            this.Controls.Add(checkInLabel);

            this.checkInDTPicker = new DateTimePicker();
            checkInDTPicker.Size = new Size(130, 35);
            checkInDTPicker.Location = new Point((this.ClientSize.Width - checkInDTPicker.Width) / 5, checkInLabel.Bottom + 3);
            checkInDTPicker.Font = new Font("Arial", 12, FontStyle.Regular);
            checkInDTPicker.Format = DateTimePickerFormat.Short;
            checkInDTPicker.Value = DateTime.Now;
            checkInDTPicker.MinDate = DateTime.Today; 
            this.Controls.Add(checkInDTPicker);



            TableLayoutPanel buttonsLayoutPanel = new TableLayoutPanel();
            buttonsLayoutPanel.Dock = DockStyle.Bottom;
            buttonsLayoutPanel.AutoSize = true;
            buttonsLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonsLayoutPanel.Padding = new Padding(25, 10, 25, 10);
            buttonsLayoutPanel.BackColor = ColorTranslator.FromHtml("#3C4858");
            buttonsLayoutPanel.ColumnCount = 4;
            buttonsLayoutPanel.RowCount = 1;
            buttonsLayoutPanel.ColumnStyles.Clear();
            buttonsLayoutPanel.RowStyles.Clear();
            this.Controls.Add(buttonsLayoutPanel);

            for (int i = 0; i < buttonsLayoutPanel.ColumnCount; i++)
            {
                buttonsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }

            Button btnReserve = new Button();
            btnReserve.Text = "Cadastrar";
            btnReserve.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btnReserve.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btnReserve.Size = new Size(100, 30);
            btnReserve.Font = new Font("Roboto", 8, FontStyle.Regular);
            btnReserve.FlatStyle = FlatStyle.Flat;
            btnReserve.FlatAppearance.BorderSize = 0;
            btnReserve.Dock = DockStyle.Fill;
            btnReserve.Click += (sender, e) =>
            {
                ConfirmCheckIn(roomId);
                // var toMainScreen1 = new MainScreen(true);
                // toMainScreen1.Close();
            };
            buttonsLayoutPanel.Controls.Add(btnReserve, 2, 0);

            Button btnExit = new Button();
            btnExit.Text = "Sair";
            btnExit.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btnExit.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btnExit.Size = new Size(100, 30);
            btnExit.Font = new Font("Roboto", 8, FontStyle.Regular);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.Dock = DockStyle.Fill;
            btnExit.Click += (sender, e) =>
            {
                this.Close();
            };

            buttonsLayoutPanel.Controls.Add(btnExit, 3, 0);

        }


    }

}