using System;
using System.Windows.Forms;
using Views;
using Controllers;


namespace Views
{

    public class ListarQuartos : Form
    {

        private static void DeleteRoom(int id){
            try{
                Controllers.Room.destroy(id);
            }catch(Exception e){
                throw e;
            }
        }
        public ListarQuartos()
        {
            this.Text = "Lista";
            this.Size = new System.Drawing.Size(400, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            Color color = System.Drawing.ColorTranslator.FromHtml("#E0E6ED");
            this.BackColor = color;

            Label Room = new Label();
            Room.Text = "Quartos";
            Room.Location = new System.Drawing.Point(30, 30);
            Room.Size = new System.Drawing.Size(400, 60);
            Room.Font = new System.Drawing.Font("Arial", 25, System.Drawing.FontStyle.Bold);

            ListView listview = new ListView();
            listview.Location = new System.Drawing.Point(30, 90);
            listview.Size = new System.Drawing.Size(500, 350);
            listview.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            listview.View = View.Details;
            listview.Columns.Add("Id", -2, HorizontalAlignment.Left);
            listview.Columns.Add("Andar", -2, HorizontalAlignment.Left);
            listview.Columns.Add("Número", -2, HorizontalAlignment.Left);
            listview.Columns.Add("Tipo", -2, HorizontalAlignment.Left);
            listview.Columns.Add("Observação", -2, HorizontalAlignment.Left);

            Panel panelList = new Panel();
            panelList.Size = new System.Drawing.Size(this.Width, 85);
            panelList.Location = new System.Drawing.Point(0, 480);
            Color color2 = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            panelList.BackColor = color2;

            Button buttonAdd = new Button();
            buttonAdd.Text = "Cadastrar";
            buttonAdd.Location = new System.Drawing.Point(150, 500);
            buttonAdd.Size = new System.Drawing.Size(95, 40);
            buttonAdd.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Color colorButtonAdd = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            buttonAdd.BackColor = colorButtonAdd;
            buttonAdd.Click += (sender, args) =>
            {
                this.Close();
                this.Dispose();
                var registerRoom = new RegisterRoom();
                registerRoom.ShowDialog();
            };

            Button buttonEdit = new Button();
            buttonEdit.Text = "Editar";
            buttonEdit.Location = new System.Drawing.Point(250, 500);
            buttonEdit.Size = new System.Drawing.Size(95, 40);
            buttonEdit.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Color colorButtonEdit = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            buttonEdit.BackColor = colorButtonEdit;
            buttonEdit.Click += (sender, args) =>
            {
                this.Close();
                this.Dispose();
                var editRoom = new UpdateRoom();
                editRoom.ShowDialog();
                
            };

            Button buttonDelete = new Button();
            buttonDelete.Text = "Excluir";
            buttonDelete.Location = new System.Drawing.Point(350, 500);
            buttonDelete.Size = new System.Drawing.Size(95, 40);
            buttonDelete.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Color colorButtonDelete = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            buttonDelete.BackColor = colorButtonDelete;
            buttonDelete.Click += (sender, args) =>
            {   
                this.Close();
                this.Dispose();
            };

            Button buttonReturn = new Button();
            buttonReturn.Text = "Voltar";
            buttonReturn.Location = new System.Drawing.Point(450, 500);
            buttonReturn.Size = new System.Drawing.Size(95, 40);
            buttonReturn.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Color colorButtonReturn = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            buttonReturn.BackColor = colorButtonReturn;
            buttonReturn.Click += (sender, args) =>
            {
                this.Close();
                this.Dispose();
                var initialScreen = new InitialScreen();
                initialScreen.ShowDialog();   
            };

            
            TableLayoutPanel buttonsLayoutPanel = new TableLayoutPanel();
            buttonsLayoutPanel.Dock = DockStyle.Bottom;
            buttonsLayoutPanel.AutoSize = true;
            buttonsLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonsLayoutPanel.Padding = new Padding(10, 10, 10, 10);
            buttonsLayoutPanel.BackColor = ColorTranslator.FromHtml("#3C4858");
            buttonsLayoutPanel.ColumnCount = 4;
            buttonsLayoutPanel.RowCount = 1;
            buttonsLayoutPanel.ColumnStyles.Clear();

            for (int i = 0; i < buttonsLayoutPanel.ColumnCount; i++)
            {
                buttonsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }

            Button btnRegisterRoom = new Button();
            btnRegisterRoom.Text = "Cadastrar";
            btnRegisterRoom.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btnRegisterRoom.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btnRegisterRoom.Size = new Size(110, 35);
            btnRegisterRoom.Font = new Font("Roboto", 8, FontStyle.Regular);
            btnRegisterRoom.FlatStyle = FlatStyle.Flat;
            btnRegisterRoom.FlatAppearance.BorderSize = 0;
            btnRegisterRoom.Dock = DockStyle.Fill;
            btnRegisterRoom.Click += (sender, e) =>
            {
                this.Hide();
                var mainScreen = new MainScreen();
                mainScreen.ShowDialog();
                this.Show();
            };

            Button btnExit = new Button();
            btnExit.Text = "Sair";
            btnExit.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btnExit.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btnExit.Size = new Size(110, 35);
            btnExit.Font = new Font("Roboto", 8, FontStyle.Regular);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Click += (sender, e) =>
            {
                this.Close();
            };

            buttonsLayoutPanel.Controls.Add(btnRegisterRoom, 1, 0);
            buttonsLayoutPanel.Controls.Add(btnExit, 2, 0);
            this.Controls.Add(buttonsLayoutPanel);

            this.ShowDialog();
            
            this.Controls.Add(buttonReturn);
            this.Controls.Add(buttonDelete);
            this.Controls.Add(buttonEdit);
            this.Controls.Add(buttonAdd);
            this.Controls.Add(panelList);
            this.Controls.Add(Room);
            this.Controls.Add(listview);
            this.ShowDialog();
        }
    }
}