using Controllers;
using Models;
using System.Windows.Forms;


namespace Views
{
    public class MainScreen : Form
    {

        private List<Button> buttons = new List<Button>();
        public int availableCount { get; set; }
        public int occupiedCount { get; set; }
        public int reservedCount { get; set; }
        public int cleaningCount { get; set; }
        public bool isCleaning { get; set; }
        public bool isAdmin { get; set; }
        public Button button { get; set; }
        public MenuStrip menuStrip;
        public ToolStripMenuItem menuItemRegister;
        public ToolStripMenuItem menuItemViews;
        public ToolStripMenuItem menuItemStatements;


      

        public void GetOptionsAdmin(Models.Employee employee)
        {
            if (employee != null)
            {
                isAdmin = employee.Type;

                if (isAdmin)
                {
                    menuStrip.Items.Add(menuItemRegister);
                    menuStrip.Items.Add(menuItemViews);
                    menuStrip.Items.Add(menuItemStatements);
                }
            }


        }

        public void isCleaningRoom(Models.Reservation reservation)
        {
            DateTime today = DateTime.Now;
            if(reservation.CheckOut.Date != today.Date)
            {
                var clean = new CreateCLean();
                clean.ShowDialog();
            }

            isCleaning = true;
        }


        private List<int> getNumbersRooms()
        {
            List<Models.Room> rooms = Controllers.Room.index();
            List<Models.Room> roomsNumbers = rooms.OrderBy(room => room.Number).ToList();

            List<int> quantityRooms = new List<int>();

            foreach (Models.Room room in roomsNumbers)
            {
                if (room.Number > 0)
                {
                    quantityRooms.Add(room.Number);
                }
            }

            return quantityRooms;
        }


        private void createSquares()
        {
            int sizeSquare = 130;
            int spacingSquare = 15;

            List<int> quantityRooms = getNumbersRooms();

            foreach (int quantityRoom in quantityRooms)
            {
                Button button = new Button();
                button.Text = quantityRoom.ToString();
                button.Size = new Size(sizeSquare, sizeSquare);
                button.Location = new Point((quantityRoom - 1) * (sizeSquare + spacingSquare), 0);
                // button.Click += Button_Click;
                buttons.Add(button);
                Controls.Add(button);
            }
        }


        private Panel createSquare(Color color, string name, int count)
        {
            Panel square = new Panel();
            square.BackColor = color;
            square.Dock = DockStyle.Fill;
            square.ForeColor = BackColor;

            int sizeWidth = 100;
            int sizeHeight = 20;
            square.Size = new Size(sizeWidth, sizeHeight);


            Label countLabel = new Label();
            countLabel.Text = name + ": " + count.ToString();
            countLabel.ForeColor = Color.White;
            countLabel.TextAlign = ContentAlignment.MiddleCenter;
            countLabel.Dock = DockStyle.Bottom;
            countLabel.Font = new Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            // square.Controls.Add(nameLabel);
            square.Controls.Add(countLabel);

            return square;
        }

        public MainScreen()
        {

            this.Icon = new Icon("Assets/logoUm.ico", 52, 52);
            this.Text = "Bem vindo";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.ControlBox = true;
            this.BackColor = ColorTranslator.FromHtml("#E0E6ED");
    
            this.menuStrip = new MenuStrip();
            menuStrip.Dock = DockStyle.Top;

            //Cadastro
            this.menuItemRegister = new ToolStripMenuItem();
            menuItemRegister.Text = "Cadastros";

            //Vizualização      
            this.menuItemViews = new ToolStripMenuItem();
            menuItemViews.Text = "Vizualizações";

            //Balanço
            this.menuItemStatements = new ToolStripMenuItem();
            menuItemStatements.Text = "Balanços";


            //Cadastro
            ToolStripMenuItem subMenuItemRegisterRooms = new ToolStripMenuItem();
            subMenuItemRegisterRooms.Text = "Quartos";
            subMenuItemRegisterRooms.Click += (sender, e) =>
            {
                var registerRoom = new RoomCreate();
                registerRoom.ShowDialog();
                this.ShowDialog();
            }; ;

            ToolStripMenuItem subMenuItRegisterEmemployees = new ToolStripMenuItem();
            subMenuItRegisterEmemployees.Text = "Funcionários";
            subMenuItRegisterEmemployees.Click += (sender, e) =>
            {
                var registerEmployee = new EmployeeCreate();
                registerEmployee.ShowDialog();
                this.Show();
            };

            ToolStripMenuItem subMenuItemRegisterGuests = new ToolStripMenuItem();
            subMenuItemRegisterGuests.Text = "Hospede";
            subMenuItemRegisterGuests.Click += (sender, e) =>
            {
                var registerGuest = new CreateGuest();
                registerGuest.FormClosed += (s, args) => 
                {
                    this.Show();
                };
                registerGuest.ShowDialog();
                this.ShowDialog();
            }; ;

            ToolStripMenuItem subMenuItemRegisterProducts = new ToolStripMenuItem();
            subMenuItemRegisterProducts.Text = "Produtos";
            subMenuItemRegisterProducts.Click += (sender, e) =>
            {
                var registerProduct = new CreateProduct();
                registerProduct.ShowDialog();
                this.Show();
            };

            ToolStripMenuItem subMenuItemViewsRooms = new ToolStripMenuItem();
            subMenuItemViewsRooms.Text = "Quartos";
            subMenuItemViewsRooms.Click += (sender, e) =>
            {
                var listRooms = new ListRoom();
                listRooms.FormClosed += (s, args) =>
                {
                    this.Show(); 
                };
                listRooms.ShowDialog();
            };

            ToolStripMenuItem subMenuItemViewsEmployees = new ToolStripMenuItem();
            subMenuItemViewsEmployees.Text = "Funcionários";
            subMenuItemViewsEmployees.Click += (sender, e) =>
            {
                var listEmployees = new Views.ListEmployee();
                listEmployees.ShowDialog();
                this.Show();
            };

            ToolStripMenuItem subMenuItemViewsGuests = new ToolStripMenuItem();
            subMenuItemViewsGuests.Text = "Hospedes";
            subMenuItemViewsGuests.Click += (sender, e) =>
            {
                var listGuests = new Views.ListGuest();
                listGuests.Click += (s, args) =>
                {
                    this.Show();
                };
                listGuests.ShowDialog();
                this.Show();
            };

            ToolStripMenuItem subMenuItemViewsProducts = new ToolStripMenuItem();
            subMenuItemViewsProducts.Text = "Produtos";
            subMenuItemViewsProducts.Click += (sender, e) =>
            {
                var listProoducts = new List();
                listProoducts.ShowDialog();
                this.Show();
            }; ;

            //Balanço
            ToolStripMenuItem subMenuItemStatementsProducts = new ToolStripMenuItem();
            subMenuItemStatementsProducts.Text = "Produtos";
            subMenuItemStatementsProducts.Click += (sender, e) =>
            {
                // var statementsProducts = new StatementsProducts();
                // statementsProducts.ShowDialog();
                this.Show();
            };

            ToolStripMenuItem subMenuItemStatementsAccommodation = new ToolStripMenuItem();
            subMenuItemStatementsAccommodation.Text = "Hospedagem";
            subMenuItemStatementsAccommodation.Click += (sender, e) =>
            {
                // var statementsAccommodation = new StatementsAccommodation();
                // statementsAccommodation.ShowDialog();
                // this.Show();
            };


            menuItemRegister.DropDownItems.Add(subMenuItemRegisterRooms);
            menuItemRegister.DropDownItems.Add(subMenuItemRegisterGuests);
            menuItemRegister.DropDownItems.Add(subMenuItRegisterEmemployees);
            menuItemRegister.DropDownItems.Add(subMenuItemRegisterProducts);
            menuItemViews.DropDownItems.Add(subMenuItemViewsRooms);
            menuItemViews.DropDownItems.Add(subMenuItemViewsEmployees);
            menuItemViews.DropDownItems.Add(subMenuItemViewsGuests);
            menuItemViews.DropDownItems.Add(subMenuItemViewsProducts);
            menuItemStatements.DropDownItems.Add(subMenuItemStatementsProducts);
            menuItemStatements.DropDownItems.Add(subMenuItemStatementsAccommodation);



            Controls.Add(menuStrip);



            int sizeSquare = 105;
            int spacingSquare = 15;
            int columnsSquare = 6;
            int rowsSquare = 3;

            int widthTable = columnsSquare * (sizeSquare + spacingSquare) - spacingSquare;
            int heightTable = rowsSquare * (sizeSquare + spacingSquare) - spacingSquare;

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Size = new Size(widthTable, heightTable);
            tableLayoutPanel.Location = new Point((this.ClientSize.Width - widthTable) / 2, (this.ClientSize.Height - heightTable) / 2);
            tableLayoutPanel.ColumnCount = columnsSquare;
            tableLayoutPanel.RowCount = rowsSquare;
            tableLayoutPanel.ColumnStyles.Clear();
            tableLayoutPanel.RowStyles.Clear();

            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / tableLayoutPanel.ColumnCount));
            }

            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / tableLayoutPanel.RowCount));
            }

            for (int i = 0; i < getNumbersRooms().Count; i++)
            {
                int quantityRoom = getNumbersRooms()[i];
                int roomId = quantityRoom;

                this.button = new Button();
                button.Text = quantityRoom.ToString();
                button.Size = new Size(sizeSquare, sizeSquare);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 1;
                button.Font = new Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                button.ForeColor = ColorTranslator.FromHtml("#ffffff");

                Models.Reservation reservation = Controllers.Reservation.findByNumberRoom(roomId);
               
                DateTime today = DateTime.Now;
                if (reservation != null)
                {
                    if (reservation.CheckIn.Date == today.Date)
                    {
                        button.BackColor = ColorTranslator.FromHtml("#B73E3E");
                    }
                    else
                    {
                        button.BackColor = ColorTranslator.FromHtml("#F7DB6A");
                    }
                }
                else
                {
                    button.BackColor = ColorTranslator.FromHtml("#539165");
                }


               

                button.Margin = new Padding(spacingSquare / 2);
                button.Click += (sender, e) =>
                {
                    Models.Reservation roomAvailable = Controllers.Reservation.findByNumberRoom(roomId);
                    if(roomAvailable == null)
                    {
                        var checkIn = new CheckIn(roomId);
                        checkIn.Show();
                    }
                    else
                    {
                       ConfirmReserve(roomId);
                    }
                    
                };
                tableLayoutPanel.Controls.Add(button, i, 0);
            }





            Color colorOccupied = ColorTranslator.FromHtml("#B73E3E");
            Color colorReserved = ColorTranslator.FromHtml("#F7DB6A");
            Color colorAvailable = ColorTranslator.FromHtml("#539165");
            Color colorCleaning = ColorTranslator.FromHtml("#7FBCD2");

            string nameOccupied = "Ocupado";
            string nameReserved = "Reservado";
            string nameAvailable = "Disponível";
            string nameCleaning = "Limpeza";

            TableLayoutPanel roomLayoutPanel = new TableLayoutPanel();
            roomLayoutPanel.Dock = DockStyle.Bottom;
            roomLayoutPanel.AutoSize = true;
            roomLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            roomLayoutPanel.Height = 80;
            roomLayoutPanel.BackColor = ColorTranslator.FromHtml("#3C4858");
            roomLayoutPanel.Location = new Point((this.ClientSize.Width - widthTable) / 2, (this.ClientSize.Height - heightTable) / 3);
            roomLayoutPanel.Padding = new Padding(spacingSquare / 1, spacingSquare / 2, spacingSquare / 1, spacingSquare / 2);
            roomLayoutPanel.ColumnCount = 14;
            roomLayoutPanel.ColumnStyles.Clear();


            for (int i = 0; i < roomLayoutPanel.ColumnCount; i++)
            {
                roomLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            };

            List<Models.Reservation> reservations = Controllers.Reservation.index();

            DateTime currentDate = DateTime.Today;

            int occupiedCount = reservations.Count(r => r.CheckIn.Date == currentDate);
            int reservedCount = reservations.Count(r => r.CheckIn.Date != currentDate);
            int availableCount = getNumbersRooms().Count - occupiedCount - reservedCount;

            Panel roomOccupied = createSquare(colorOccupied, nameOccupied, occupiedCount);
            Panel roomReserved = createSquare(colorReserved, nameReserved, reservedCount);
            Panel roomAvailable = createSquare(colorAvailable, nameAvailable, availableCount);
            Panel roomCleaning = createSquare(colorCleaning, nameCleaning, cleaningCount);

            roomLayoutPanel.Controls.Add(roomOccupied, 5, 0);
            roomLayoutPanel.Controls.Add(roomReserved, 6, 0);
            roomLayoutPanel.Controls.Add(roomAvailable, 7, 0);
            roomLayoutPanel.Controls.Add(roomCleaning, 8, 0);

            Controls.Add(roomLayoutPanel);
            Controls.Add(tableLayoutPanel);


        }

        public void ConfirmReserve(int roomId)
        {
            Models.Reservation reservation = Controllers.Reservation.findByNumberRoom(roomId);

            Form formConfirmReserve = new Form();
            formConfirmReserve.Text = "Reserva - " + roomId;
            formConfirmReserve.Size = new Size(350, 400);
            formConfirmReserve.StartPosition = FormStartPosition.CenterScreen;
            formConfirmReserve.FormBorderStyle = FormBorderStyle.FixedSingle;
            formConfirmReserve.MaximizeBox = false;
            formConfirmReserve.MinimizeBox = false;
            formConfirmReserve.ControlBox = true;
            formConfirmReserve.BackColor = ColorTranslator.FromHtml("#f5f5f5");


            Label titleMessageBox = new Label();
            titleMessageBox.Text = "Reserva - " + roomId;
            titleMessageBox.AutoSize = true;
            titleMessageBox.Location = new Point(30, 30);
            titleMessageBox.Font = new Font("Arial", 16, FontStyle.Bold);
            titleMessageBox.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            formConfirmReserve.Controls.Add(titleMessageBox);

            ListBox listBox = new ListBox();
            listBox.Location = new Point(45, 120);
            listBox.Size = new Size(250, 120);
            listBox.Font = new Font("Arial", 11, FontStyle.Regular);
            listBox.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            listBox.BorderStyle = BorderStyle.None;
            listBox.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            listBox.Margin = new Padding(listBox.Margin.Left, listBox.Margin.Top + 10, listBox.Margin.Right, listBox.Margin.Bottom);


            listBox.Items.Add("Hospede: " +  reservation.GuestId);
            listBox.Items.Add("Quarto: " + reservation.RoomNumber);
            listBox.Items.Add("Dias: " + reservation.DaysOfStay);
            listBox.Items.Add("CheckIn: " + reservation.CheckIn);
            listBox.Items.Add("CheckOut: " + reservation.CheckOut);
            listBox.Items.Add("Valor: " + reservation.Total);

            Button buttonYes = new Button();
            buttonYes.Text = "Cancelar reserva";
            buttonYes.Size = new Size(100, 30);
            buttonYes.Location = new Point(95, 300);
            buttonYes.FlatStyle = FlatStyle.Flat;   
            buttonYes.FlatAppearance.BorderSize = 1;
            buttonYes.Font = new Font("Roboto", 8, FontStyle.Regular);
            buttonYes.ForeColor = ColorTranslator.FromHtml("#ffffff");
            buttonYes.BackColor = ColorTranslator.FromHtml("#78909C");
            buttonYes.Click += (sender, e) =>
            {
                // Controllers.Reservation.destroy(reservation.Id);
                isCleaningRoom(reservation);
                formConfirmReserve.Close();
            };

            Button buttonNo = new Button();
            buttonNo.Text = "Fechar";
            buttonNo.Size = new Size(100, 30);
            buttonNo.Location = new Point(200, 300);
            buttonNo.FlatStyle = FlatStyle.Flat;
            buttonNo.FlatAppearance.BorderSize = 1;
            buttonNo.Font = new Font("Roboto", 8, FontStyle.Regular);
            buttonNo.ForeColor = ColorTranslator.FromHtml("#ffffff");
            buttonNo.BackColor = ColorTranslator.FromHtml("#78909C");
            buttonNo.Click += (sender, e) =>
            {
                formConfirmReserve.Close();
            };

            formConfirmReserve.Controls.Add(listBox);
            
            if(isAdmin)
            {
                formConfirmReserve.Controls.Add(buttonYes);
                formConfirmReserve.Controls.Add(buttonNo);
            }

            
            formConfirmReserve.ShowDialog();

        }



        



    }

}