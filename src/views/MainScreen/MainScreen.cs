using Controllers;
using Models;

namespace Views
{
    public class MainScreen : Form
    {

        public event EventHandler<string> ButtonClicked;
        public int availableCount { get; set; }
        public int occupiedCount { get; set; }
        public int reservedCount { get; set; }
        public int cleaningCount { get; set; }
        public Button button1;



        // private Dictionary<string, int> colorCounts = new Dictionary<string, int>();


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


        // public void button_Click( string status)
        // {
        //     Button button1 = new Button();

        //     switch (status)
        //     {
        //         case "RESERVED":
        //             button1.BackColor = ColorTranslator.FromHtml("#F7DB6A"); // Amarelo para quarto reservado
        //             reservedCount++;
        //             break;
        //         case "OCCUPIED":
        //             button1.BackColor = ColorTranslator.FromHtml("#B73E3E"); // Vermelho para quarto ocupado
        //             occupiedCount++;
        //             break;
        //         case "CLEANING":
        //             button1.BackColor = ColorTranslator.FromHtml("#7FBCD2"); // Laranja para quarto em limpeza
        //             cleaningCount++;
        //             break;
        //         default:
        //             button1.BackColor = ColorTranslator.FromHtml("#539165"); // Cor padrão para outros status
        //             availableCount++;
        //             break;
        //     }

        //     button1.ForeColor = Color.White;
        //     button1.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#242424");

        //     // ButtonClicked?.Invoke(button, status);

        // }


        private void createSquares()
        {
            int sizeSquare = 130;
            int spacingSquare = 15;

            foreach (int quantityRoom in getNumbersRooms())
            {
                Button button1 = new Button();
                button1.Text = quantityRoom.ToString();
                button1.Size = new Size(sizeSquare, sizeSquare);
                button1.Location = new Point((quantityRoom - 1) * (sizeSquare + spacingSquare), 0);
                button1.Click += (sender, e) => 
                {
                    // button_Click("RESERVED");
                };
                Controls.Add(button1);
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



            MenuStrip menuStrip = new MenuStrip();
            menuStrip.Dock = DockStyle.Top;

            //Cadastro
            ToolStripMenuItem menuItemRegister = new ToolStripMenuItem();
            menuItemRegister.Text = "Cadastros";

            //Vizualização      
            ToolStripMenuItem menuItemViews = new ToolStripMenuItem();
            menuItemViews.Text = "Vizualizações";

            //Balanço
            ToolStripMenuItem menuItemStatements = new ToolStripMenuItem();
            menuItemStatements.Text = "Balanços";

            //Cadastro
            ToolStripMenuItem subMenuItemRegisterRooms = new ToolStripMenuItem();
            subMenuItemRegisterRooms.Text = "Quartos";
            subMenuItemRegisterRooms.Click += (sender, e) =>
            {
                var registerRoom = new RegisterRoom();
                registerRoom.ShowDialog();
                this.Show();
            }; ;

            ToolStripMenuItem subMenuItRegisterEmemployees = new ToolStripMenuItem();
            subMenuItRegisterEmemployees.Text = "Funcionários";
            subMenuItRegisterEmemployees.Click += (sender, e) =>
            {
                // var registerEmployee = new RegisterEmployee();
                // registerEmployee.ShowDialog();
                this.Show();
            };

            ToolStripMenuItem subMenuItemRegisterProducts = new ToolStripMenuItem();
            subMenuItemRegisterProducts.Text = "Produtos";
            subMenuItemRegisterProducts.Click += (sender, e) =>
            {
                // var registerProduct = new RegisterProduct();
                // registerProduct.ShowDialog();
                this.Show();
            };

            //Vizualização      
            ToolStripMenuItem subMenuItemViewsRooms = new ToolStripMenuItem();
            subMenuItemViewsRooms.Text = "Quartos";
            subMenuItemViewsRooms.Click += (sender, e) =>
            {
                var listRooms = new List();
                listRooms.ShowDialog();
                this.Show();
            }; ;

            ToolStripMenuItem subMenuItemViewsEmployees = new ToolStripMenuItem();
            subMenuItemViewsEmployees.Text = "Funcionários";
            subMenuItemViewsEmployees.Click += (sender, e) =>
            {
                // var listEmployees = new List();
                // listEmployees.ShowDialog();
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
                this.Show();
            };

            if(Models.Guest.)
            menuItemRegister.DropDownItems.Add(subMenuItemRegisterRooms);
            menuItemRegister.DropDownItems.Add(subMenuItRegisterEmemployees);
            menuItemRegister.DropDownItems.Add(subMenuItemRegisterProducts);
            menuItemViews.DropDownItems.Add(subMenuItemViewsRooms);
            menuItemViews.DropDownItems.Add(subMenuItemViewsEmployees);
            menuItemViews.DropDownItems.Add(subMenuItemViewsProducts);
            menuItemStatements.DropDownItems.Add(subMenuItemStatementsProducts);
            menuItemStatements.DropDownItems.Add(subMenuItemStatementsAccommodation);

            menuStrip.Items.Add(menuItemRegister);
            menuStrip.Items.Add(menuItemViews);
            menuStrip.Items.Add(menuItemStatements);

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
                string roomId = quantityRoom.ToString(); // Substitua pelo valor correto

                Button button = new Button();
                button.Text = quantityRoom.ToString();
                button.Size = new Size(sizeSquare, sizeSquare);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 1;
                button.Font = new Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                button.BackColor = ColorTranslator.FromHtml("#539165");
                button.ForeColor = ColorTranslator.FromHtml("#ffffff");
                button.Margin = new Padding(spacingSquare / 2);
                button.Click += (sender, e) =>
                {
                    var checkIn = new CheckIn(roomId);
                    checkIn.ShowDialog();
                    this.Show();
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



    }

}