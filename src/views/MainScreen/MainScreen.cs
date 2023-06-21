using Controllers;
using Models;

namespace Views
{
    public class MainScreen : Form
    {

        private int[,] quantityRooms = {
            {101, 102, 103, 104, 105, 106},
            {201, 202, 203, 204, 205, 206},
            {301, 302, 303, 304, 305, 306}
        };

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = ColorTranslator.FromHtml("#B73E3E");
            button.ForeColor = Color.White;
            button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#242424");
            // var checkIn = new CheckIn();
            // checkIn.ShowDialog();
            // this.Show();
        }

        private void createSquares()
        {
            int sizeSquare = 130; 
            int spacingSquare = 15; 

            for (int i = 0; i < quantityRooms.GetLength(0); i++)
            {
                for (int j = 0; j < quantityRooms.GetLength(1); j++)
                {
                    int quantityRoom = quantityRooms[i, j];

                    Button button = new Button();
                    button.Text = quantityRoom.ToString();
                    button.Size = new Size(sizeSquare, sizeSquare);
                    button.Location = new Point(j * (sizeSquare + spacingSquare), i * (sizeSquare + spacingSquare));
                    button.Click += button_Click; 
                    Controls.Add(button); 
                }
            }
        }
        private Panel createSquare(Color color, string name)
        {
            Panel square = new Panel();
            square.BackColor = color;
            square.Dock = DockStyle.Fill;
            square.ForeColor = BackColor;


            int sizeWidth = 50; 
            int sizeHeight = 20;
            square.Size = new Size(sizeWidth, sizeHeight);

            Label label = new Label();
            label.Text = name;
            label.ForeColor = Color.White;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Fill;
            label.Font = new Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, GraphicsUnit.
            Point, ((byte)(0)));

            square.Controls.Add(label);

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
            subMenuItemRegisterRooms.Click += (sender, e) => {
                var registerRoom = new RegisterRoom();
                registerRoom.ShowDialog();
                this.Show();
            };;

            ToolStripMenuItem subMenuItRegisterEmemployees = new ToolStripMenuItem();
            subMenuItRegisterEmemployees.Text = "Funcionários";
            subMenuItRegisterEmemployees.Click += (sender, e) => {
                // var registerEmployee = new RegisterEmployee();
                // registerEmployee.ShowDialog();
                this.Show();
            };

            ToolStripMenuItem subMenuItemRegisterProducts = new ToolStripMenuItem();
            subMenuItemRegisterProducts.Text = "Produtos";
            subMenuItemRegisterProducts.Click += (sender, e) => {
                // var registerProduct = new RegisterProduct();
                // registerProduct.ShowDialog();
                this.Show();
            };

            //Vizualização      
            ToolStripMenuItem subMenuItemViewsRooms = new ToolStripMenuItem();
            subMenuItemViewsRooms.Text = "Quartos";
            subMenuItemViewsRooms.Click += (sender, e) => {
                var listRooms = new List();
                listRooms.ShowDialog();
                this.Show();
            };;

            ToolStripMenuItem subMenuItemViewsEmployees = new ToolStripMenuItem();
            subMenuItemViewsEmployees.Text = "Funcionários";
            subMenuItemViewsEmployees.Click += (sender, e) => {
                // var listEmployees = new List();
                // listEmployees.ShowDialog();
                this.Show();
            };

            ToolStripMenuItem subMenuItemViewsProducts = new ToolStripMenuItem();
            subMenuItemViewsProducts.Text = "Produtos";
            subMenuItemViewsProducts.Click +=  (sender, e) => {
                var listProoducts = new List();
                listProoducts.ShowDialog();
                this.Show();
            };;

            //Balanço
            ToolStripMenuItem subMenuItemStatementsProducts = new ToolStripMenuItem();
            subMenuItemStatementsProducts.Text = "Produtos";
            subMenuItemStatementsProducts.Click += (sender, e) => {
                // var statementsProducts = new StatementsProducts();
                // statementsProducts.ShowDialog();
                this.Show();
            };

            ToolStripMenuItem subMenuItemStatementsAccommodation = new ToolStripMenuItem();
            subMenuItemStatementsAccommodation.Text = "Hospedagem";
            subMenuItemStatementsAccommodation.Click += (sender, e) => {
                // var statementsAccommodation = new StatementsAccommodation();
                // statementsAccommodation.ShowDialog();
                this.Show();
            };

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

            for (int i = 0; i < quantityRooms.GetLength(0); i++)
            {
                for (int j = 0; j < quantityRooms.GetLength(1); j++)
                {
                    int quantityRoom = quantityRooms[i, j];

                    Button button = new Button();
                    button.Text = quantityRoom.ToString();
                    button.Size = new Size(sizeSquare, sizeSquare);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 1;
                    button.Font = new Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold, GraphicsUnit.
                    Point, ((byte)(0)));
                    button.BackColor = ColorTranslator.FromHtml("#539165");
                    button.ForeColor = ColorTranslator.FromHtml("#ffffff");
                    button.Margin = new Padding(spacingSquare / 2); 
                    button.Click += (sender, e) => 
                    {
                        var room = new CheckIn(quantityRoom.ToString());
                        room.ShowDialog();
                        this.Show();
                       
                    };

                    tableLayoutPanel.Controls.Add(button, j, i);
                };

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
            roomLayoutPanel.BackColor= ColorTranslator.FromHtml("#3C4858");
            roomLayoutPanel.Location = new Point((this.ClientSize.Width - widthTable) / 2, (this.ClientSize.Height - heightTable) / 3 );
            roomLayoutPanel.Padding =  new Padding(spacingSquare / 1, spacingSquare / 2, spacingSquare / 1, spacingSquare / 2);
            roomLayoutPanel.ColumnCount = 14;
            roomLayoutPanel.ColumnStyles.Clear();
            

            for (int i = 0; i < roomLayoutPanel.ColumnCount; i++)
            {
                roomLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            }

            Panel roomOccupied = createSquare(colorOccupied, nameOccupied);
            Panel roomReserved = createSquare(colorReserved, nameReserved);
            Panel roomAvailable = createSquare(colorAvailable, nameAvailable);
            Panel roomCleaning = createSquare(colorCleaning, nameCleaning);

            roomLayoutPanel.Controls.Add(roomOccupied, 5, 0);
            roomLayoutPanel.Controls.Add(roomReserved, 6, 0);
            roomLayoutPanel.Controls.Add(roomAvailable, 7, 0);
            roomLayoutPanel.Controls.Add(roomCleaning, 8, 0);

            Controls.Add(roomLayoutPanel);
            Controls.Add(tableLayoutPanel);


        }        



    }

}