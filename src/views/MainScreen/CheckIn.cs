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




        public List<Dictionary<string, object>> GetDaysStayToComboBox()
        {
            quantityDays = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>() { { "Text", "1 dia" }, { "Value", 1 } },
                new Dictionary<string, object>() { { "Text", "2 dias" }, { "Value", 2 } },
                new Dictionary<string, object>() { { "Text", "3 dias" }, { "Value", 3 } },
                new Dictionary<string, object>() { { "Text", "4 dias" }, { "Value", 4 } },
                new Dictionary<string, object>() { { "Text", "5 dias" }, { "Value", 5 } },
                new Dictionary<string, object>() { { "Text", "6 dias" }, { "Value", 6 } },
                new Dictionary<string, object>() { { "Text", "7 dias" }, { "Value", 7 } }
            };

            return quantityDays;
        }

        public DateTime CalculateCheckOutDate()
        {
            int daysStay = Convert.ToInt32(daysStayCbo.SelectedItem);
            DateTime checkIn = checkInDTPicker.Value;
            DateTime checkOut = checkIn.AddDays(daysStay);
            return checkOut;
        }


        public void SaveCheckIn()
        {
            try
            {
                int daysStay = Convert.ToInt32(daysStayCbo.SelectedItem);
                DateTime checkIn = checkInDTPicker.Value;
                DateTime checkOut = checkIn.AddDays(daysStay);
                int client = Convert.ToInt32(clientCbo.SelectedValue);
                int room = Convert.ToInt32(roomLabel.Text);
                Controller.store(checkIn, checkOut, client, room);
                MessageBox.Show("Reserva realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao realizar reserva!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw e;
            }
        }

        public CheckIn(string roomId)
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
            titleLabel.Text = "Reserva";
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point((this.ClientSize.Width - titleLabel.Width) / 5, 40);
            titleLabel.Font = new Font("Arial", 20, FontStyle.Bold);
            titleLabel.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            this.Controls.Add(titleLabel);

            this.roomLabel = new Label();
            roomLabel.Text = roomId;
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point((this.ClientSize.Width - titleLabel.Width) / 5, 40);
            titleLabel.Font = new Font("Arial", 20, FontStyle.Bold);
            titleLabel.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            this.Controls.Add(titleLabel);

            this.clientLabel = new Label();
            clientLabel.Text = "Hospede:";
            clientLabel.AutoSize = true;
            clientLabel.Location = new Point((this.ClientSize.Width - clientLabel.Width) / 5, titleLabel.Bottom + 30);
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
            clientCbo.SelectedIndex = 0;
            this.Controls.Add(clientCbo);

            this.daysStayLabel = new Label();
            daysStayLabel.Text = "Estadia:";
            daysStayLabel.AutoSize = true;
            daysStayLabel.Location = new Point(clientCbo.Right + 30, titleLabel.Bottom + 30);
            this.Controls.Add(daysStayLabel);

            this.daysStayCbo = new ComboBox();;
            daysStayCbo.Size = new Size(100, 35); 
            daysStayCbo.BackColor = ColorTranslator.FromHtml("#f7f7f7");
            daysStayCbo.Location = new Point(clientCbo.Right + 40, daysStayLabel.Bottom + 3);
            daysStayCbo.DropDownStyle = ComboBoxStyle.DropDownList;
            daysStayCbo.FlatStyle = FlatStyle.Flat;
            daysStayCbo.Font = new Font("Arial", 12, FontStyle.Regular);
            daysStayCbo.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            daysStayCbo.ValueMember= "Value";
            daysStayCbo.DisplayMember = "dias";
            daysStayCbo.DataSource = GetDaysStayToComboBox();
            if (daysStayCbo.Items.Count > 0)
            {
                daysStayCbo.SelectedIndex = 0;
            }

            this.Controls.Add(daysStayCbo);

            this.checkInLabel = new Label();
            checkInLabel.Text = "Check-in:";
            checkInLabel.AutoSize = true;
            checkInLabel.Location = new Point((this.ClientSize.Width - checkInLabel.Width) / 3, daysStayCbo.Bottom + 20);
            this.Controls.Add(checkInLabel);

            this.checkInDTPicker = new DateTimePicker();
            checkInDTPicker.Size = new Size(130, 35);
            checkInDTPicker.Location = new Point((this.ClientSize.Width - checkInDTPicker.Width) / 5, checkInLabel.Bottom + 3);
            checkInDTPicker.Font = new Font("Arial", 12, FontStyle.Regular);
            checkInDTPicker.Format = DateTimePickerFormat.Short;
            checkInDTPicker.Value = DateTime.Now;
            this.Controls.Add(checkInDTPicker);

            this.checkOutLabel = new Label();
            checkOutLabel.Text = "Check-out:";
            checkOutLabel.AutoSize = true;
            checkOutLabel.Location = new Point(checkInDTPicker.Right + 40, daysStayCbo.Bottom + 20);            
            this.Controls.Add(checkOutLabel);


            DateTime checkOutDate = CalculateCheckOutDate();
            this.checkOutDTPicker = new DateTimePicker();
            checkOutDTPicker.Size = new Size(130, 35);
            checkOutDTPicker.Location = new Point(checkInDTPicker.Right + 40, checkOutLabel.Bottom + 3);
            checkOutDTPicker.Font = new Font("Arial", 12, FontStyle.Regular);
            checkOutDTPicker.Format = DateTimePickerFormat.Short;
            checkOutDTPicker.Value = checkOutDate;
            this.Controls.Add(checkOutDTPicker);


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
                this.Hide();
                var mainScreen = new MainScreen();
                mainScreen.ShowDialog();
                this.Show();
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